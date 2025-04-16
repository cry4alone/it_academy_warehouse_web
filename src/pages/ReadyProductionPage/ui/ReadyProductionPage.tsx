import React from 'react';
import TableReadyProduction from './table/TableReadyProduction';
import { ReadyProvider } from './Context';
import Buttons from './buttons/Buttons';

export const ReadyProductionPage = () => {
    return (
        <ReadyProvider>
            <div className='tab__title'>Готовое производство</div>
            <TableReadyProduction />
            <Buttons />
        </ReadyProvider>
    );
}

