import React from 'react';
import TableShipment from "./table/TableShipment";
import Buttons from './buttons/Buttons';
import '@app/styles/global.scss';
import { ShipmentProvider } from './Context';


export const ShipmentPage = () => {

    return (
        <ShipmentProvider>
            <div className="tab__title">Документы / Отгрузка</div>
            <TableShipment  />
            <Buttons />
        </ShipmentProvider>
    )
}
