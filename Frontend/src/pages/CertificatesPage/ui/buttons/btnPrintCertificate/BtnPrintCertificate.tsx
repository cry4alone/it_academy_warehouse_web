import React from 'react';
import { Button, notification } from 'antd';
import { useSelectedDataContext, useDefaultPropsContext } from '../../Context';
//import { makePDF } from './makePDF';
import { ICertificateData } from '../../../types/certificateTypes';

const BtnPrintCertificate = () => {
    const SelectedData: ICertificateData[] = useSelectedDataContext();
    const { setSelectedData } = useDefaultPropsContext();
    const handlePrint = () => {
        //makePDF(SelectedData);
        notification.success({
            message: 'Успех',
            description: 'Сертификат успешно печатан.',
        });
        setSelectedData([]);
    };

    return <Button type='primary' onClick={handlePrint} disabled={!SelectedData.length}>Печать сертификата</Button>;
};

export default BtnPrintCertificate;
