import { Button } from 'antd';
import React from 'react';
import { useNavigate } from 'react-router-dom';

const BtnCertificate = () => {
    const navigate = useNavigate();

    const handleWorkCertificates = () => {
        navigate('/documents/certificates');
    };
    return <Button onClick={handleWorkCertificates}>Работа с сертификатами</Button>;
};

export default BtnCertificate;
