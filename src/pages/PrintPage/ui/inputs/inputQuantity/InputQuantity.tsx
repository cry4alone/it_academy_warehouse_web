import React, { useState } from 'react';
import { Input } from 'antd';

const InputQuantity = () => {
    const [value, setValue] = useState('1'); 

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const inputValue = e.target.value;

        if (/^[1-9]\d*$/.test(inputValue)) {
            setValue(inputValue); 
        } else if (inputValue === '') {
            setValue(''); 
        }
    };

    return (
        <>
            <h5>Количество копий</h5>
            <Input
                placeholder="1"
                value={value}
                onChange={handleChange}
                type="text"
            />
        </>
    );
};

export default InputQuantity;