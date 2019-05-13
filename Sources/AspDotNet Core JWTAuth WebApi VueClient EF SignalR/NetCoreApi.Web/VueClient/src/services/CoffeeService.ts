import Axios, {AxiosRequestConfig} from 'axios';
import {HubConnection} from '@aspnet/signalr';

export async function order(product: string, size: string, connection: HubConnection) {

    const options: AxiosRequestConfig = {
        headers: {'content-type': 'application/json'}
    };

    return await Axios.post('/Coffee', {"product": product, "size": size}, options)
}

