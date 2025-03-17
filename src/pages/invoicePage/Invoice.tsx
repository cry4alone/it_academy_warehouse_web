import React, { useState, useEffect } from 'react';
import TableInvoice from './components/table/TableInvoice';
import NewInvoiceModal from './components/modals/NewInvoiceModal';
import { Button, notification } from 'antd';
import { useLocation } from 'react-router-dom';
import { createInvoice } from './api/createInvoice';
import { fetchInvoices } from './api/fetchInvoices';
import { InvoiceData } from './types/invoiceTypes';
import { signInvoice } from './api/signInvoice';
import '@app/styles/global.scss';

function Invoice() {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [invoices, setInvoices] = useState<InvoiceData[]>([]);
    const [selectedRows, setSelectedRows] = useState<React.Key[]>([]);
    const [selectedData, setSelectedData] = useState<InvoiceData[]>([]);
    const location = useLocation();
    const selectedItems = location.state?.selectedData || {};

    useEffect(() => {
        const loadInvoices = async () => {
            try {
                const data = await fetchInvoices();
                setInvoices(data.map((item) => ({ ...item, key: item.id })));
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        loadInvoices();
    }, []);

    const showModal = () => {
        setIsModalOpen(true);
    };

    const handleOk = async (data: InvoiceData) => {
        const newInvoice = await createInvoice(data);
        setInvoices((prevInvoices) => [...prevInvoices, { ...newInvoice, key: newInvoice.id }]);
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };

    const handleSign = () => {
        if (selectedData.length === 0) {
            notification.error({
                message: 'Error',
                description: 'Не выбрана накладная для подписи!',
            });
            return;
        }
        if (Object.keys(selectedItems).length === 0) {
            notification.error({
                message: 'Error',
                description: 'Не выбраны позиции для подписи!',
            });
            return;
        }
        signInvoice(selectedData, selectedItems);
        notification.success({
            message: 'Success',
            description: 'Накладная подписана',
        });
    };

    return (
        <>
            <div className='tab__title'>Документы | Накладная возврата</div>
            <NewInvoiceModal handleOk={handleOk} handleCancel={handleCancel} isVisible={isModalOpen} />
            <TableInvoice
                onSelectionChange={(NewSelectedRows: React.Key[], NewSelectedData: InvoiceData[]) => {
                    setSelectedRows(NewSelectedRows);
                    setSelectedData(NewSelectedData);
                }}
                dataSource={invoices}
            />
            <div className='button-container'>
                <Button>Отмена</Button>
                <Button onClick={handleSign}>Подписать</Button>
                <Button onClick={showModal}>Создать накладную</Button>
                <Button type='primary'>Сохранить</Button>
            </div>
        </>
    );
}

export default Invoice;
