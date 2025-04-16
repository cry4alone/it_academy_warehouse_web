import React, {useEffect, useState} from 'react';
import { Modal, Form, Input, Select, Button, InputNumber } from 'antd';
import OrderTable from '../tables/OrderTable';

const { Option } = Select;

interface DelivaryModalProps {
    isDelivaryModalVisible: boolean;
    handleOk: () => void;
    handleCancel: () => void;
    onSaveDelivary: (delivary: number ) => void;
}

const DeliveryModal: React.FC<DelivaryModalProps> = ({isDelivaryModalVisible, handleOk, handleCancel, onSaveDelivary}) => {

    const [selectedRow, setSelectedRow] = useState<React.Key[]>([]);
    const [selectedRowData, setSelectedRowData] = useState<any>(null);
    
    const [deliveryNumber, setDeliveryNumber] = useState<number | null> (null);
    const [selectedDeliveryNumber, setSelectedDeliveryNumber] = useState<number | null>(null);

    const handleRowSelection = (selectedRowKeys: React.Key[], selectedRows: any[]) => {
        setSelectedRow(selectedRowKeys);
        setSelectedRowData(selectedRows[0]); // Сохраняем данные выбранной строки
    };

    const handleSave = () => {
        if (selectedRowData) {
            const selectedIdDelivary = selectedRowData.idDelivary;
            onSaveDelivary(selectedIdDelivary); 
            handleOk();
        } else {
            console.log('Пожалуйста, выберите поставку!');
        }
    };

    return (
        <>
            <Modal
                title="График отгрузки"
                open={isDelivaryModalVisible}
                onOk={handleSave}
                onCancel={handleCancel}
                maskClosable={false}
                width="1100px"
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
                    layout='inline'  
                >
                    <Form.Item label="Номер поставки:">
                        <InputNumber
                            min={0}
                            value={deliveryNumber}
                            onChange={(value) => setDeliveryNumber(value)}
                            />
                    </Form.Item>
                    <Form.Item>
                        <Button onClick={() => setSelectedDeliveryNumber(deliveryNumber)}>
                            Найти
                        </Button>
                    </Form.Item>
                    <Form.Item label="Контракт:">
                        <Select>
                            <Option>1 вариант</Option>
                            <Option>2 вариант</Option>
                        </Select>
                    </Form.Item>
                    <div style={{ marginTop: '16px' }}>
                        <OrderTable 
                            onSelectionChange={handleRowSelection}
                            selectedDeliveryNumber={selectedDeliveryNumber}
                        />
                    </div>
                </Form>
            </Modal>
        </>
    );
};

export default DeliveryModal;