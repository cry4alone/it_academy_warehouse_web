import React from 'react';
import { Button, notification } from 'antd';
import { useLocation } from 'react-router-dom';
import { useSelectedDataContext } from '../../../Context';
import { signInvoice } from '../../../../api/signInvoice';

const BtnSign = () => {
    const selectedData = useSelectedDataContext();
    const location = useLocation();
    const selectedItems = location.state?.selectedData || {};

    const handleSign = () => {
        if (selectedData.length === 0) {
            notification.error({
                message: 'Error',
                description: 'Не выбрана накладная для подписи!',
            });
            return;
        }
        if (Object.keys(selectedItems).length === 0) {
            notification.error({
                message: 'Error',
                description: 'Не выбраны позиции для подписи!',
            });
            return;
        }
        signInvoice(selectedData, selectedItems);
        notification.success({
            message: 'Success',
            description: 'Накладная подписана',
        });
    };

    return <Button onClick={handleSign}>Подписать</Button>;
};

export default BtnSign;
