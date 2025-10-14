import React from 'react';
import { Button } from 'antd';
import { LeftOutlined } from '@ant-design/icons';

interface LeftArrowProps {
  onClick: () => void; 
  disabled: boolean; 
}

const BtnArrowLeft: React.FC<LeftArrowProps> = ({ onClick, disabled }) => {
  return (
    <Button
      className="arrow left-arrow"
      icon={<LeftOutlined />}
      onClick={onClick}
      disabled={disabled}
    />
  );
};

export default BtnArrowLeft;