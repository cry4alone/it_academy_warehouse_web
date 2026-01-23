import React from 'react';
import { Button, notification } from 'antd';
import { useLocation, useNavigate } from 'react-router-dom';
import { useSelectedDataContext } from '../../Context';
import { signInvoice } from '../../../api/signInvoice';

const BtnSign = () => {
    const selectedData = useSelectedDataContext();
    const location = useLocation();
    const navigate = useNavigate();
    const selectedItems = location.state?.data || {};

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

        navigate('/gp');
    };

    return <Button onClick={handleSign} disabled={selectedData.length === 0}>Подписать</Button>;
};

export default BtnSign;
