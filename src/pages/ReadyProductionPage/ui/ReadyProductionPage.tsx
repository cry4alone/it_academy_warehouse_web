import {useEffect, useState} from 'react';
import TableReadyProduction from './table/TableReadyProduction';
import { ReadyProvider } from './Context';
import Buttons from './buttons/Buttons';
import { useDefaultPropsContext } from './Context';
import {Item} from "./table/TableReadyProduction"
import Filters from "./filters/Filters.tsx";


export const ReadyProductionPage = () => {
    return (
        <ReadyProvider>
            <Filters/>
            <TableReadyProduction />
            <Buttons />
        </ReadyProvider>
    );
}

