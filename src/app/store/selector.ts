import { RootState } from './authReducer';

export const selectUser = (state: RootState) => state.auth.user;