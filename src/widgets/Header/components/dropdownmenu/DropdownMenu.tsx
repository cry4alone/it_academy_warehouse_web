// UserMenu.js
import React from 'react';
import { Dropdown, Menu, Button } from 'antd';
import { FaRegUser } from 'react-icons/fa';
import { useAuth } from '../../../../app/contexts/AuthContext';
import { useNavigate } from 'react-router-dom';
import './dropdownmenu.scss';

const UserMenu = () => {
    const { user, setUser } = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => {
        setUser(null);
        navigate('/auth');
    };

    const items = [
        {
            key: 'main',
            label: 'Главная',
            onClick: () => {
                navigate('/home');
            },
        },
        {
            key: 'logout',
            label: 'Выйти',
            onClick: handleLogout,
        },
    ];

    return (
        <div className='user-menu'>
            {user && (
                <Dropdown menu={{ items }} trigger={['click']}>
                    <Button icon={<FaRegUser />} />
                </Dropdown>
            )}
        </div>
    );
};

export default UserMenu;
