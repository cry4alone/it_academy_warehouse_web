import { useState } from 'react';
import { Button, notification } from 'antd';
import HandMeasureModal from './HandMeasureModal';
import { useSelectedRowsContext } from '../../Context';


const BtnHandMeasure = () => {
    const selectedRows = useSelectedRowsContext() || [];
    console.log(selectedRows);
    const [isModalVisible, setIsModalVisible] = useState(false);

    const handleCancel = () => {
        setIsModalVisible(false); 
    };

    const handleMeasureProduct = () => {
        if (selectedRows !== undefined && selectedRows.length > 0) {
        setIsModalVisible(true); 
        } else {
        notification.error({
            message: 'Ошибка',
            description: 'Пожалуйста, выберите хотя бы одну строку для ручного взвешивания.',
        });
        }
    };

    return (
        <div>
        <Button
            onClick={handleMeasureProduct}
            aria-label="Ручное взвешивание"
            disabled={selectedRows.length === 0}
        >
            Ручное взвешивание
        </Button>
        <HandMeasureModal
            visibleModal={isModalVisible}
            onCancel={handleCancel}
        />
        </div>
    );
};

export default BtnHandMeasure;
