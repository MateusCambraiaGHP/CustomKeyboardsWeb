import { FormGroup, FormControl } from "@angular/forms";
import { InputType } from "../enums/input-type.enum";

export interface InputCustom {
    label?: string;
    icon?: string;
    placeholder?: string;
    formControlName?: string;
    class?: string;
    info?: string;
    type?: InputType;
    optionValueKey?: string;
    optionTextKey?: string;
    optionsSelect?: {
        titleSelect?: string;
        options?: { value?: any; text?: string }[];
    }[];
    control?: FormControl | FormGroup;
    onChangeFn?: Function;
}
