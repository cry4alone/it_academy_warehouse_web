import React from 'react';
import { Button, notification } from 'antd';
import { ICertificateData } from "../../../types/certificateTypes.ts";
import { useSelectedDataContext } from "../../Context.tsx";
import {cancelCertificate} from "../../../api/cancelCertificate.ts";

const BtnCancel = () => {
    const SelectedData: ICertificateData[] = useSelectedDataContext();

    const handleCancel = async () => {
        if (!SelectedData || SelectedData.length === 0) {
            notification.error({
                message: 'Ошибка',
                description: 'Выберите документы для отмены подписи', // Исправлено описание
            });
            return;
        }
        console.log('Selected data:', JSON.stringify(SelectedData, null, 2));

        try {
            // Логика отмены подписи будет здесь
            for(const item of SelectedData){
                const success = await cancelCertificate(item.id);
                if (success) {
                    notification.success({
                        message: 'Успех',
                        description: `Подпись сертификата ${item.id} отменена .`,
                    });
                } else {
                    notification.error({
                        message: 'Ошибка',
                        description: `Не удалось отменить подпись сертификата с ID ${item.id}.`,
                    });
                }
            }
            console.log('Отмена подписи для:', SelectedData);
        } catch (error) {
            console.error(error);
            notification.error({
                message: 'Ошибка',
                description: 'Произошла ошибка при отмене подписи документов.',
            });
        }
    };

    return (
        <Button onClick={handleCancel}>Отмена подписи</Button>
    );
};

export default BtnCancel;