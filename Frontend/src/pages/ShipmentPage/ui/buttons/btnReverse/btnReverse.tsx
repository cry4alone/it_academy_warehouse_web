import React, { useState } from 'react';
import { Button, notification } from 'antd';
import { useSelectedDataContext } from '../../Context';
import HandReverseModal from "./HandReverseModal";

const BtnReverse = () => {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const selectedData = useSelectedDataContext(); 

    const handleCancel = () => {
        setIsModalVisible(false);
    };

    const handleOpenModal = () => {
        // Проверяем, есть ли выбранные данные
        if (!selectedData || selectedData.length === 0) {
            notification.error({
                message: 'Ошибка',
                description: 'Выберите документы для сторнирования',
                duration: 3, 
            });
            return;
        }
        setIsModalVisible(true);
    };

    return (
        <div>
            <Button onClick={handleOpenModal} disabled={selectedData.length === 0}>Сторнировать</Button>
            <HandReverseModal
                visibleModal={isModalVisible}
                onCancel={handleCancel}
            />
        </div>
    );
};

export default BtnReverse;