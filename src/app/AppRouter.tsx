import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom'; // Используем BrowserRouter
import Layout from '@widgets/layout/Layout';
import Auth from '@/pages/authPage/ui/Auth';
import NotFoundPage from '@/pages/notFoundPage/NotFoundPage';
import ReadyProduction from '@/pages/readyProductionPage/ui/ReadyProduction';
import Certificates from '@/pages/certificatesPage/ui/Certificates';
import Shipment from '@/pages/shipmentPage/ui/Shipment';
import Invoice from '@/pages/invoicePage/ui/Invoice';
import Main from '@/pages/mainPage/MainPage';
import CreateCertificate from '@pages/workInProgressPage/createCertificatePage/CreateCertificate';
import Print from '@pages/printPage/ui/Print';
import PrivateRouter from './PrivateRouter';
import WorkInProgress from '@/pages/workInProgressPage/WorkInProgress';
export const AppRouter = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<Layout />}>
                    <Route index element={<Auth />} />
                    <Route path='auth' element={<Auth />} />
                    <Route element={<PrivateRouter />}>
                        <Route path='home' element={<Main />} />
                        <Route path='nzp' element={<WorkInProgress />} />
                        <Route path='nzp/create-certificate' element={<CreateCertificate />} />
                        <Route path='gp' element={<ReadyProduction />} />
                        <Route path='/documents/certificates' element={<Certificates />} />
                        <Route path='/documents/shipment' element={<Shipment />} />
                        <Route path='/documents/transfers' element={<Invoice />} />
                        <Route path='print' element={<Print />} />
                        <Route path='*' element={<NotFoundPage />} />
                    </Route>
                </Route>
            </Routes>
        </BrowserRouter>
    );
};

