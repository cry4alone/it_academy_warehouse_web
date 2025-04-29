// src/app/store/index.ts
import { configureStore } from '@reduxjs/toolkit';
import rootReducer from './authReducer';

const store = configureStore({
  reducer: rootReducer,
});

export type AppDispatch = typeof store.dispatch;
export default store;