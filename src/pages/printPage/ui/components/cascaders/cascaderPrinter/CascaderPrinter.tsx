import React from 'react';
import { Cascader } from 'antd';
import { usePrintContext } from '../../../Context';

interface Option {
    value: string;
    label: string;
}

const options: Option[] = [
    {
        value: 'Принтер 1',
        label: 'Принтер 1',
    },
    {
        value: 'Принтер 2',
        label: 'Принтер 2',
    },
];

const CascaderPrinter = () => {
    const { setSelectedPrinter } = usePrintContext();

    const onChange = (value: string[]) => {
        if (value.length > 0) {
            setSelectedPrinter(value[0]);
        }
    };

    return (
        <div>
            <h5>Принтер</h5>
            <Cascader options={options} onChange={onChange} placeholder="Выберите" />
        </div>
    );
};

export default CascaderPrinter;