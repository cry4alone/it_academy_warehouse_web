import React, { useState } from 'react';
import PrimaryButton from '../components/primarybutton/PrimaryButton';
import Input from '../components/Input';
import users from '../data/users';
import { useNavigate } from 'react-router-dom';
import '../styles/global.scss';

const Auth = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [passwordError, setPasswordError] = useState(false);
  const navigate = useNavigate();

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
      navigate('/ready-production');
    } else {
      setError('Неверный логин или пароль.');
    }
  };

  return (
    <div className="auth-page">
      <form className="auth-form" onSubmit={handleSubmit}>
        <h1>Авторизация</h1>
        <div className="input-field">
          <Input
            placeholder="Логин"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
        </div>
        <div className="input-field">
          <Input
            type="password"
            placeholder="Пароль"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            style={{ borderColor: passwordError ? 'red' : '' }}
          />
        </div>
        {error && <p className="error-message">{error}</p>}
        <PrimaryButton type="submit" onClick={handleSubmit}>Войти</PrimaryButton>
      </form>
    </div>
  );
};

export default Auth;
