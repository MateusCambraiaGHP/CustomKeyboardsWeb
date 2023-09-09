import { Component, Input, OnChanges } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { InputCustom } from "./models/input-custom.model";
import { RowCustom } from "./models/row-input-custom.model";
import { BackendErrors } from "../../customer/models/banck.model.erros";

@Component({
  selector: "app-form",
  templateUrl: "./form.component.html",
  styleUrls: ["./form.component.scss"]
})
export class FormComponent implements OnChanges {
  @Input() formGroup!: FormGroup;
  @Input() title!: string;
  @Input() subtitle!: string;
  @Input() submit!: Function;
  @Input() fillObject: any;
  @Input() _class!: string;
  @Input() inputs!: InputCustom[];
  @Input() rows!: RowCustom[];
  @Input() backendErrors: BackendErrors | undefined;
  @Input() showLoading = true as boolean;
  @Input() isErro = false as boolean;
  loading = false as boolean;
  formEnviado = false as boolean;
  constructor(public formBuilder: FormBuilder) {}

  bindInputs() {
    this.formGroup.controls = {};
    const entriesForm = (
      formGroup: any,
      childForm: any,
      keys: string[],
      indexKey = 0 as number
    ) => {
      const currentFormGroup = formGroup.controls[keys[indexKey]];
      const currentChildForm =
        childForm[keys[indexKey]] ?? childForm.controls[keys[indexKey]];

      if (currentFormGroup) {
        entriesForm(currentFormGroup, currentChildForm, keys, indexKey++);
      } else {
        formGroup.addControl(keys[indexKey], currentChildForm);
      }
    };

    this.rows.forEach(r => {
      if (r.inputCustom?.length) {
        r.inputCustom.forEach(ic => {
          if (ic.formControlName?.length) {
            const keys = ic.formControlName.split(".");
            let childForm = {};
            keys.forEach((key, index) => {
              childForm =
                index === keys.length - 1
                  ? { [key]: ic.control }
                  : { [key]: this.formBuilder.group(childForm) };
            });
            entriesForm(this.formGroup, childForm, keys);
          }
        });
      }
    });
  }

  ngOnChanges(): void {
    this.rows.forEach(e => {
      if (e.inputCustom) this.bindInputs();
    });
    if (this.fillObject) {
      this.fillObject.forEach((item: any) => {
        this.formGroup.patchValue(item);
      });
    }
  }

  async _submit() {
    if (!this.formGroup.valid) {
      this.loading = true;
      this.formEnviado = true;
    }
    this.loading = true;
    this.submitContinuing();
    if (this.backendErrors) this.isErro = true;
  }

  submitContinuing = async () => {
    if (this.showLoading) this.loading = true;
    this.loading = true;
    await this.submit();

    this.loading = false;
  };
}
