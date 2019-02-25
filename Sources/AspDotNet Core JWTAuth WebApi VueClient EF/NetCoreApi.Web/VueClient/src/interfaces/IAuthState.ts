import { IToken } from './IToken';

export interface IAuthState {
    auth: IToken | null;
    showAuthModal: boolean;
    loading: boolean;
}
