import React from 'react';
import { Modal, Form, Button, DatePicker, Select, Input } from 'antd';
import { createInvoice } from '../../../../api/createInvoice';
import { InvoiceData } from '../../../../types/invoiceTypes';
import { useDefaultPropsContext } from '../../../Context';

interface NewInvoiceModalProps {
    isVisible: boolean;
    onClose: () => void;
}

const valuesWarehouse = [
    { value: 'Склад ЛО-1', label: 'Склад ЛО-1' },
    { value: 'Склад ЛО-2', label: 'Склад ЛО-2' },
    { value: 'Склад ЛО-3', label: 'Склад ЛО-3' },
];

export const NewInvoiceModal: React.FC<NewInvoiceModalProps> = ({ isVisible, onClose }) => {
    const [form] = Form.useForm();
    const { setInvoices } = useDefaultPropsContext();

    const handleOk = async (data: InvoiceData) => {
        const newInvoice = await createInvoice(data);
        setInvoices((prevInvoices: InvoiceData[]) => [...prevInvoices, { ...newInvoice, key: newInvoice.id }]);
        onClose();
    };

    const handleCancel = () => {
        onClose();
    };

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
            onCancel={onClose}
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
