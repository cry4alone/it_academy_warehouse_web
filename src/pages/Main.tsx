import React from 'react';
import User from "@shared/assets/User.svg";
import '@app/styles/global.scss';
import { useAuth } from '@/contexts/Context';

const Main = () => {
    const { user } = useAuth();
    return (
        <div className="main-page">
            <form className="main-form">
                <img src={User} alt="User Logo" />
                <h1>Здравствуйте, {user.name}!</h1>
                <p>Выберите необходимый пункт меню слева.</p>
            </form>
        </div>
    );
};

export default Main;
