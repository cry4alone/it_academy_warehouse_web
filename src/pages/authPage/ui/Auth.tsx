import React from 'react';
import { AuthProvider } from '@/contexts/AuthContext';
import AuthForm from './components/Form/Form';

const Auth = () => {
    return (
        <AuthProvider>
            <AuthForm />
        </AuthProvider>
    );
};

export default Auth;
