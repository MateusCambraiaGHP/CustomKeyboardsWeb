import { Component, Input } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Customer } from "../models/customer.model";
import { InputType } from "../../generics/form/enums/input-type.enum";
import { RowCustom } from "../../generics/form/models/row-input-custom.model";
import { CustomerService } from "../services/products.service";
import { BackendErrors } from "../models/banck.model.erros";
import { ActivatedRoute } from "@angular/router";

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
    backendErrors: BackendErrors | undefined;
    isErro: boolean = false;

    federativeUnit = [
        { text: "MG", value: "1" },
        { text: "SP", value: "1" },
    ];

    constructor(private customerService: CustomerService,
        private route: ActivatedRoute) { }

    ngOnInit(): void {
        const id = this.route.snapshot.params['id'];
        console.log('ID:', id);
        this.fillInputs();
    }

    fillInputs() {
        this.rows = [
            {
                inputCustom: [
                    {
                        label: "Nome",
                        formControlName: "name",
                        control: new FormControl("", [Validators.required]),
                        type: InputType.text,
                        class: "col-md-4",
                    },
                    {
                        label: "Nome Fantasia",
                        formControlName: "fantasyName",
                        control: new FormControl("", [Validators.required]),
                        type: InputType.text,
                        class: "col-md-4",
                    },
                    {
                        label: "Ativo?",
                        formControlName: "active",
                        control: new FormControl("", [Validators.required]),
                        type: InputType.text,
                        class: "col-md-4",
                    },
                ],
            },
            {
                inputCustom: [
                    {
                        label: "Cep",
                        formControlName: "cep",
                        control: new FormControl("", [Validators.required]),
                        type: InputType.text,
                        class: "col-md-4",
                    },
                    {
                        label: "Endereço",
                        formControlName: "adress",
                        control: new FormControl("", [Validators.required]),
                        type: InputType.text,
                        class: "col-md-4",
                    },
                    {
                        label: "UF",
                        formControlName: "federativeUnit",
                        control: new FormControl("1", [Validators.required]),
                        optionsSelect: [
                            { options: this.federativeUnit },
                        ],
                        type: InputType.select,
                        class: "col-md-2",
                    },
                ],
            },
            {
                inputCustom: [
                    {
                        label: "Telefone",
                        formControlName: "phone",
                        control: new FormControl("", [Validators.required]),
                        type: InputType.text,
                        class: "col-md-4",
                    }
                ],
            },
        ];
    }

    submitForm = async () => {
        const Customer: Customer = {
            ...this.productReceived,
            ...this.form.value,
        };

        // const resp = this.productReceived
        //     ? await this.customerService.update(Customer)
        //     : await this.customerService.create(Customer);

        const resp = await this.customerService.create(Customer);

        this.backendErrors = resp?.errors;
        if (this.backendErrors)
            this.isErro = true;
        return resp;
    };
}
