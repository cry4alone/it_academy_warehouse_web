import React, { useContext } from 'react';
import TableReadyProduction from '../components/table/TableReadyProduction';
import { Button } from 'antd';
import { ButtonContext } from '../contexts/ButtonContext';
import '../styles/global.scss';

function ReadyProduction() {
const { showAdditionalButtons } = useContext(ButtonContext);

return (
    <>
    <div className="tab__title">Готовое производство</div>
    <TableReadyProduction />
    <div className="button-container">
        {!showAdditionalButtons && (
        <>
            <Button>Перераспределить сертификат</Button>
            <Button>Возврат продукции</Button>
            <Button>Работа с сертификатами</Button>
            <Button>Печать этикеток</Button>
        </>
        )}
        {showAdditionalButtons && (
        <>
            <Button>Отмена</Button>
            <Button type="primary">Добавить пакеты</Button>
        </>
        )}
    </div>
    </>
);
}

export default ReadyProduction;