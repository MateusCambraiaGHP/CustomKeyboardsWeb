import { Component, Input } from '@angular/core';
import { InputCustom } from '../../generics/form/models/input-custom.model';
import { FormControl, FormGroup } from '@angular/forms';
import { Customer } from '../models/customer.model';
import { InputType } from '../../generics/form/enums/input-type.enum';

@Component({
    selector: 'app-customer-form',
    templateUrl: './customer-form.component.html',
    styleUrls: ['./customer-form.component.scss']
})
export class CustomerFormComponent {
    @Input() readonly: boolean = false;
    @Input()
    productReceived!: Customer;

    inputs: InputCustom[] = []
    form: FormGroup = new FormGroup({});

    customers = [
        { text: 'TesteSelect', value: '4c88815e-97bd-4009-bc97-27aa5d7ec9b1' },
        { text: 'TesteSelect', value: 'd5d1f355-9742-4a13-9770-9669d6eee884' },
    ]

    constructor(
    ) { }

    ngOnInit(): void {
        this.fillInputs();
    }

    fillInputs() {
        this.inputs = [
            {
                label: 'TesteSelect', controlName: 'categoriaId', control: new FormControl(''),
                optionsSelect: [
                    { titleSelect: "", options: this.customers }
                ], type: InputType.select, optionTextKey: 'key', optionValueKey: 'value'
            },
        ]
    }
}
