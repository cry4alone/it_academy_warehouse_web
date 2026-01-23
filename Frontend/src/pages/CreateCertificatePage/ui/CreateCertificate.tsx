import React from 'react';
import { useState } from 'react';
import { Button } from 'antd';
import { CertificateModal } from "./modals/CertificateModal";
import TableCertificates from '@/pages/CertificatesPage/ui/table/TableCertificates';
import { CertificateProvider } from '@/pages/CertificatesPage/ui/Context';


export const CreateCertificate = () => {
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
            <CertificateProvider>
                <TableCertificates />
                <Button onClick={showCertificateModal}>Создать сертификат</Button>
                <CertificateModal 
                    isCertificateModalVisible={isCertificateModalVisible}
                    handleOk={handleOk}
                    handleCancel={handleCancel}
                />
            </CertificateProvider>
        </>
    );
};
