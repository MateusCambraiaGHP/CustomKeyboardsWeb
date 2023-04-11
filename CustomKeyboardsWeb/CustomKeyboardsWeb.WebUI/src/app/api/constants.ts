import { environment } from "src/environments/environment.prod";
import { HeadersRequest } from "./models/headers-request.model";

export const API_URL = environment.apiUrl;
export const HEADERS: HeadersRequest = {
    "Content-Type": "application/json",
};
