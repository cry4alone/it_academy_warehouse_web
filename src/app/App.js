import React from 'react';

import { BrowserRouter, Routes, Route } from 'react-router-dom'; // Используем BrowserRouter
import Layout from '../widgets/layout/Layout';
import Auth from '../pages/authPage/Auth';
import NotFoundPage from '../pages/NotFoundPage';
import WorkInProgress from '../pages/WorkInProgress';
import ReadyProduction from '../pages/ReadyProduction';
import Certificates from '../pages/Certificates';
import Shipment from '../pages/Shipment';
import Invoice from '../pages/Invoice';
import Main from '../pages/Main';
import PrivateRouter from './PrivateRouter';
import './styles/global.scss';

const App = () => {
    {
        return (
            <BrowserRouter>
                <Routes>
                    <Route path='/' element={<Layout />}>
                        <Route index element={<Auth />} />
                        <Route path='auth' element={<Auth />} />
                        <Route element={<PrivateRouter />}>
                            <Route path='home' element={<Main />} />
                            <Route path='nzp' element={<WorkInProgress />} />
                            <Route path='gp' element={<ReadyProduction />} />
                            <Route path='/documents/certificates' element={<Certificates />} />
                            <Route path='/documents/shipment' element={<Shipment />} />
                            <Route path='/documents/transfers' element={<Invoice />} />
                            <Route path='*' element={<NotFoundPage />} />
                        </Route>
                    </Route>
                </Routes>
            </BrowserRouter>
        );
    }
};

export default App;
