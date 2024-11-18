import React from 'react';
import { Input as AntdInput } from 'antd';

const Input = ({ placeholder, ...props }) => {
  return <AntdInput placeholder={placeholder} {...props} />;
};

export default Input;
