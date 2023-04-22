/**
 * @description
 * Turns a value into the real currency
 */
export const convertToReal = (value: string | number) => {
	const newValue = (typeof (value) == 'string') ? parseFloat(value as string) : value;
	return (!value && value != 0) ? null : newValue.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
}