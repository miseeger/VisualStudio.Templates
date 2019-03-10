// https://codeburst.io/vuex-and-typescript-3427ba78cfa8

import { IToken } from "../../interfaces/IToken";
import { IAuthState } from "../../interfaces/IAuthState";
import { ILoginPayload } from "@/interfaces/ILoginPayLoad";
import { IRegisterPayload } from "@/interfaces/IRegisterPayload";
import { PlainObject } from "@/typings/PlainObject";

import Axios from "axios";
import { IForgotPasswordPayload } from "@/interfaces/IForgotPasswordPayload";
import { IResetPasswordPayload } from "@/interfaces/IResetPasswordPayload";

export const namespaced = true;

export const state: IAuthState = {
    auth: null,
    showAuthModal: false,
    showForgotPasswordModal: false,
    showPasswordResetModal: false,
    loading: false
};

export const mutations = {
    SHOW_AUTH_MODAL: (state: IAuthState) => (state.showAuthModal = true),

    HIDE_AUTH_MODAL: (state: IAuthState) => (state.showAuthModal = false),

    SHOW_RESET_PASSWORD_MODAL: (state: IAuthState) =>
        (state.showPasswordResetModal = true),

    HIDE_RESET_PASSWORD_MODAL: (state: IAuthState) =>
        (state.showPasswordResetModal = false),

    SHOW_FORGOT_PASSWORD_MODAL: (state: IAuthState) =>
        (state.showForgotPasswordModal = true),

    HIDE_FORGOT_PASSWORD_MODAL: (state: IAuthState) =>
        (state.showForgotPasswordModal = false),

    REQUEST_START: (state: IAuthState) => (state.loading = true),

    REQUEST_SUCCESS: (state: IAuthState) => (state.loading = false),

    REQUEST_ERROR: (state: IAuthState) => (state.loading = false),

    LOGOUT: (state: IAuthState) => (state.auth = null),

    LOGIN_SUCCESS: (state: IAuthState, payload: IToken) => {
        state.auth = payload;
        state.loading = false;
    }
};

export const getters = {
    isAuthenticated: (state: IAuthState) => {
        return (
            state.auth !== null &&
            state.auth.access_token !== null &&
            new Date(state.auth.access_token_expiration) > new Date()
        );
    },
    loggedInUser: (state: IAuthState) => {
        return state.auth === null ? "" : state.auth.userName;
    }
};

// https://medium.com/front-end-weekly/typescript-error-ts7031-makes-me-go-huh-c81cf76c829b
// https://stackoverflow.com/questions/41911603/typesrcript-typing-key-string-any
// https://basarat.gitbooks.io/typescript/content/docs/destructuring.html

export const actions = {
    login: ({ commit }: PlainObject, payload: ILoginPayload) =>
        new Promise((resolve, reject) => {
            commit("REQUEST_START");
            Axios.post("api/token", payload)
                .then(response => {
                    const authToken: IToken = response.data;
                    Axios.defaults.headers.common["Authorization"] = `Bearer ${
                        authToken.access_token
                    }`;
                    commit("LOGIN_SUCCESS", authToken);
                    commit("HIDE_AUTH_MODAL");
                    resolve(response);
                })
                .catch(error => {
                    commit("REQUEST_ERROR");
                    delete Axios.defaults.headers.common["Authorization"];
                    reject(error.response);
                });
        }),

    register: ({ commit }: PlainObject, payload: IRegisterPayload) =>
        new Promise((resolve, reject) => {
            commit("REQUEST_START");
            Axios.post("api/account/register", payload)
                .then(response => {
                    commit("REQUEST_SUCCESS");
                    resolve(response);
                })
                .catch(error => {
                    commit("REQUEST_ERROR");
                    reject(error.response);
                });
        }),

    forgotPassword: ({ commit }: PlainObject, payload: IForgotPasswordPayload) =>
        new Promise((resolve, reject) => {
            commit("REQUEST_START");
            Axios.post("api/account/forgotpassword", payload)
                .then(response => {
                    commit("REQUEST_SUCCESS");
                    resolve(response);
                })
                .catch(error => {
                    commit("REQUEST_ERROR");
                    reject(error.response);
                });
        }),

        resetPassword: ({ commit }: PlainObject, payload: IResetPasswordPayload) =>
            new Promise((resolve, reject) => {
                commit("REQUEST_START");
                Axios.post("api/account/resetpassword", payload)
                    .then(response => {
                        commit("REQUEST_SUCCESS");
                        resolve(response);
                    })
                    .catch(error => {
                        commit("REQUEST_ERROR");
                        reject(error.response);
                    });
            }),        

    logout: ({ commit }: PlainObject) => {
        commit("LOGOUT");
        delete Axios.defaults.headers.common["Authorization"];
    }
};
