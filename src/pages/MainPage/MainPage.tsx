import React from 'react';
import User from '@shared/assets/User.svg';
import './style.scss';
import { useAuth } from '@/app/contexts/AuthContext';

export const MainPage = () => {
    const { user } = useAuth();
    console.log('User in Main:', user);
    //добавить кнопку авторизации
    return (
        <div className='main-page'>
            <div className='main-form'>
                <img src={User} alt='User Logo' />
                <h1>Здравствуйте, {user?.name || 'Гость'}!</h1>
                {
                    user ? <p>Авторизуйтесь </p> : <p>Выберите необходимый пункт меню слева.</p>
                }
            </div>
        </div>
    );
};

