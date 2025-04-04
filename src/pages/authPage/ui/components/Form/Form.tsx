import React, { useState } from 'react';
import { Form } from 'antd';
import { useNavigate, useLocation } from 'react-router-dom';
import { useAuth } from '@/contexts/Context';
import '@/pages/authPage/ui/style.scss';
import { fetchUsers } from '@/pages/authPage/api/fetchUsers';
import Inputs from '../inputs/Inputs';
import BtnSubmit from '../button/btnSubmit/BtnSubmit';

const AuthForm: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [passwordError, setPasswordError] = useState(false);
    const { setUser } = useAuth();
    const navigate = useNavigate();
    const location = useLocation();

    const from = location.state?.from || '/home';

    const handleSubmit = async () => {
        setError('');
        setPasswordError(false);

        if (password.length < 8) {
            setPasswordError(true);
            setError('Пароль должен содержать не менее 8 символов.');
            return;
        }

        try {
            const users = await fetchUsers(username);

            console.log('API Response:', users);

            if (!users || users.length === 0) {
                setError('Пользователь с таким логином не найден.');
                return;
            }

            const user = users[0];

            if (user.password !== password) {
                setError('Неверный пароль.');
                return;
            }

            setUser(user);
            console.log('User set in context:', user);
            navigate(from, { replace: true });
        } catch (error) {
            console.error('Ошибка при авторизации:', error);
            setError('Ошибка при авторизации. Попробуйте позже.');
        }
    };

    return (
        <div className='auth-page'>
            <Form className='auth-form' onFinish={handleSubmit}>
                <h1>Авторизация</h1>
                <Inputs
                    username={username}
                    setUsername={setUsername}
                    password={password}
                    setPassword={setPassword}
                    passwordError={passwordError}
                />
                {error && <p className='error-message'>{error}</p>}
                <BtnSubmit />
            </Form>
        </div>
    );
};

export default AuthForm;
