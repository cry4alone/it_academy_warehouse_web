import React from 'react';
import { Button, notification } from 'antd';
import { useSelectedDataContext } from '../../../Context';
import { makePDF } from './makePDF';
import { ICertificateData } from '../../../../types/certificateTypes';

const BtnPrintCertificate = () => {
    const SelectedData: ICertificateData[] = useSelectedDataContext();
    const handlePrint = () => {
        makePDF(SelectedData);
        notification.success({
            message: 'Успех',
            description: 'Сертификат успешно печатан.',
        });
    };

    return <Button onClick={handlePrint}>Печать сертификата</Button>;
};

export default BtnPrintCertificate;
