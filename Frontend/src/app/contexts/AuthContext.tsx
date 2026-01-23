import React, { createContext, useState, useContext, useEffect } from 'react';

interface User {
    id?: string;
    username: string;
    password: string;
    name: string;
    surname: string;
}

interface AuthContextType {
    user: User | null;
    setUser: React.Dispatch<React.SetStateAction<User | null>>;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
    const [user, setUser] = useState<User | null>(null);
    const [isInitialized, setIsInitialized] = useState(false);

    useEffect(() => {
        const storedUser = localStorage.getItem('user');
        if (storedUser) {
            try {
                setUser(JSON.parse(storedUser));
            } catch (error) {
                console.error('Ошибка парсинга данных из localStorage', error);
            }
        }
        setIsInitialized(true);
    }, []);

    useEffect(() => {
        if (!isInitialized) return;
        localStorage.setItem('user', JSON.stringify(user));
    }, [user, isInitialized]);

    return (
        <AuthContext.Provider value={{ user, setUser }}>
            {children} 
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
};