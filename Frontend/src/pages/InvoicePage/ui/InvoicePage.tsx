import React from 'react';
import TableInvoice from './table/TableInvoice';
import { InvoiceProvider } from './Context';
import Buttons from './buttons/Buttons';

export const InvoicePage = () => {
    return (
        <InvoiceProvider>
            <TableInvoice />
            <Buttons />
        </InvoiceProvider>
    );
}

