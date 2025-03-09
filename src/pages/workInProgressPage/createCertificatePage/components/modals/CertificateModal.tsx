import React, { useState } from 'react';
import { Modal, Form, Button, Select, Input, InputNumber } from 'antd';
import DelivaryModal from "./DeliveryModal";
import ControlSchemeModal from "./ControlSchemeModal";


interface CertificateModalProps {
    isCertificateModalVisible: boolean;
    handleOk: () => void;
    handleCancel: () => void
}

const CertificateModal: React.FC<CertificateModalProps> = ({isCertificateModalVisible, handleOk, handleCancel}) => {
    
    // Для модульного окна поставки (DelivaryModal)
    const [isDelivaryModalVisible, setIsDeliveryModalVisible] = useState<boolean>(false);
    const [delivaryValue, setDelivaryValue] = useState<number>(0);

    const handleOkDelivaryModal = () => {
        setIsDeliveryModalVisible(!isDelivaryModalVisible);
    };

    const handleCancelDelivaryModal = () => {
        setIsDeliveryModalVisible(!isDelivaryModalVisible);
    };

    const handleSaveDelivary = (delivary: number) => {
        setDelivaryValue(delivary)
    }

    // Для модульного окна схемы контроля (ControlSchemeModal)
    const [isControlSchemeModalVisible, setIsControlSchemeModalVisible] = useState<boolean>(false);
    const [controlSchemeValue, setControlSchemeValue] = useState<string>("");

    const handleOkControlSchemeModal = () => {
        setIsControlSchemeModalVisible(!isControlSchemeModalVisible);
    };

    const handleCancelControlSchemeModal = () => {
        setIsControlSchemeModalVisible(!isControlSchemeModalVisible);
    };

    const handleSaveControlScheme = (controlScheme: string) => {
        setControlSchemeValue(controlScheme);
    }

    return (
        <Modal
            title="Создание серитификата"
            open={isCertificateModalVisible}
            onOk={handleOk}
            onCancel={handleCancel}
            maskClosable={false}
            footer={[
                <Button key="cancel" onClick={handleCancel}>
                    Отмена
                </Button>,
                <Button key="submit" type="primary" onClick={handleOk}>
                    Сохранить
                </Button>,
            ]}
        >
            <Form 
                layout="horizontal"
                labelCol={{ span: 7 }}
                wrapperCol={{ span: 14 }}
                >
                <Form.Item label="Секция">
                    <InputNumber min={0}/>
                </Form.Item>
                <Form.Item label="Поставка">
                    <Input
                        value={delivaryValue}
                        readOnly
                        suffix={
                            <Button onClick={() => setIsDeliveryModalVisible(true)}>
                                Выбрать
                            </Button>
                        }
                    />
                </Form.Item>
                <Form.Item label="Схема контроля">
                <Input
                        value={controlSchemeValue}
                        readOnly
                        suffix={
                            <Button onClick={() => setIsControlSchemeModalVisible(true)}>
                                Выбрать
                            </Button>
                        }
                    />
                </Form.Item>
                <Form.Item label="Плановый вес">
                    <InputNumber min={100}/>
                </Form.Item>
            </Form>
            <DelivaryModal 
                isDelivaryModalVisible={isDelivaryModalVisible}
                handleOk={handleOkDelivaryModal}    
                handleCancel={handleCancelDelivaryModal}
                onSaveDelivary={handleSaveDelivary}
            />
            <ControlSchemeModal 
                isControlSchemeModalVisible={isControlSchemeModalVisible}
                handleOk={handleOkControlSchemeModal}
                handleCancel={handleCancelControlSchemeModal}
                onSaveControlScheme={handleSaveControlScheme}
            />
        </Modal>
    );
};

export default CertificateModal;