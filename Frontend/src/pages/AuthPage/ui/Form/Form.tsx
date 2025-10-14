import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Form } from 'antd';
import { useNavigate, useLocation } from 'react-router-dom';
import { useAuth } from '@/app/contexts/AuthContext';
import '@/pages/AuthPage/ui/style.scss';
import { fetchUsers } from '@/pages/AuthPage/api/fetchUsers';
import Inputs from '../inputs/Inputs';
import BtnSubmit from '../button/btnSubmit/BtnSubmit';
import { setUserRedux } from '@/app/store/userSlice';

const AuthForm: React.FC = () => {
    const dispatch = useDispatch();
    const userRedux = useSelector((state: any) => state.user.user);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [passwordError, setPasswordError] = useState(false);
    const { setUser, user } = useAuth();
    const navigate = useNavigate();
    const location = useLocation();

    const from = location.state?.from || '/home';

    useEffect(() => {
        if (user != null) {
            navigate(from, { replace: true });
        }
    }, [user]);

    useEffect(() => {
        console.log('User from redux (в useEffect):', userRedux);
    }, [userRedux]);

    const handleSubmit = async () => {
        setError('');
        setPasswordError(false);
        dispatch(setUserRedux({ id: 1, name: 'Иван' }));

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
