import React from 'react';
import TableCertificates from './table/TableCertificates';
import Buttons from './buttons/Buttons';
import { CertificateProvider } from './Context';

export const CertificatesPage = () => {
    return (
        <CertificateProvider>
            <TableCertificates />
            <Buttons />
        </CertificateProvider>
    );
}

