import {useEffect, useState} from 'react';
import TableReadyProduction from './table/TableReadyProduction';
import { ReadyProvider } from './Context';
import Buttons from './buttons/Buttons';
import { useDefaultPropsContext } from './Context';
import {Item} from "./table/TableReadyProduction"


export const ReadyProductionPage = () => {
    return (
        <ReadyProvider>
            <TableReadyProduction />
            <Buttons />
        </ReadyProvider>
    );
}

