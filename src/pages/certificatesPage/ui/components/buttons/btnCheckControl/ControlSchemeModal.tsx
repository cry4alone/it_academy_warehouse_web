import React from 'react';
import { Modal, Form, Input, Select, Button } from 'antd';

const { Option } = Select;

interface ControlSchemeModalProps {
    isControlSchemeModalVisible: boolean;
    handleOk: () => void;
    handleCancel: () => void;
}

const ControlSchemeModal: React.FC<ControlSchemeModalProps> = ({ isControlSchemeModalVisible, handleOk, handleCancel }) => {
    return (
        <Modal
            title="Схема контроля"
            open={isControlSchemeModalVisible}
            onOk={handleOk}
            onCancel={handleCancel}
            footer={[
                <Button key="cancel" onClick={handleCancel}>
                    Отмена
                </Button>,
                <Button key="submit" type="primary" onClick={handleOk}>
                    Добавить
                </Button>,
            ]}
        >
            <Form layout="vertical">
                <Form.Item label="Стандарт">
                    <Select placeholder="Выберите стандарт">
                        <Option value="standard1">Стандарт 1</Option>
                        <Option value="standard2">Стандарт 2</Option>
                    </Select>
                </Form.Item>
                <Form.Item label="Марка">
                    <Select placeholder="Выберите марку">
                        <Option value="mark1">Марка 1</Option>
                        <Option value="mark2">Марка 2</Option>
                    </Select>
                </Form.Item>
                <Form.Item label="Пакет">
                    <Select placeholder="Выберите пакет">
                        <Option value="package1">Пакет 1</Option>
                        <Option value="package2">Пакет 2</Option>
                    </Select>
                </Form.Item>
                <Form.Item label="Продукция">
                    <Select placeholder="Выберите продукцию">
                        <Option value="product1">Продукция 1</Option>
                        <Option value="product2">Продукция 2</Option>
                    </Select>
                </Form.Item>
                <Form.Item label="Схема контроля">
                    <Input />
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default ControlSchemeModal;
