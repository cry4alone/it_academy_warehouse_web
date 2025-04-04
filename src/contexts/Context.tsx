import React, { createContext, useState, useContext, ReactNode, useEffect } from 'react';
import { IUserData } from '@/pages/authPage/types/usersTypes';

interface AuthContextType {
    user: IUserData | null;
    setUser: (user: IUserData | null) => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error('useAuth must be used within an AuthProvider');
    }
    return context;
};

export const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    const [user, setUser] = useState<IUserData | null>(() => {
        const storedUser = localStorage.getItem('authUser');
        return storedUser ? JSON.parse(storedUser) : null;
    });

    useEffect(() => {
        if (user) {
            localStorage.setItem('authUser', JSON.stringify(user));
        } else {
            localStorage.removeItem('authUser');
        }
    }, [user]);

    return <AuthContext.Provider value={{ user, setUser }}>{children}</AuthContext.Provider>;
};
