//import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Button } from 'antd';
import BtnHandMeasure from './btnHandMeasure/BtnHandMeasure';


export const Buttons = () => {

    const navigate = useNavigate();
    
    const handleCreateCertificate = () => {
        navigate('/nzp/create-certificate');
    }

    return (
        <>
            <BtnHandMeasure />
            <Button>Обработка накладных возврата</Button>
            <Button type='primary' onClick={handleCreateCertificate}>Создание сертификата</Button>
        </>
    )
};