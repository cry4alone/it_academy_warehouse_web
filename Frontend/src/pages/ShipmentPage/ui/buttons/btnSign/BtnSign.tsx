import React from 'react';
import { Button } from 'antd';
import { notification } from 'antd';
import { useSelectedDataContext } from '../../Context';
import { signShipment } from '../../../api/signShipment'; 

const BtnSign = () => {
    const selectedData = useSelectedDataContext();

    const handleSign = async () => {
        if (!selectedData || selectedData.length === 0) {
            notification.error({
                message: 'Ошибка',
                description: 'Выберите документы для подписи',
            });
            return;
        }

        try {
            for (const item of selectedData) {
                const success = await signShipment(item);
                if (success) {
                    notification.success({
                        message: 'Успех',
                        description: `Документ с ID ${item.id} успешно подписан.`,
                    });
                } else {
                    notification.error({
                        message: 'Ошибка',
                        description: `Не удалось подписать документ с ID ${item.id}.`,
                    });
                }
            }
        } catch (error) {
            console.log(error);
            notification.error({
                message: 'Ошибка',
                description: 'Произошла ошибка при подписании документов.',
            });
        }
    };

    return <Button type="primary" onClick={handleSign} disabled={selectedData.length === 0}>Подписать</Button>;
};

export default BtnSign;