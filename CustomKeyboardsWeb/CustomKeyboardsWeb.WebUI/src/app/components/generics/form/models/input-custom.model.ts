import { FormGroup, FormControl } from '@angular/forms';
import { InputType } from '../enums/input-type.enum';

export interface InputCustom {
    label?: string,
    icon?: string,
    placeholder?: string,
    controlName?: string,
    class?: string,
    info?: string,
    type?: InputType,
    rows?: number
    optionValueKey?: string,
    optionTextKey?: string,
    optionsSelect?: {
        titleSelect?: string,
        options?: { value?: any, text?: string }[]
    }[],
    control?: FormControl | FormGroup,
    onChangeFn?: Function
}