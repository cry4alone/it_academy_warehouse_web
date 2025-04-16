import React, { useState } from 'react';
import { Modal, Form, Select, Button } from 'antd';


const { Option } = Select;

interface ControlSchemeModalProps {
    isControlSchemeModalVisible: boolean;
    handleOk: () => void;
    handleCancel: () => void;
    onSaveControlScheme: (controlScheme: string) => void;
}

const ControlSchemeModal: React.FC<ControlSchemeModalProps> = ({isControlSchemeModalVisible, handleOk, handleCancel, onSaveControlScheme }) => {
    
    const [selectedStandard, setSelectedStandard] = useState<string | null>(null);
    const [selectedBrand, setSelectedBrand] = useState<string | null>(null);
    const [selectedPack, setSelectedPack] = useState<string | null>(null);
    const [selectedProducts, setSelectedProducts] = useState<string | null>(null);
    
    const handleSave = () => {
        if (selectedStandard && selectedBrand && selectedPack && selectedProducts) {
            const controlScheme = `${selectedStandard}/${selectedBrand}/${selectedPack}/${selectedProducts}`
            onSaveControlScheme(controlScheme);
            handleOk();
        }
        else {
            console.log('Пожалуйста, заполните все поля!');
        }
    };

    return (
        <>
            <Modal
                title="Схема контроля"
                open={isControlSchemeModalVisible}
                onOk={handleSave}
                onCancel={handleCancel}
                maskClosable={false}
                footer={[
                    <Button key="cancel" onClick={handleCancel}>
                        Отмена
                    </Button>,
                    <Button key="submit" type="primary" onClick={handleSave}>
                        Сохранить
                    </Button>,
                ]}
            >
                <Form
                    layout='horizontal'  
                    labelCol={{ span: 7 }}
                    wrapperCol={{ span: 14 }}
                >
                    <Form.Item label="Стандарт:">
                        <Select 
                            value={selectedStandard}
                            onChange={(value) => setSelectedStandard(value)}
                        >
                            <Option value="ГОСТ 11089-2019">ГОСТ 11089-2019</Option>
                            <Option value="ГОСТ 4784-97">ГОСТ 4784-97</Option>
                            <Option value="ГОСТ 11059-2019">ГОСТ 11059-2019</Option>
                        </Select>
                    </Form.Item>
                    <Form.Item label="Марка:">
                        <Select
                            value={selectedBrand}
                            onChange={(value) => setSelectedBrand(value)}
                        >
                            <Option value="A7">A7</Option>
                            <Option value="A8">A8</Option>
                            <Option value="A10">A10</Option>
                        </Select>
                    </Form.Item>
                    <Form.Item label="Пакет:">
                        <Select
                            value={selectedPack}
                            onChange={(value) => setSelectedPack(value)}
                        >
                            <Option value="1-ый пакет">1-ый пакет</Option>
                            <Option value="2-ой пакет">2-ой пакет</Option>
                        </Select>
                    </Form.Item>
                    <Form.Item label="Продукция:">
                        <Select
                            value={selectedProducts}
                            onChange={(value) => setSelectedProducts(value)}
                        >
                            <Option value="Чушка">Чушка</Option>
                            <Option value="Цилиндрические слитки">Цилиндрические слитки</Option>
                            <Option value="Катанка">Катанка</Option>
                        </Select>
                    </Form.Item>
                </Form>
            </Modal>
        </>
    );
}

export default ControlSchemeModal;
