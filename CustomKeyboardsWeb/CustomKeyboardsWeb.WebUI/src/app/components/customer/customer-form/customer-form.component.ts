import { Component, Input } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Customer } from "../models/customer.model";
import { InputType } from "../../generics/form/enums/input-type.enum";
import { RowCustom } from "../../generics/form/models/row-input-custom.model";
import { CustomerService } from "../services/products.service";

@Component({
    selector: "app-customer-form",
    templateUrl: "./customer-form.component.html",
    styleUrls: ["./customer-form.component.scss"],
})
export class CustomerFormComponent {
    @Input() readonly: boolean = false;
    @Input()
    productReceived!: Customer;
    rows: RowCustom[] = [];
    form: FormGroup = new FormGroup({});
    title: string = "Customer";

    customers = [
        { text: "TesteSelect", value: "teste1" },
        { text: "TesteSelect", value: "test 2" },
    ];

    constructor(private customerService: CustomerService) {}

    ngOnInit(): void {
        this.fillInputs();
    }

    fillInputs() {
        this.rows = [
            {
                inputCustom: [
                    {
                        label: "TesteSelect",
                        formControlName: "teste1",
                        control: new FormControl(""),
                        optionsSelect: [
                            { titleSelect: "", options: this.customers },
                        ],
                        type: InputType.select,
                        optionTextKey: "key",
                        optionValueKey: "value",
                        class: "col-md-3",
                    },
                    {
                        label: "zzz",
                        formControlName: "teste2",
                        control: new FormControl(""),
                        optionsSelect: [
                            { titleSelect: "", options: this.customers },
                        ],
                        type: InputType.select,
                        optionTextKey: "key",
                        optionValueKey: "value",
                        class: "col-md-3",
                    },
                    {
                        label: "textarea",
                        formControlName: "teste3",
                        control: new FormControl(""),
                        type: InputType.textArea,
                        optionTextKey: "key",
                        optionValueKey: "value",
                        class: "col-md-3",
                    },
                ],
            },
            {
                inputCustom: [
                    {
                        label: "TesteSelect",
                        formControlName: "teste4",
                        control: new FormControl(""),
                        optionsSelect: [
                            { titleSelect: "", options: this.customers },
                        ],
                        type: InputType.select,
                        optionTextKey: "key",
                        optionValueKey: "value",
                        class: "col-md-3",
                    },
                    {
                        label: "zzz",
                        formControlName: "teste5",
                        control: new FormControl(""),
                        optionsSelect: [
                            { titleSelect: "", options: this.customers },
                        ],
                        type: InputType.select,
                        optionTextKey: "key",
                        optionValueKey: "value",
                        class: "col-md-3",
                    },
                    {
                        label: "inputtext",
                        formControlName: "teste6",
                        control: new FormControl(""),
                        type: InputType.text,
                        optionTextKey: "key",
                        optionValueKey: "value",
                        class: "col-md-3",
                    },
                ],
            },
        ];
    }

    submitForm = async () => {
        const product: Customer = {
            ...this.productReceived,
            ...this.form.value,
        };

        console.log(product);
        const resp = this.productReceived
            ? await this.customerService.update(product)
            : await this.customerService.create(product);

        if (!resp) return;
    };
}
