import React, { useState } from 'react';
import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import TableWorkInProgress from './createCertificatePage/components/tables/TableWorkInProgress';
import BtnHandMeasure from './components/buttons/BtnHandMeasure';
import { ITableRow } from './types/workInProgressTypes';

export const WorkInProgressPage = () => {
    const [selectedRows, setSelectedRows] = useState<ITableRow[]>([]);
    const [dataSource, setDataSource] = useState<ITableRow[]>([]);
    const navigate = useNavigate();
    
    const updateDataSource = (updatedRows: ITableRow[]) => {
        setDataSource((prevDataSource) =>
            prevDataSource.map((item) => {
                const updatedItem = updatedRows.find((row) => row.key === item.key);
                return updatedItem ? { ...item, ...updatedItem } : item;
            })
        );
    };

    const handleCreateCertificate = () => {
        navigate('/nzp/create-certificate');
    }

    

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
                <Button type='primary' onClick={handleCreateCertificate}>Создание сертификата</Button>
            </div>
        </>
    );
}
