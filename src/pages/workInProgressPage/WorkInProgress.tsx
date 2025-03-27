import React, { useState } from 'react';
import { Button } from 'antd';
import TableWorkInProgress from './createCertificatePage/components/tables/TableWorkInProgress';
import '@app/styles/global.scss';
import BtnHandMeasure from './components/buttons/BtnHandMeasure';
import { ITableRow } from './types/workInProgressTypes';

function WorkInProgress() {
    const [selectedRows, setSelectedRows] = useState<ITableRow[]>([]);
    const [dataSource, setDataSource] = useState<ITableRow[]>([]);

    const updateDataSource = (updatedRows: ITableRow[]) => {
        setDataSource((prevDataSource) =>
            prevDataSource.map((item) => {
                const updatedItem = updatedRows.find((row) => row.key === item.key);
                return updatedItem ? { ...item, ...updatedItem } : item;
            })
        );
    };

    return (
        <>
            <div className="tab__title">Незавершённое производство</div>
            <TableWorkInProgress
                onSelectionChange={setSelectedRows}
                dataSource={dataSource} 
            />
            <div className="button-container">
                <BtnHandMeasure
                    selectedRows={selectedRows}
                    onSave={updateDataSource} 
                />
                <Button>Обработка накладных возврата</Button>
                <Button>Создание сертификата</Button>
            </div>
        </>
    );
}

export default WorkInProgress;