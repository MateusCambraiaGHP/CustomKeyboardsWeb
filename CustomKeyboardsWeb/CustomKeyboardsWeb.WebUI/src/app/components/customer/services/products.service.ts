import { Injectable } from "@angular/core";
import { Customer } from "../models/customer.model";
import { CustomKeyboardApi } from "src/app/api/customkeyboard-api";

@Injectable({
    providedIn: "root",
})
export class CustomerService {
    customers: Customer[] = [];
    loading: boolean = false;

    constructor() {}

    loadProducts = async () => {
        this.loading = true;
        const resp = await CustomKeyboardApi.Customer.getAll();
        if (resp) this.customers = resp;
        this.loading = false;
    };

    create = async (product: Customer) => {
        const resp = await CustomKeyboardApi.Customer.createCustomer(product);
        if (resp) this.loadProducts();
        return resp;
    };

    update = async (product: Customer) => {
        const resp = await CustomKeyboardApi.Customer.updateCustomer(product);
        if (resp) this.loadProducts();
        return resp;
    };

    delete = async (productId: string) => {
        const resp = await CustomKeyboardApi.Customer.deleteCustomerById(
            productId
        );
        if (resp) this.loadProducts();
        return resp;
    };
}
