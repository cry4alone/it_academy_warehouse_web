import React from 'react';
import { Input } from 'antd';

interface InputLoginProps {
    placeholder: string;
    value: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    required?: boolean;
}

const InputLogin: React.FC<InputLoginProps> = ({ placeholder, value, onChange, required }) => {
    return (
        <Input
            placeholder={placeholder}
            value={value}
            onChange={onChange}
            required={required}
            autoComplete='username'
        />
    );
};

export default InputLogin;
