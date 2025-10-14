import React from 'react';
import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import User from '@shared/assets/User.svg';
import './style.scss';
import { useAuth } from '@/app/contexts/AuthContext';

export const MainPage = () => {
    const navigate = useNavigate();
    const { user } = useAuth();
    //добавить кнопку авторизации
    return (
        <div className='main-page'>
            <div className='main-form'>
                <img src={User} alt='User Logo' />
                <h1>Здравствуйте, {user?.name || 'Гость'}!</h1>
                {user ? (
                    <p>Выберите необходимый пункт меню слева.</p>
                ) : (
                    <Button
                        type='primary'
                        onClick={() => {
                            navigate('/auth');
                        }}
                    >
                        Авторизация
                    </Button>
                )}
            </div>
        </div>
    );
};
