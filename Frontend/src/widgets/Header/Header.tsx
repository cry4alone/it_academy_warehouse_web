import React from 'react';
import { useLocation } from 'react-router-dom';
import logo from '@shared/assets/Rusal.svg';
import './header.scss';
import { useAuth } from '@/app/contexts/AuthContext';
import DropdownMenu from './components/dropdownmenu/DropdownMenu';
import { routes } from '@/app/router.config';

export const Header = () => {
    const { user } = useAuth();
    const location = useLocation();
    return (
        <header className='header'>
            <div className='header__logo'>
                <img src={logo} alt='Rusal Logo' />
            </div>
            <div className='header__breadcrumbs'>
                {routes.find((route) => route.path === location.pathname)?.breadcrumb}
            </div>
            <div className='header__acc'>
                <div className='header__accInfo'>
                    {user ? (
                        <>
                            <p>{`${user.surname || ''} ${user.name || ''}`.trim() || 'Имя не указано'}</p>
                            <p className='header__login'>{user.username || 'Логин не указан'}</p>
                        </>
                    ) : (
                        <>
                            <p>Войдите в систему</p>
                            <p className='header__login'>Данные недоступны</p>
                        </>
                    )}
                </div>
                {user && <DropdownMenu />}
            </div>
        </header>
    );
};
