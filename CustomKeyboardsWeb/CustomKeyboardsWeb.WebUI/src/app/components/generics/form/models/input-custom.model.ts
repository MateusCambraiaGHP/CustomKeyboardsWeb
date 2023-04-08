import { FormGroup, FormControl } from '@angular/forms';
import { InputType } from '../enums/input-type.enum';

export interface InputCustom {
	label?: string,
	icon?: string,
	placeholder?: string,
	class?: string,
	type?: InputType,
	rows?: number
	optionValueKey?: string,
	optionTextKey?: string,
	optionsSelect?: any[],
	control: FormControl | FormGroup,
	onChangeFn?: Function
	disabled?: boolean
}