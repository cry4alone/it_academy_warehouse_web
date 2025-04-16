import React, { createContext, useState, useContext, ReactNode, useEffect } from 'react';
import { IUserData } from '@/pages/AuthPage/types/usersTypes';

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
    // Инициализация состояния user из localStorage
    // const [user, setUser] = useState<IUserData | null>(() => {
    //     try {
    //         const storedUser = localStorage.getItem('authUser');
    //         return storedUser ? JSON.parse(storedUser) : null;
    //     } catch (error) {
    //         console.error('Ошибка при чтении данных пользователя из localStorage:', error);
    //         return null;
    //     }
    // });
    const [user, setUser] = useState<IUserData | null>({} as IUserData);
    // Обновление localStorage при изменении user
    useEffect(() => {
        console.log('Updating localStorage with user:', user);
        localStorage.setItem('authUser', JSON.stringify(user));
    }, [user]);

    return (
        <AuthContext.Provider value={{ user, setUser }}>
            {children}
        </AuthContext.Provider>
    );
};