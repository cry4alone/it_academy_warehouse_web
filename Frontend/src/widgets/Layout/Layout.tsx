import React from 'react';
import { Header } from '../Header/Header';
import { Sidebar } from '../Sidebar/Sidebar';
import './layout.scss';
import { Outlet } from 'react-router-dom';

export const Layout = () => {
    return (
        <div className='layout'>
            <Header />
            <div className='layout-content'>
                <Sidebar />
                <main className='layout-main'>
                    <Outlet />
                </main>
            </div>
        </div>
    );
};
