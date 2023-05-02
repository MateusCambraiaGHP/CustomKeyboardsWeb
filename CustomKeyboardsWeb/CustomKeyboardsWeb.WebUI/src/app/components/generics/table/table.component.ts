import { Component, ContentChild, Input, TemplateRef } from '@angular/core';
import { HeaderTable } from './models/header-table.model';
import { ElementColumnType } from './enums/element-column-type';
import { convertToReal } from 'src/app/utils/string-utils';
import { convertToLocalDate, convertToLocalDateTime } from 'src/app/utils/date-utils';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {
    @ContentChild('customColumn') customColumn!: TemplateRef<any>;
	@Input()
    headers!: HeaderTable[];
	@Input() items!: any[];
	@Input() title!: string;
	@Input() _class!: string;
	@Input() loading: boolean = false;
    @Input()
    typeObject!: string;

	ngOnInit(): void {	}

    constructor(private router: Router) { }

	formatValue(item: Object, headerTable: HeaderTable) {

		let value = this.getValueItem(item, headerTable.prop ?? "");

		if (headerTable.textEnum) value ?? headerTable.textEnum?[value as string] : ''

		switch (headerTable.type) {
			case ElementColumnType.money:
				return convertToReal(value as string)
			case ElementColumnType.date:
				return convertToLocalDate(value as string)
			case ElementColumnType.dateTime:
				return convertToLocalDateTime(value as string)
			case ElementColumnType.boolean:
				return headerTable.booleanText?[value]: ''
			default:
				return value
		}
	}

	valueIsTypeText(headerTable: HeaderTable) {
		if (headerTable.custom) return false

		switch (headerTable.type) {
			case undefined:
			case ElementColumnType.date:
			case ElementColumnType.dateTime:
			case ElementColumnType.money:
			case ElementColumnType.boolean:
				return true
            default:
                return false;
		}
	}

	getValueItem(item: any, prop: string) {
		const keys = prop.split('.');
		if (keys.length === 1){
            return item[prop]
        }
		let child: any;
		keys.forEach(e => child  = child ? child[e] : item[e])
		return child;
	}

    EditItem(idItem: any, item: Object){
        this.router.navigate([`form-${this.typeObject}`], { queryParams: { item: JSON.stringify(item) } })
    }
}
