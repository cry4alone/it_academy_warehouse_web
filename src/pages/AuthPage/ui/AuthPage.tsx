import React from 'react';
import { AuthProvider } from '@/app/contexts/AuthContext';
import AuthForm from './Form/Form';

export const AuthPage = () => {
    return (
        <AuthProvider>
            <AuthForm />
        </AuthProvider>
    );
};

