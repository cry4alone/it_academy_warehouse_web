import React from 'react';
import { useState } from 'react';
import { Button } from 'antd';
import CertificateModal from "./components/modals/CertificateModal";
import TableCertificates from '@widgets/tables/TableCertificates';
import { CertificateProvider } from '@pages/certificatesPage/ui/Context';


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
            <CertificateProvider>
                <div className="tab__title">НЗП | Создание сертификата</div>
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

export default CreateCertificate;