import {
    Component,
    ContentChild,
    Input,
    OnChanges,
    SimpleChanges,
    TemplateRef,
} from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { InputCustom } from "./models/input-custom.model";
import { RowCustom } from "./models/row-input-custom.model";
import { Customer } from "../../customer/models/customer.model";

@Component({
    selector: "app-form",
    templateUrl: "./form.component.html",
    styleUrls: ["./form.component.scss"],
})
export class FormComponent implements OnChanges {
    @ContentChild("beforeInput")
    beforeInput!: TemplateRef<any>;
    @ContentChild("insideInput") insideInput!: TemplateRef<any>;
    @Input() formGroup!: FormGroup;
    @Input() title!: string;
    @Input() subtitle!: string;
    @Input() submit!: Function;
    @Input() showLoading = true as boolean;
    @Input() fillObject: any;
    @Input() _class!: string;
    @Input() inputs!: InputCustom[];
    @Input() rows!: RowCustom[];
    loading: boolean = false;
    constructor(public formBuilder: FormBuilder) {}

    bindInputs() {
        this.formGroup.controls = {};
        const entriesForm = (
            formGroup: any,
            childForm: any,
            keys: string[],
            indexKey: number = 0
        ) => {
            const currentFormGroup = formGroup.controls[keys[indexKey]];
            const currentChildForm =
                childForm[keys[indexKey]] ?? childForm.controls[keys[indexKey]];
            if (currentFormGroup) {
                entriesForm(
                    currentFormGroup,
                    currentChildForm,
                    keys,
                    indexKey + 1
                );
            } else {
                formGroup.addControl(keys[indexKey], currentChildForm);
            }
        };

        this.rows.forEach((r) => {
            if (r.inputCustom !== undefined) {
                r.inputCustom.forEach((e) => {
                    if (e.formControlName != undefined) {
                        const keys = e.formControlName.split(".");
                        let childForm = {};
                        for (let i = keys.length; i > 0; i--) {
                            const key = keys[i - 1];
                            childForm =
                                i == keys.length
                                    ? { [key]: e.control }
                                    : {
                                          [key]: this.formBuilder.group(
                                              childForm
                                          ),
                                      };
                        }
                        entriesForm(this.formGroup, childForm, keys);
                    }
                });
            }
        });
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.rows.forEach((e) => {
            if (e.inputCustom) this.bindInputs();
        });
        if (this.fillObject) this.formGroup.patchValue(this.fillObject);
    }

    async _submit() {
        this.submitContinuing();
    }

    submitContinuing = async () => {
        if (this.showLoading) this.loading = true;
        await this.submit();
        this.loading = false;
    };
}
