import { Component, ContentChild, Input, SimpleChanges, TemplateRef } from '@angular/core';
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
	@ContentChild('insideInput')
  insideInput!: TemplateRef<any>;
	@Input()
  formGroup!: FormGroup;
	@Input()
  title!: string;
	@Input()
  subtitle!: string;
	@Input()
  submit!: Function;
	@Input()
  inputs!: InputCustom[];
	@Input() fillObject: any;
	@Input() showLoading: boolean = true;
	@Input()
  showConfirmation!: boolean;
	@Input()
  subtitleLoading!: string;
	@Input()
  _class!: string;

	loading: boolean = false;

	constructor(public formBuilder: FormBuilder) { }

	ngOnChanges(changes: SimpleChanges): void {
		if (this.inputs) this.bindInputs();
		if (this.fillObject) this.formGroup.patchValue(this.fillObject);
	}

	bindInputs() {

		this.formGroup.controls = {}

		const entriesForm = (formGroup: any, childForm: any, keys: string[], indexKey: number = 0) => {
			const currentFormGroup = formGroup.controls[keys[indexKey]];
			const currentChildForm = childForm[keys[indexKey]] ?? childForm.controls[keys[indexKey]];

			if (currentFormGroup)
				entriesForm(currentFormGroup, currentChildForm, keys, (indexKey + 1))
			else
				formGroup.addControl(keys[indexKey], currentChildForm)
		}

		this.inputs.forEach(e => {
			const keys = e.controlName.split('.');
			let childForm = {};
			for (let i = keys.length; i > 0; i--) {
				const key = keys[i - 1];
				childForm = (i == keys.length) ? { [key]: e.control } : { [key]: this.formBuilder.group(childForm) };
			}
			entriesForm(this.formGroup, childForm, keys)
		})

	}

	// markAsTouchedControls(formGroup: FormGroup) {
	// 	<any>Object.entries(formGroup.controls)
	// 		.forEach(([key, value]) => {
	// 			value.markAsTouched()
	// 			if (value['controls'])
	// 				this.markAsTouchedControls(value as FormGroup)
	// 		})
	// }

	async _submit() {
		// if (!this.formGroup.valid) {
		// 	this.markAsTouchedControls(this.formGroup);
		// 	return;
		// }

		// if (this.showConfirmation) {
		// 	document.getElementById(this.idModalConfirmation).click();
		// 	return;
		// }

		this.submitContinuing()
	}

	submitContinuing = async () => {
		if (this.showLoading) this.loading = true
		await this.submit();
		this.loading = false;
	}

}
