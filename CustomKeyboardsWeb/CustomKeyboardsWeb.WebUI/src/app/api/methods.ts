import { API_URL, HEADERS } from "./constants";
import { OptionsRequest } from "./models/options-request.model";

export const get = <T>(route: string, options?: OptionsRequest) =>
    baseRequest<T>("GET", route, options);
export const post = <T>(route: string, options?: OptionsRequest) =>
    baseRequest<T>("POST", route, options);
export const put = <T>(route: string, options?: OptionsRequest) =>
    baseRequest<T>("PUT", route, options);
export const del = <T>(route: string, options?: OptionsRequest) =>
    baseRequest<T>("DELETE", route, options);

async function baseRequest<T>(
    method: string,
    route: string,
    options?: OptionsRequest
): Promise<T> {
    const body = JSON.stringify(options?.body);
    try {
        const response = await fetch(
            `${API_URL}${route}`,
            {
                method,
                headers: {
                    'Content-Type': 'application/json'
                },
                mode: 'cors',
                body
            }
        );
        if (response.ok) {
            const json = await response.json();
            return json;
        } else {
            const errorResponse = await response.json();
            // const backendErrors = [];
            // backendErrors.push(...errorResponse.errors);
            return errorResponse;
        }
    } catch (error) {
        console.error('Erro na chamada da API:', error);
        return false as any;
    }
}
