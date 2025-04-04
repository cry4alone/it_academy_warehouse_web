import React from 'react';
import { AuthProvider } from '@/contexts/Context';
import AuthForm from './components/Form/Form';

const Auth = () => {
    return (
        <AuthProvider>
            <AuthForm />
        </AuthProvider>
    );
};

export default Auth;
