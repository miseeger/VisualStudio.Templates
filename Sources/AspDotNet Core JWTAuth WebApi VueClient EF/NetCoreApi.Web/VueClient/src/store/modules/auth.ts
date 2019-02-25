// https://codeburst.io/vuex-and-typescript-3427ba78cfa8

import { IToken } from '../../interfaces/IToken';
import { IAuthState } from '../../interfaces/IAuthState';
import { ILoginPayload } from '@/interfaces/ILoginPayLoad';
import { IRegisterPayload } from '@/interfaces/IRegisterPayload';
import Axios from 'axios';

export const state: IAuthState = {
    auth: null,
    showAuthModal: false,
    loading: false,
};

export const mutations = {
    SHOW_AUTH_MODAL: (state: IAuthState) => state.showAuthModal = true,

    HIDE_AUTH_MODAL: (state: IAuthState) => state.showAuthModal = false,

    REQUEST_LOGIN: (state: IAuthState) => state.loading = true,

    LOGIN_ERROR: (state: IAuthState) => state.loading = false,

    REGISTER_REQUEST: (state: IAuthState) => state.loading = true,

    REGISTER_REQUEST_SUCCESS: (state: IAuthState) => state.loading = false,

    REGISTER_ERROR: (state: IAuthState) => state.loading = false,

    LOGOUT: (state: IAuthState) => state.auth = null,

    LOGIN_SUCCESS: (state: IAuthState, payload: IToken) => {
        state.auth = payload;
        state.loading = false;
    },
};

export const getters = {
    isAuthenticated: (state: IAuthState) => {
        return (
            state.auth !== null &&
            state.auth.access_token !== null &&
            new Date(state.auth.access_token_expiration) > new Date()
        );
    },
};

// https://medium.com/front-end-weekly/typescript-error-ts7031-makes-me-go-huh-c81cf76c829b
// https://stackoverflow.com/questions/41911603/typesrcript-typing-key-string-any
// https://basarat.gitbooks.io/typescript/content/docs/destructuring.html

export const actions = {
    login: ({ commit }: { [key: string]: any }, payload: ILoginPayload) =>
        new Promise((resolve, reject) => {
            commit('LOGIN_REQUEST');
            Axios
                .post('api/token', payload)
                .then((response) => {
                    const authToken: IToken = response.data;
                    Axios.defaults.headers.common["Authorization"] = `Bearer ${authToken.access_token}`;
                    commit('LOGIN_SUCCESS', authToken);
                    commit('HIDE_AUTH_MODAL');
                    resolve(response);
                })
                .catch((error) => {
                    commit('LOGIN_ERROR');
                    delete Axios.defaults.headers.common["Authorization"];
                    reject(error.response);
                });
        }),

    register: ({ commit }: { [key: string]: any }, payload: IRegisterPayload) => 
        new Promise((resolve, reject) => {
            commit('REGISTER_REQUEST');
            Axios
                .post('api/account', payload)
                .then(response => {
                    commit('REGISTER_SUCCESS');
                    resolve(response);
                })
                .catch(error => {
                    commit('REGISTER_ERROR');
                    reject(error.response);
                });
        }),
    
    logout: ({ commit }: { [key: string]: any }) => {
        commit('LOGOUT');
        delete Axios.defaults.headers.common["Authorization"];
    }
};
