import React from 'react';
import './Input.scss';

const Input = ({ placeholder, ...props }) => {
  return <input className= "inp" placeholder={placeholder} {...props} />;
};

export default Input;
