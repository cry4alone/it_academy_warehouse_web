import React from 'react';
import TableShipment from "./components/table/TableShipment";
import Buttons from './components/buttons/Buttons';
import '@app/styles/global.scss';
import { ShipmentProvider } from './Context';


function Shipment() {

    return (
        <ShipmentProvider>
            <div className="tab__title">Документы | Отгрузка</div>
            <TableShipment  />
            <Buttons />
        </ShipmentProvider>
    )
}

export default Shipment;