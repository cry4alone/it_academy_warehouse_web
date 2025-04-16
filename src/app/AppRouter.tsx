import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from '@widgets/layout/Layout';
import { MainPage } from '@/pages/MainPage/MainPage';
import PrivateRouter from './PrivateRouter';
import { routes } from './router.config';


export const AppRouter = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<Layout />}>
                    <Route index element={<MainPage />}>
                    </Route>
                    {routes.map((route) => {
                        const { path, element, isPrivate } = route;
                        const routeElement = isPrivate ? <PrivateRouter>{element}</PrivateRouter> : element;
                        return <Route key={path} path={path} element={routeElement} />;
                    })}
                </Route>
                <Route />
            </Routes>
        </BrowserRouter>
    );
};
