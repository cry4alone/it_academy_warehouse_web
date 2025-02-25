import React from 'react';
import { Modal, Form, Input, Select, Button, Checkbox } from 'antd';

const { Option } = Select;

interface PackageModalProps {
    isPackageModalVisible: boolean;
    handlePackageOk: () => void;
    handlePackageCancel: () => void;
}

const PackageModal: React.FC<PackageModalProps> = ({ isPackageModalVisible, handlePackageOk, handlePackageCancel }) => {
    return (
        <Modal
            title="Выбор упаковки"
            open={isPackageModalVisible}
            onOk={handlePackageOk}
            onCancel={handlePackageCancel}
            footer={[
                <Button key="cancel" onClick={handlePackageCancel}>
                    Отмена
                </Button>,
                <Button key="submit" type="primary" onClick={handlePackageOk}>
                    Применить
                </Button>,
            ]}
        >
            <Form layout="vertical">
                <Form.Item label="Вид материала">
                    <Select placeholder="Выберите материал">
                        <Option value="material1">Материал 1</Option>
                        <Option value="material2">Материал 2</Option>
                    </Select>
                </Form.Item>
                <Form.Item label="Спецификация">
                    <Select placeholder="Выберите спецификацию">
                        <Option value="spec1">Спецификация 1</Option>
                        <Option value="spec2">Спецификация 2</Option>
                    </Select>
                </Form.Item>
                <Form.Item label="Вес, кг">
                    <Input />
                </Form.Item>
                <Form.Item label="Упаковка">
                    <Select placeholder="Выберите упаковку">
                        <Option value="package1">Упаковка 1</Option>
                        <Option value="package2">Упаковка 2</Option>
                    </Select>
                </Form.Item>
                <Form.Item label="Вес поддона">
                    <Input />
                </Form.Item>
                <Form.Item label="Ручной вес:">
                    <Input />
                </Form.Item>
                <Form.Item>
                    <Checkbox>Пакет был взвешен с упаковкой</Checkbox>
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default PackageModal;
