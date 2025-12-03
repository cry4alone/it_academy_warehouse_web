import React from 'react';
import { Select } from 'antd';
import { usePrintContext } from '../../Context';

const PrinterSelector: React.FC = () => {
    const { setSelectedLabel } = usePrintContext();

    const options = [
        { value: 'ETR', label: 'ETR' },
        { value: 'TBR', label: 'TBR' },
        { value: 'SOW', label: 'SOW' },
    ];

    const handleChange = (value: string) => {
        setSelectedLabel(value);
    };

    return (
        <div>
            <h5>Этикетка</h5>
            <Select  placeholder='Выберите' onChange={handleChange} options={options} />
        </div>
    );
};

export default PrinterSelector;
