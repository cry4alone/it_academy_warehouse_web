import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';
import './Sidebar.scss';
import Arrow from '../../shared/assets/Arrow.svg';
import { HomeOutlined, FileOutlined, ExceptionOutlined, FileDoneOutlined, MenuOutlined } from '@ant-design/icons';

function Sidebar() {
    const [isDocumentsOpen, setIsDocumentsOpen] = useState(false); // Состояние для отображения подменю
    const [isMenuCollapsed, setIsMenuCollapsed] = useState(false); // Состояние для отображения меню


    const toggleDocumentsMenu = () => {
        setIsDocumentsOpen((prevState) => !prevState); // Переключаем состояние подменю
    };

    const toggleMenuCollapsed = () => {
        setIsMenuCollapsed((prevState) => !prevState);
    }

    return (
        <aside className={`sidebar ${isMenuCollapsed ? "collapsed" : ""}`}>
            <nav>
                <ul className='menu'>

                    <li>
                        <button className='menu__button' onClick={toggleMenuCollapsed}><MenuOutlined /></button>
                    </li>

                    {/* Главная */}
                    <li>
                        <NavLink to='/home' className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
                            <HomeOutlined className='icon' /> 
                            <span>  Главная</span>
                        </NavLink>
                    </li>

                    {/* Незавершённое производство */}
                    <li>
                        <NavLink to='/nzp' className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
                            <ExceptionOutlined className='icon' />
                            <span>Незавершённое производство (НЗП)</span>
                        </NavLink>
                    </li>

                    {/* Готовая продукция */}
                    <li>
                        <NavLink to='/gp' className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
                            <FileDoneOutlined className='icon' />
                            <span>Готовая продукция (ГП)</span>
                        </NavLink>
                    </li>

                    {/* Документы */}
                    <li>
                        <div
                            className='nav-link' 
                            onClick={toggleDocumentsMenu} // Обработчик клика для переключения подменю
                        >
                            <div className='div__documents'>
                                <FileOutlined className='icon' />
                                <span>Документы</span>
                                <img
                                    src={Arrow}
                                    className={`arrow-icon ${isDocumentsOpen ? 'rotated' : ''}`}
                                    alt='Arrow'
                                />
                            </div>
                        </div>
                        {isDocumentsOpen && (
                            <ul className={`submenu ${isMenuCollapsed ? "collapsed-submenu" : ""}`}>
                                <li>
                                    <NavLink
                                        to='/documents/transfers'
                                        className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}
                                    >
                                        Накладные передачи
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to='/documents/inventory'
                                        className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}
                                    >
                                        Инвентаризация
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to='/documents/certificates'
                                        className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}
                                    >
                                        Сертификаты
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to='/documents/shipment'
                                        className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}
                                    >
                                        Отгрузка
                                    </NavLink>
                                </li>
                            </ul>
                        )}
                    </li>
                </ul>
            </nav>
        </aside>
    );
}

export default Sidebar;
