import { Component } from '@angular/core';
import { HeaderTable } from '../../generics/table/models/header-table.model';
import { CustomerService } from '../services/products.service';

@Component({
  selector: 'app-table-customers',
  templateUrl: './table-customers.component.html',
  styleUrls: ['./table-customers.component.scss']
})
export class TableCustomersComponent {
    loading = true as boolean;
    typeObject = 'customer' as string;

	headers: HeaderTable[] = [
		{ title: 'Nome', prop: "name", width: '80px' },
		{ title: 'Nome Fantasia', prop: "fantasyName", width: '80px', textAlign: 'center' },
		{ title: 'Ativo?', prop: "active",  width: '80px', textAlign: 'center' },
        { title: 'Telefone', prop: "phone", width: '80px', textAlign: 'center' },
        { title: 'Endereço', prop: "adress",  width: '80px', textAlign: 'center' },
	]

	constructor(
		public customersService: CustomerService,
	) {
		customersService.loadProducts()
	}

	ngOnInit(): void { }

	deleteProduct = (productId: string) =>
		async () => {
			const resp = await this.customersService.delete(productId)
		}

	get products() {
		return this.customersService.customers;
	}
}
