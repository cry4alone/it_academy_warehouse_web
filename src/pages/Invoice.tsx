import React from 'react';
import TableInvoice from "../components/table/documents/TableInvoice";
import { Button } from 'antd';
import '../app/styles/global.scss';

function Invoice() {
    
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