import React from 'react';
import TableInvoice from './components/table/TableInvoice';

import '@app/styles/global.scss';
import { InvoiceProvider } from './Context';
import Buttons from './components/buttons/Buttons';

function Invoice() {
    return (
        <InvoiceProvider>
            <div className='tab__title'>Документы | Накладная возврата</div>
            <TableInvoice />
            <Buttons />
        </InvoiceProvider>
    );
}

export default Invoice;
