import React, { useContext } from 'react';
import TableInvoice from "../components/table/documents/TableInvoice";
import { Button } from 'antd';
import { ButtonContext } from '../contexts/ButtonContext';
import '../styles/global.scss';

function Invoice() {
    const { showAdditionalButtons } = useContext(ButtonContext);
    
    return (
        <>
            <div className="tab__title">Документы | Накладная возврата</div>
            <TableInvoice />
            <div className="button-container">
                <Button>Отмена</Button>
                <Button>Подписать</Button>
                <Button type="primary">Сохранить</Button>
            </div>
        </>
    )
}

export default Invoice;