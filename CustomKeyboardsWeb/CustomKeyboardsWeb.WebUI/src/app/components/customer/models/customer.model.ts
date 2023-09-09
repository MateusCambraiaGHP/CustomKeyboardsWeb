import { BackendErrors } from "./banck.model.erros"

export interface Customer{
    id: number
    active: string
    name: string
    fantasyName: string
    cep: string
    adress: string
    fedarativeUnit: string
    phone: string
    errors? : BackendErrors
}