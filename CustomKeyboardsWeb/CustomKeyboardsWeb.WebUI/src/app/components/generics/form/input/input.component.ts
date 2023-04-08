import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { InputType } from '../enums/input-type.enum';
import { FormComponent } from '../form.component';
import { InputCustom } from '../models/input-custom.model';


@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputComponent {
 @Input()
  id!: string;
 @Input()
  inputCustom!: InputCustom;

 InputType = InputType;
 disableAfterSelecting: boolean = false;

 formControl = new FormControl;
 formbuilder = new FormBuilder;
 parentForm = new FormComponent(this.formbuilder);

 ngOnInit(): void {
  this.bindInputForm();
  if (this.inputCustom.type == InputType.date)
    this.formControl.setValue(this.formControl.value?.split('T')[0])

  if (this.formControl.value !== '')
    setTimeout(() => this.formControl.markAsTouched());
}

bindInputForm() {
  const keys = this.inputCustom.controlName.split('.');
  let controls = this.parentForm['formGroup'].controls as any;
  keys.forEach(e => controls = controls[e].controls ?? controls[e])
  this.formControl = controls as FormControl;
}

getErrorMessage() {
  if (this.formControl.hasError('required'))
    return 'Campo obrigatório';

  if (this.formControl.hasError('email'))
    return 'Email inválido';

}

isTextField = () => {
  switch (this.inputCustom.type) {
    case undefined:
    case InputType.text:
    case InputType.password:
    case InputType.date:
    case InputType.number:
      return true
    default:
      return false
  }
}

getValueOptionSelect(option: any) {
  return option[this.inputCustom.optionValueKey ?? option] 
}

getTextOptionSelect(option: any) {
  return option[this.inputCustom.optionTextKey ?? option] 
}

onChangeSelect(selectedValue: string) {
  if (this.inputCustom.disableAfterSelecting)
    this.disableAfterSelecting = true

  const selectedObject = this.inputCustom.optionsSelect?.find(e =>
    e["this.inputCustom.optionValueKey"].toString() === selectedValue.toString())

  if (this.inputCustom.onChangeFn)
    this.inputCustom.onChangeFn(selectedValue, selectedObject)
}
/* / SELECT */

onChangeValueInput(value: any) {
  if (this.inputCustom.onChangeFn)
    this.inputCustom.onChangeFn(value);
}

get isErrorValidate() {
  return this.formControl.invalid && this.formControl.touched
}
}
