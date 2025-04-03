import React from 'react';
import { useState } from 'react';
import { Button } from 'antd';
import CertificateModal from "./components/modals/CertificateModal";
import TableCertificates from '@/pages/certificatesPage/ui/components/table/TableCertificates'; // может передвинуть в widgets так как используется в нескольких компонентах


const CreateCertificate = () => {
    const [isCertificateModalVisible, setIsCertificateModalVisible] = useState<boolean>(false);

    const showCertificateModal = () => {
        setIsCertificateModalVisible(!isCertificateModalVisible);
    }
    
    const handleOk = () => {
        setIsCertificateModalVisible(!isCertificateModalVisible);
    };

    const handleCancel = () => {
        setIsCertificateModalVisible(!isCertificateModalVisible);
    };

    return (
        <>
            <div className="tab__title">НЗП | Создание сертификата</div>
            <TableCertificates />
            <Button onClick={showCertificateModal}>Создать сертификат</Button>
            <CertificateModal 
                isCertificateModalVisible={isCertificateModalVisible}
                handleOk={handleOk}
                handleCancel={handleCancel}
            />
        </>
    );
};

export default CreateCertificate;