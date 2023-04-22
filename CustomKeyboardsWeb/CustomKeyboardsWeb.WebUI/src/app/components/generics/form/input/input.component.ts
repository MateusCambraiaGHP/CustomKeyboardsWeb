import { Component, Input } from "@angular/core";
import { InputCustom } from "../models/input-custom.model";
import { InputType } from "../enums/input-type.enum";
import { FormControl, FormGroup } from "@angular/forms";
import { BackendErrors } from "src/app/components/customer/models/banck.model.erros";

@Component({
    selector: "app-input",
    templateUrl: "./input.component.html",
    styleUrls: ["./input.component.scss"],
})
export class InputComponent {
    @Input()
    inputCustom!: InputCustom;
    InputType = InputType;
    formControl = new FormControl();
    @Input()
    formGroup!: FormGroup;
    @Input()
    formEnviado!: boolean;
    @Input()
    backendErrors: BackendErrors | undefined;
    @Input() isErro: boolean = false;

    isTextField = () => {
        switch (this.inputCustom.type) {
            case undefined:
            case InputType.text:
            case InputType.password:
            case InputType.date:
            case InputType.number:
                return true;
            default:
                return false;
        }
    };

    definirErrosBackend() {
        for (const controlName in this.formGroup.controls) {
            if (this.formGroup.controls.hasOwnProperty(controlName)) {
                const control = this.formGroup.get(controlName);
                const field = controlName;
                const erro = this.getErrorMessage(field, "");
                if (erro)
                    control?.setErrors({ backendError: erro });
            }
        }
    }

    getErrorMessage(field: any,fieldName: any ): any {

        const key = field.toString();
        if (this.backendErrors && this.backendErrors[key]) {
            return this.backendErrors[key][0];
        }

        if (this.formGroup.get(field)?.hasError("required"))
            return `O ${fieldName} é obrigatório`;

        if (this.formGroup.get(field)?.hasError("email"))
            return "Email inválido";
    }

    validateForm(field: any, isErro: boolean) {
        return (this.formEnviado && !this.formGroup.get(field)?.valid) || this.isErro;
    }
}
