import React from 'react';
import InputLogin from './inputLogin/InputLogin';
import InputPassword from './inputPassword/InputPassword';

interface InputsProps {
    username: string;
    setUsername: (value: string) => void;
    password: string;
    setPassword: (value: string) => void;
    passwordError: boolean;
}

const Inputs: React.FC<InputsProps> = ({ username, setUsername, password, setPassword, passwordError }) => {
    return (
        <div>
            <p>Логин</p>
            <InputLogin
                placeholder='Введите логин'
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
            />
            <p>Пароль</p>
            <InputPassword
                placeholder='Введите пароль'
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
                borderColor={passwordError ? 'red' : ''}
            />
        </div>
    );
};

export default Inputs;
