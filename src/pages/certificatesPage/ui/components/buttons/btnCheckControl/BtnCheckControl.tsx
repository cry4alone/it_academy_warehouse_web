import ControlSchemeModal from './ControlSchemeModal';
import React, { useState } from 'react';
import { Button } from 'antd';

const BtnCheckControl = () => {
    const showControlSchemeModal = () => {
        setIsControlSchemeModalVisible(true);
    };
    const [isControlSchemeModalVisible, setIsControlSchemeModalVisible] = useState(false);

    const handleOk = () => {
        setIsControlSchemeModalVisible(false);
    };

    const handleCancel = () => {
        setIsControlSchemeModalVisible(false);
    };

    return (
        <>
            <Button type='primary' onClick={showControlSchemeModal}>
                Проверка схемы контроля
            </Button>
            <ControlSchemeModal
                isControlSchemeModalVisible={isControlSchemeModalVisible}
                handleOk={handleOk}
                handleCancel={handleCancel}
            />
        </>
    );
};

export default BtnCheckControl;
