import { Component, Input } from '@angular/core';
import { InputCustom } from '../models/input-custom.model';
import { InputType } from '../enums/input-type.enum';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputComponent {

    @Input()
    inputCustom!: InputCustom;
    InputType = InputType;
    formControl = new FormControl;

    getValueOptionSelect(option: any) {
		return  option
	}

	getTextOptionSelect(option: any) {
		return option
	}
}
