import React from 'react';
import logo from '@shared/assets/Rusal.svg';
import './header.scss';
import { useAuth } from '@/contexts/Context';
import DropdownMenu from './components/dropdownmenu/DropdownMenu';

function Header() {
    const { user } = useAuth();
    console.log('User in Header:', user);

    return (
        <header className='header'>
            <div className='header__logo'>
                <img src={logo} alt='Rusal Logo' />
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
}

export default Header;
