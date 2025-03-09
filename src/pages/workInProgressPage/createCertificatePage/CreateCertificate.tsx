import { useState } from 'react';
import { Button } from 'antd';
import TableCertificates from "../../../components/table/documents/TableCertificates";
import CertificateModal from "./components/modals/CertificateModal";


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