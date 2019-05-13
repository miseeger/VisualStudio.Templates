import Axios from 'axios';

import { IForgotPasswordPayload } from '@/interfaces/IForgotPasswordPayload';
import { ILoginPayload } from '@/interfaces/ILoginPayLoad';
import { IRegisterPayload } from '@/interfaces/IRegisterPayload';

function setAuthHeader(accessToken: string): void {
    Axios.defaults.headers.common["Authorization"] = `Bearer ${accessToken}`;
}

function deleteAuthHeader(): void {
    delete Axios.defaults.headers.common["Authorization"];
}

async function register(payload: IRegisterPayload) {
    return await Axios.post("api/account/register", payload);
}
async function login(payload: ILoginPayload) {
    return await Axios.post("api/token", payload);
}

async function forgotPassword(payload: IForgotPasswordPayload) {
    return await Axios.post("api/account/forgotpassword", payload);
}

export default { setAuthHeader, deleteAuthHeader, register, login, forgotPassword }

