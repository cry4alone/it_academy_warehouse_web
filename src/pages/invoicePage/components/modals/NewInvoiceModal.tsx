import React from 'react';
import { Modal, Form, Button, DatePicker, Select, Input } from 'antd';
import { InvoiceData } from '../../types/invoiceTypes';

// Интерфейс для входных данных (props)
interface NewInvoiceModalProps {
    handleOk: (values: InvoiceData) => void;
    handleCancel: () => void;
    isVisible: boolean;
}

const valuesWarehouse = [
    { value: 'Склад ЛО-1', label: 'Склад ЛО-1' },
    { value: 'Склад ЛО-2', label: 'Склад ЛО-2' },
    { value: 'Склад ЛО-3', label: 'Склад ЛО-3' },
];

const NewInvoiceModal: React.FC<NewInvoiceModalProps> = ({ handleOk, handleCancel, isVisible }) => {
    const [form] = Form.useForm();

    const handleCreate = () => {
        form.validateFields()
            .then((values) => {
                const formattedValues = {
                    ...values,
                    date: values.date.format('YYYY-MM-DD'),
                };
                handleOk(formattedValues);
                form.resetFields();
            })
            .catch((info) => {
                console.log('Validate Form Error:', info);
            });
    };

    return (
        <Modal
            title='Новая накладная'
            open={isVisible}
            onOk={handleCreate}
            onCancel={handleCancel}
            footer={[
                <Button key='cancel' onClick={handleCancel}>
                    Отмена
                </Button>,
                <Button key='submit' type='primary' onClick={handleCreate}>
                    Создать
                </Button>,
            ]}
        >
            <Form form={form}>
                <Form.Item name='where' label='Куда' rules={[{ required: true, message: 'Выберите склад!' }]}>
                    <Select placeholder='Выберите склад' options={valuesWarehouse}></Select>
                </Form.Item>
                <Form.Item
                    name='type'
                    label='Тип возврата'
                    rules={[{ required: true, message: 'Выберите тип возврата!' }]}
                >
                    <Select
                        placeholder='Выберите тип возврата'
                        options={[
                            {
                                value: 'Доработка',
                                label: 'Доработка',
                            },
                            {
                                value: 'Переплав',
                                label: 'Переплав',
                            },
                        ]}
                    ></Select>
                </Form.Item>
                <Form.Item
                    name='reason'
                    label='Причина возврата'
                    rules={[{ required: true, message: 'Выберите причину!' }]}
                >
                    <Select
                        placeholder='Выберите причину возврата'
                        options={[
                            {
                                value: 'Невостребованная продукция',
                                label: 'Невостребованная продукция',
                            },
                            {
                                value: 'Дефект',
                                label: 'Дефект',
                            },
                        ]}
                    ></Select>
                </Form.Item>
                <Form.Item name='defect' label='Дефект'>
                    <Input placeholder='Заполните только если причина возврата Дефект'></Input>
                </Form.Item>
                <Form.Item name='date' label='Дата' rules={[{ required: true, message: 'Выберите дату!' }]}>
                    <DatePicker placeholder='Выберите дату' />
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default NewInvoiceModal;