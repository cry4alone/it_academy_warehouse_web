import PrimaryButton from '@widgets/primarybutton/PrimaryButton';
import Input from './components/input/Input';
import { useNavigate, useLocation } from 'react-router-dom';
import "./style.scss";
import { useAuth } from '@contexts/Context';
import React, { useState } from 'react';
import axios from 'axios';

interface User {
    id: string;
    username: string;
    password: string;
    surname: string;
    name: string;
}

const Auth = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [passwordError, setPasswordError] = useState(false);
    const { setUser } = useAuth();
    const navigate = useNavigate();
    const location = useLocation();

    const from = location.state?.from || '/home';

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError('');
        setPasswordError(false);

        if (password.length < 8) {
            setPasswordError(true);
            setError('Пароль должен содержать не менее 8 символов.');
            return;
        }

        try {
            const response = await axios.get<User[]>('http://localhost:3000/users', {
                params: { username },
            });

            const user = response.data[0];
            if (user && user.password === password) {
                localStorage.setItem('authUser', JSON.stringify(user));
                setUser(user);
                navigate(from, { replace: true });
            } else {
                setError('Неверный логин или пароль.');
            }
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <div className='auth-page'>
            <form className='auth-form' onSubmit={handleSubmit}>
                <h1>Авторизация</h1>
                <p>Логин</p>
                <div className='input-field'>
                    <Input
                        placeholder='Введите логин'
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                </div>
                <p>Пароль</p>
                <div className='input-field'>
                    <Input
                        type='password'
                        placeholder='Введите пароль'
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                        style={{ borderColor: passwordError ? 'red' : '' }}
                    />
                </div>
                {error && <p className='error-message'>{error}</p>}
                <PrimaryButton type='submit'>Войти</PrimaryButton>
            </form>
        </div>
    );
};

export default Auth;
