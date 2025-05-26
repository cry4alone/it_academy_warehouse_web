import React, { useState } from 'react';
import { Button, notification } from 'antd';
import { useSelectedDataContext } from '../../Context';
import HandReverseModal from "./HandReverseModal.tsx";

const BtnReverse = () => {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const selectedData = useSelectedDataContext(); // Получаем выбранные данные из контекста

    const handleCancel = () => {
        setIsModalVisible(false);
    };

    const handleOpenModal = () => {
        // Проверяем, есть ли выбранные данные
        if (!selectedData || selectedData.length === 0) {
            notification.error({
                message: 'Ошибка',
                description: 'Выберите документы для сторнирования',
                duration: 3, // Уведомление закроется через 3 секунды
            });
            return;
        }
        setIsModalVisible(true);
    };

    return (
        <div>
            <Button onClick={handleOpenModal}>Сторнировать</Button>
            <HandReverseModal
                visibleModal={isModalVisible}
                onCancel={handleCancel}
            />
        </div>
    );
};

export default BtnReverse;