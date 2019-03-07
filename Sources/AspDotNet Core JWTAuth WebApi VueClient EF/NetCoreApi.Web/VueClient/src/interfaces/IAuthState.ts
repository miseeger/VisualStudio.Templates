import { IToken } from './IToken';

export interface IAuthState {
    auth: IToken | null;
    showAuthModal: boolean;
    showPasswordResetModal: boolean;
    showForgotPasswordModal: boolean;
    loading: boolean;
}
