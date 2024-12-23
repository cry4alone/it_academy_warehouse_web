import React from "react";
import logo from "../../shared/assets/Rusal.svg";
import "./header.scss";
import { FaRegUser } from "react-icons/fa";

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
        <FaRegUser />
      </div>
    </header>
  );
}

export default Header;
