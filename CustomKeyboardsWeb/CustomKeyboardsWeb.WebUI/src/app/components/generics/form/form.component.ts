import { Component, ContentChild, Input, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { InputCustom } from './models/input-custom.model';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {
	@ContentChild('beforeInput')
    beforeInput!: TemplateRef<any>;
	@ContentChild('insideInput') insideInput!: TemplateRef<any>;
	@Input() formGroup!: FormGroup;
	@Input() title!: string;
	@Input() subtitle!: string;
	@Input() submit!: Function;
	@Input() inputs!: InputCustom[];
	@Input() showLoading: boolean = true;
	@Input() _class!: string;

	loading: boolean = false;

	constructor(public formBuilder: FormBuilder) { }


	async _submit() {
		this.submitContinuing()
	}

	submitContinuing = async () => {
		if (this.showLoading) this.loading = true
		await this.submit();
		this.loading = false;
	}
}
