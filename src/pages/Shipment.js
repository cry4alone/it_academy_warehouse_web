import React, { useContext } from 'react';
import TableShipment from "../components/table/documents/TableShipment";
import { Button } from 'antd';
import { ButtonContext } from '../contexts/ButtonContext';
import '../styles/global.scss';

function Shipment() {
    const { showAdditionalButtons } = useContext(ButtonContext);

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