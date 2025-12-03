import React from 'react'
import { Button } from 'antd'
import { useLocation, useNavigate } from 'react-router-dom'

const btnCancel = () => {
    const location = useLocation();
    const from = location.state?.from || '/documents/transfers';
    const navigate = useNavigate();
    
    const handleCancel = () => {
        navigate(from, { replace: true, state: {} });
    }

  return (
    <Button onClick={handleCancel}>Отмена</Button>
  )
}

export default btnCancel