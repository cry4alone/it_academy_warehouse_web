import { createSlice } from '@reduxjs/toolkit';

// src/features/auth/model/slice.ts
import { createSlice } from '@reduxjs/toolkit';

interface AuthState {
  user: any | null; // Замените `any` на конкретный тип пользователя, если он есть
}

const initialState: AuthState = {
  user: null,
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setUser: (state, action) => {
      state.user = action.payload;
    },
    clearUser: (state) => {
      state.user = null;
    },
  },
});

export const { setUser, clearUser } = authSlice.actions;
export default authSlice.reducer;