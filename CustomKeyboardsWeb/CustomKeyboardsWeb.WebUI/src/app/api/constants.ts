import { environment } from "src/environments/environment.prod";
import { HeadersRequest } from "./models/headers-request.model";

export const API_URL = environment.apiUrl;
export const HEADERS: HeadersRequest = {
    "Access-Control-Allow-Origin": "*",
    "Access-Control-Allow-Headers": "Origin, X-Requested-With, Content-Type, Accept",
    "Content-Type": "application/json",
};
