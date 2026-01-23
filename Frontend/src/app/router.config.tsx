import React from 'react';
import { CreateCertificate } from '@/pages/CreateCertificatePage/ui/CreateCertificate';
import { MainPage } from '@/pages/MainPage/MainPage';
import { PrintPage } from '@/pages/PrintPage/';
import { WorkInProgressPage } from '@/pages/WorkInProgressPage';
import { AuthPage } from '@/pages/AuthPage';
import { NotFoundPage } from '@/pages/NotFoundPage';
import { ReadyProductionPage } from '@/pages/ReadyProductionPage';
import { CertificatesPage } from '@/pages/CertificatesPage';
import { ShipmentPage } from '@/pages/ShipmentPage';
import { InvoicePage } from '@/pages/InvoicePage';

interface RouteType {
    path: string;
    element: React.ReactElement;
    isPrivate?: boolean;
    breadcrumb?: string;
}

export const routes: RouteType[] = [
    {
        path: '/auth',
        element: <AuthPage />,
        breadcrumb: 'Авторизация', 
    },
    {
        path: '/home',
        element: <MainPage />,
        breadcrumb: 'Главная',
    },
    {
        path: '/nzp',
        element: <WorkInProgressPage />,
        isPrivate: true,
        breadcrumb: 'НЗП',
    },
    {
        path: '/nzp/create-certificate',
        element: <CreateCertificate />,
        isPrivate: true,
        breadcrumb: 'Создание сертификата',
    },
    {
        path: '/gp',
        element: <ReadyProductionPage />,
        isPrivate: true,
        breadcrumb: 'Готовая продукция',
    },
    {
        path: '/documents/certificates',
        element: <CertificatesPage />,
        isPrivate: true,
        breadcrumb: 'Документы / Сертификаты',
    },
    {
        path: '/documents/shipment',
        element: <ShipmentPage />,
        isPrivate: true,
        breadcrumb: 'Документы / Отгрузка',
    },
    {
        path: '/documents/transfers',
        element: <InvoicePage />,
        isPrivate: true,
        breadcrumb: 'Документы / Перемещения',
    },
    {
        path: '/print',
        element: <PrintPage />,
        isPrivate: true,
        breadcrumb: 'Печать',
    },
    {
        path: '*',
        element: <NotFoundPage />,
        breadcrumb: ' ',
    },
];
