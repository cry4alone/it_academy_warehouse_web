import React from 'react';
import { Button } from 'antd';
import { RightOutlined } from '@ant-design/icons';

interface RightArrowProps {
  onClick: () => void; 
  disabled: boolean; 
}

const BtnArrowRight: React.FC<RightArrowProps> = ({ onClick, disabled }) => {
  return (
    <Button
      className="arrow right-arrow"
      icon={<RightOutlined />}
      onClick={onClick}
      disabled={disabled}
    />
  );
};

export default BtnArrowRight;