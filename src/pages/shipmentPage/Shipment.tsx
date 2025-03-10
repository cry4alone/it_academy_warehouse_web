import React from 'react';
import TableShipment from "./components/table/TableShipment";
import { Button } from 'antd';
import '@app/styles/global.scss';

function Shipment() {

    return (
        <>
            <div className="tab__title">Документы | Отгрузка</div>
            <TableShipment  />
            <div className="button-container">
                <Button>Отмена</Button>
                <Button>Подписать</Button>
                <Button type="primary">Сохранить</Button>
            </div>
        </>
    )
}

export default Shipment;