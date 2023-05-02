import * as qs from "qs";
import { Customer } from "../components/customer/models/customer.model";
import { get, put, post, del } from "./methods";

export const CustomKeyboardApi = {
    Customer: {
        getAll: () => get<Customer[]>(`/cliente/getall`),
        getById: (id: number) => get<Customer[]>(`/cliente/getbyid/${id}`),
        deleteCustomerById: (id: string) =>
            del<boolean>(
                `/cliente/DeletarProduto?${qs.stringify({ id })}`
            ),
        updateCustomer: (body: Customer) =>
            put<boolean>(`/cliente/update`, { body }),
        createCustomer: (body: Customer) =>
            post<Customer>(`/cliente/save`, { body }),
    },
};
