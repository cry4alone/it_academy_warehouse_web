import React from 'react';
import TableReadyProduction from './components/table/TableReadyProduction';
import '@app/styles/global.scss';
import { ReadyProvider } from './Context';
import Buttons from './components/buttons/Buttons';

function ReadyProduction() {
    return (
        <ReadyProvider>
            <div className='tab__title'>Готовое производство</div>
            <TableReadyProduction />
            <Buttons />
        </ReadyProvider>
    );
}

export default ReadyProduction;
