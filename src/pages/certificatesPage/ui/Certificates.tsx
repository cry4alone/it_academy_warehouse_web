import React from 'react';
import TableCertificates from '@widgets/tables/TableCertificates';
import Buttons from './components/buttons/Buttons';
import { CertificateProvider } from './Context';

function Certificates() {

    return (
        <CertificateProvider>
            <div className='tab__title'>Документы | Сертификат</div>
            <TableCertificates />
            <Buttons />
        </ CertificateProvider>
    );
}

export default Certificates;
