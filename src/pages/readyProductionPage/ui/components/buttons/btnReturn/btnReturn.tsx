import React from 'react';
import { Button } from 'antd';
import { useNavigate, useLocation } from 'react-router-dom';
import { useSelectedDataContext } from '../../../Context';

const BtnReturn: React.FC = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const { selectedData } = useSelectedDataContext();

    const handleReturnProduct = () => {
        if (!selectedData || selectedData.length === 0) {
            console.warn('No data selected for return.');
            return;
        }

        navigate('/documents/transfers', {
            state: { data: selectedData, from: location },
        });
    };

    return (
        <Button onClick={handleReturnProduct} disabled={!selectedData || selectedData.length === 0}>
            Возврат продукции
        </Button>
    );
};

export default BtnReturn;
