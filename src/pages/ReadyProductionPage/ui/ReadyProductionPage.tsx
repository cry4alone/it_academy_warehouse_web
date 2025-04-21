import {useEffect, useState} from 'react';
import TableReadyProduction from './table/TableReadyProduction';
import { ReadyProvider } from './Context';
import Buttons from './buttons/Buttons';
import { useDefaultPropsContext } from './Context';
import {Item} from "./table/TableReadyProduction"


export const ReadyProductionPage = () => {
    return (
        <ReadyProvider>
            <div className='tab__title'><p>Готовое производство</p></div>
            <TableReadyProduction />
            <Buttons />
        </ReadyProvider>
    );
}

