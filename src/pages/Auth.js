import React, { useState, useEffect } from 'react';
import { Button, Input } from 'antd';
import { useNavigate } from 'react-router-dom';
import '../styles/global.scss';

const Auth = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [passwordError, setPasswordError] = useState(false);
  const [users, setUsers] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await fetch('http://localhost:3000/users');
        if (!response.ok) {
          throw new Error('Ошибка!');
        }
        const data = await response.json();
        setUsers(data);
      } catch (error) {
        console.error('Error fetch user:', error);
      }
    };

    fetchUsers();
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    setError('');
    setPasswordError(false);

    if (password.length < 8) {
      setPasswordError(true);
      setError('Пароль должен содержать не менее 8 символов.');
      return;
    }

    const user = users.find(u => u.username === username && u.password === password);
    if (user) {
      localStorage.setItem('authUser', JSON.stringify(user));
      navigate('/ReadyProduction');
    } else {
      setError('Неверный логин или пароль.');
    }
  };

  return (
    <div className="auth-page">
      <form className="auth-form" onSubmit={handleSubmit}>
        <h1>Авторизация</h1>
        <p>Логин</p>
        <div className="input-field">
          <Input
            placeholder="Введите логин"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
        </div>
        <p>Пароль</p>
        <div className="input-field">
          <Input.Password
            placeholder="Введите пароль"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            style={{ borderColor: passwordError ? 'red' : '' }}
          />
        </div>
        {error && <p className="error-message">{error}</p>}
        <Button type="primary" htmlType="submit">Войти</Button>
      </form>
    </div>
  );
};

export default Auth;
