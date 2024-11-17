import React from 'react';
import logo from "../../shared/assets/Rusal.svg";
import accLogo from "../../shared/assets/accLogo.svg";
import "./header.scss";

function Header() {
  return (
    <header className="header">
      <div className="header__logo">
        <img src={logo} alt="Rusal Logo" />
      </div>
      <div className="header__acc">
        <div className="header__accInfo">
          <p>Войдите в систему</p>
          <p>Данные недоступны</p>
        </div>
        <img src={accLogo} className="header__accLogo" alt="Account Logo" />
      </div>
    </header>
  );
}

export default Header;
