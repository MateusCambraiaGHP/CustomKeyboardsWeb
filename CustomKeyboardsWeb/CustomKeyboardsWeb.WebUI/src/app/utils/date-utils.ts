/**
 * @description
 * Transforms the date to local format
 */
export const convertToLocalDate = (value: string) =>
	value ? new Date(value.replace('Z', '')).toLocaleDateString() : null

/**
 * @description
 * Transforms the date and hour to local format
 */
export const convertToLocalDateTime = (value: string) =>
	value ? new Date(value.replace('Z', '')).toLocaleString() : null