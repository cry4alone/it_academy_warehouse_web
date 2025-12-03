import React from 'react';
import { Button, notification } from 'antd';
import { useNavigate } from 'react-router-dom';
import { usePrintContext } from '../../Context';

const BtnPrint = () => {
    const { isPrinterAndLabelSelected } = usePrintContext();
    const navigate = useNavigate();
    const handlePrint = () => {
        if (!isPrinterAndLabelSelected) {
            notification.error({
                message: 'Ошибка',
                description: 'Пожалуйста, выберите принтер и этикетку перед печатью.',
            });
            return;
        }

        notification.success({
            message: 'Успех',
            description: 'Этикетки распечатаны',
        });
        navigate('/gp');

    };

    return (
        <Button
            type="primary"
            onClick={handlePrint}
        >
            Распечатать
        </Button>
    );
};

export default BtnPrint;