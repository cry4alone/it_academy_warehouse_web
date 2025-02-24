import React from 'react';
import './Input.scss';

interface InputProps {
    placeholder?: string;
    value?: string;
    onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void;
    required?: boolean;
    type?: "text" | "password";
    style?: React.CSSProperties;
}

const Input: React.FC<InputProps> = ({ placeholder, ...props }) => {
  return <input className= "inp" placeholder={placeholder} {...props} />;
};

export default Input;
