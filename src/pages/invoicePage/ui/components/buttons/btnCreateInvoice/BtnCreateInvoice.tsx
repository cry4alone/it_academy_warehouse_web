import React, { useState } from 'react';
import { Button } from 'antd';
import { NewInvoiceModal } from './NewInvoiceModal';

const BtnCreateInvoice = () => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const handleOpenModal = () => {
        setIsModalOpen(true);
    };

    const handleCloseModal = () => {
        setIsModalOpen(false);
    };

    return (
        <>
            <Button onClick={handleOpenModal}>Создать накладную</Button>
            <NewInvoiceModal
                isVisible={isModalOpen}
                onClose={handleCloseModal}
            />
        </>
    );
};

export default BtnCreateInvoice;