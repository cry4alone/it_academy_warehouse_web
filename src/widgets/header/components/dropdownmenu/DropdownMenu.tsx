// UserMenu.js
import React from 'react';
import { Dropdown, Menu, Button } from 'antd';
import { FaRegUser } from 'react-icons/fa';
import { useAuth } from '../../../../contexts/Context';
import { useNavigate } from 'react-router-dom';
import './dropdownmenu.scss'; 

const UserMenu = () => {
  const { user, setUser } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    setUser(null);
    navigate('/auth');
  };

  const menu = (
    <Menu>
      <Menu.Item key="logout" onClick={handleLogout}>
        Выйти
      </Menu.Item>
    </Menu>
  );

  return (
    <div className="user-menu">
      {user && (
        <Dropdown overlay={menu} trigger={['click']}>
          <Button icon={<FaRegUser />} />
        </Dropdown>
      )}
    </div>
  );
};

export default UserMenu;
