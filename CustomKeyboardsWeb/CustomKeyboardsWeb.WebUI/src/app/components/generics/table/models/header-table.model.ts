import { ElementColumnType } from "../enums/element-column-type";

export interface HeaderTable {
	title: string,
	prop?: string,
	custom?: boolean,
	style?: string,
	minWidth?: string,
	width?: string,
	textAlign?: string,
	maxWidth?: string,
	prefix?: string,
	sufix?: string,
	type?: ElementColumnType,
	textEnum?: Object
	colorEnum?: Object
	booleanText?: { true: string, false: string }
}