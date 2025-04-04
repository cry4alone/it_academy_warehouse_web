import React from 'react';
import { Input } from 'antd';

interface InputPasswordProps {
    placeholder: string;
    value: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    required?: boolean;
    borderColor?: string;
}

const InputPassword: React.FC<InputPasswordProps> = ({ placeholder, value, onChange, required, borderColor }) => {
    return (
        <Input.Password
            placeholder={placeholder}
            value={value}
            onChange={onChange}
            required={required}
            autoComplete='current-password'
            style={{ borderColor }}
        />
    );
};

export default InputPassword;
