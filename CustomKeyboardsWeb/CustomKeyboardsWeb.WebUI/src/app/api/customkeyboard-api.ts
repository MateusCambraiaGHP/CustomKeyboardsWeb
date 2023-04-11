import * as qs from "qs";
import { Customer } from "../components/customer/models/customer.model";
import { get, put, post, del } from "./methods";

export const CustomKeyboardApi = {
    Customer: {
        getAll: () => get<Customer[]>(`/Vitrine/ListaProdutos`),
        deleteCustomerById: (id: string) =>
            del<boolean>(
                `/AdminProdutos/DeletarProduto?${qs.stringify({ id })}`
            ),
        updateCustomer: (body: Customer) =>
            put<boolean>(`/AdminProdutos/AtualizarProduto`, { body }),
        createCustomer: (body: Customer) =>
            post<boolean>(`/AdminProdutos/NovoProduto`, { body }),
    },
};
