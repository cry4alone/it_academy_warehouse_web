import React, { useState, useEffect } from 'react';
import TableInvoice from "./components/table/TableInvoice";
import NewInvoiceModal from "./components/modals/NewInvoiceModal";
import { Button } from 'antd';
import { useLocation } from 'react-router-dom';
import { createInvoice } from './api/createInvoice';
import { fetchInvoices } from './api/fetchInvoices';
import { InvoiceData } from './types/invoiceTypes';
import '@app/styles/global.scss';



function Invoice() {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [invoices, setInvoices] = useState<InvoiceData[]>([]);
    const location = useLocation();
    const selectedData = location.state.selectedData;

    useEffect(() => {
        console.log(selectedData);
        const loadInvoices = async () => {
            try {
                const data = await fetchInvoices();
                setInvoices(data.map(item => ({ ...item, key: item.id })));
            }
            catch (error) {
                console.error('Error fetching data:', error);
            }
        }
        loadInvoices();
    }, [])

    const showModal = () => {
        setIsModalOpen(true);
    };

    const handleOk = async (data: InvoiceData) => {
        const newInvoice = await createInvoice(data);
        console.log(newInvoice);
        setInvoices((prevInvoices) => [...prevInvoices, { ...newInvoice, key: newInvoice.id }]);
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };

    return (
        <>
            <div className="tab__title">Документы | Накладная возврата</div>
            <NewInvoiceModal
                handleOk={handleOk}
                handleCancel={handleCancel}
                isVisible={isModalOpen}
            />
            <TableInvoice dataSource={invoices} />
            <div className="button-container">
                <Button>Отмена</Button>
                <Button>Подписать</Button>
                <Button onClick={showModal}>Создать накладную</Button>
                <Button type="primary">Сохранить</Button>
            </div>
        </>
    );
}

export default Invoice;