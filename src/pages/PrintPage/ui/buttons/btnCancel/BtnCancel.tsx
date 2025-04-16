import React from 'react'
import { Button } from 'antd'
import { useNavigate } from 'react-router-dom';

const btnCancel = () => {
    const navigate = useNavigate();
    
    const handleCancelNavigation = () => {
        navigate('/gp');
        };
    return (
    <Button onClick={handleCancelNavigation}>Отмена</Button>
    )
}

export default btnCancel