import React from 'react';
import CreateCertificate from '@/pages/WorkInProgressPage/createCertificatePage/CreateCertificate';
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
}

export const routes: RouteType[] = [
    { path: '/auth', element: <AuthPage /> },
    { path: '/home', element: <MainPage /> },
    { path: '/nzp', element: <WorkInProgressPage />, isPrivate: true },
    { path: '/nzp/create-certificate', element: <CreateCertificate />, isPrivate: true },
    { path: '/gp', element: <ReadyProductionPage />, isPrivate: true },
    { path: '/documents/certificates', element: <CertificatesPage />, isPrivate: true },
    { path: '/documents/shipment', element: <ShipmentPage />, isPrivate: true },
    { path: '/documents/transfers', element: <InvoicePage />, isPrivate: true },
    { path: '/print', element: <PrintPage />, isPrivate: true },
    { path: '*', element: <NotFoundPage /> },
];