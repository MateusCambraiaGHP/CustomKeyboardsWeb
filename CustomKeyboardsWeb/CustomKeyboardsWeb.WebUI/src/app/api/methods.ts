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
    console.log(body)
    try {
        return await fetch(
            `${API_URL}${route}`,
            Object.assign({ method,    headers: {
                'Content-Type': 'application/json'
            },
            mode: 'cors', } as any, { body } || {})
        )
            .then((r) => {
                if (!r.ok) throw r;
                return r.json();
            })
            .then((json) => {
                return json;
            });
    } catch (error) {
        return false as any;
    }
}
