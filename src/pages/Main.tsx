import React from 'react';
import User from "@shared/assets/User.svg";
import '@app/styles/global.scss';

const Main = () => {
    return (
        <div className="main-page">
            <form className="main-form">
                <img src={User} alt="User Logo" />
                <h1>Здравствуйте!</h1>
                <p>Выберите необходимый пункт меню слева.</p>
            </form>
        </div>
    );
};

export default Main;
