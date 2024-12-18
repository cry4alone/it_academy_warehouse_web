import PrimaryButton from "../components/primarybutton/PrimaryButton";
import Input from "../components/input/Input";
import users from "../data/users";
import { useNavigate } from "react-router-dom";
import "../styles/global.scss";
import { useAuth } from "../Context";
import React, { useState, useEffect } from 'react';

const Auth = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [passwordError, setPasswordError] = useState(false);
  const [users, setUsers] = useState([]);
  const navigate = useNavigate();
  const { setUser } = useAuth();

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
        console.error('Ошибка fetch пользователя:', error);
      }
    };

    fetchUsers();
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    setError("");
    setPasswordError(false);

    if (password.length < 8) {
      setPasswordError(true);
      setError("Пароль должен содержать не менее 8 символов.");
      return;
    }

    const user = users.find(
      (u) => u.username === username && u.password === password
    );
    if (user) {
      localStorage.setItem("authUser", JSON.stringify(user));
      setUser(user);
      //const { user } = useAuth();
      //console.log(user);
      navigate("/ReadyProduction");
    } else {
      setError("Неверный логин или пароль.");
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
          <Input
            type="password"
            placeholder="Введите пароль"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            style={{ borderColor: passwordError ? "red" : "" }}
          />
        </div>
        {error && <p className="error-message">{error}</p>}
        <PrimaryButton type="submit">Войти</PrimaryButton>
      </form>
    </div>
  );
};

export default Auth;
