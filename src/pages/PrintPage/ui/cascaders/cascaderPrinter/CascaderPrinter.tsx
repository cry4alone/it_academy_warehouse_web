import React from 'react';
import { Select } from 'antd';

import { usePrintContext } from '../../Context';

type PrinterOption = {
    value: string;
    label: string;
};

const PrinterSelector: React.FC = () => {
    const { setSelectedPrinter } = usePrintContext();

    const options: PrinterOption[] = [
        { value: 'Принтер 1', label: 'Принтер 1' },
        { value: 'Принтер 2', label: 'Принтер 2' },
    ];

    const handleChange = (value: string) => {
        setSelectedPrinter(value);
    };

    return (
        <div>
            <h5>Принтер</h5>
            <Select placeholder='Выберите принтер' onChange={handleChange} options={options} />
        </div>
    );
};

export default PrinterSelector;
