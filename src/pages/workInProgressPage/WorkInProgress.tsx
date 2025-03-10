import React from 'react';
import { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Button, notification } from 'antd';
import TableWorkInProgress from './createCertificatePage/components/tables/TableWorkInProgress';
import { ButtonContext } from '../../contexts/ButtonContext';
import '../../app/styles/global.scss';

function WorkInProgress() {
    const { showAdditionalButtons } = useContext(ButtonContext);
    const navigate = useNavigate();
    const [selectedRows, setSelectedRows] = useState([]);

    const handleMeasureProduct = () => {
        if (selectedRows.length > 0) {
            navigate('/handMeasure');
        } else {
            notification.error({
                message: 'Error',
                description: 'Пожалуйста, выберите хотя бы одно поле',
            });
        }
    };

    const handleCancel = () => {
        notification.error({
            message: 'Ошибка',
            description: 'Действие отменено',
        });
    };
    const handleCreateCertificate = () => {
        navigate('create-certificate');
    };

    const handleAddSelectedItems = () => {
        notification.success({
            message: 'Success',
            description: 'Выбранные позиции добавлены',
        });
    };

    return (
        <>
            <div className="tab__title">Незавершённое производство</div>
            <TableWorkInProgress onSelectionChange={setSelectedRows} />
            <div className="button-container">
                {!showAdditionalButtons && (
                    <>
                        <Button onClick={handleMeasureProduct} disabled={selectedRows.length === 0}>Ручное взвешивание</Button>
                        <Button  onClick={handleCancel}>Обработка накладных возврата</Button>
                        <Button onClick={handleCreateCertificate}>Создание сертификата</Button>
                    </>
                )}
                {showAdditionalButtons && (
                    <>
                        <Button >Отмена</Button>
                        <Button type="primary" onClick={handleAddSelectedItems}>Добавить выбранные позиции</Button>
                    </>
                )}
            </div>
        </>
    );
}

export default WorkInProgress;
