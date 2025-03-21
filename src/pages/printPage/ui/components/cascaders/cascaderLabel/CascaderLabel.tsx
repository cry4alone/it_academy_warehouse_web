import React from 'react';
import { Cascader } from 'antd';
import { usePrintContext } from '../../../Context';

interface Option {
    value: string;
    label: string;
}

const options: Option[] = [
    {
        value: 'ETR',
        label: 'ETR',
    },
    {
        value: 'TBR',
        label: 'TBR',
    },
    {
        value: 'SOW',
        label: 'SOW',
    },
];

const CascaderLabel = () => {
    const { setSelectedLabel } = usePrintContext();

    const onChange = (value: string[]) => {
        if (value.length > 0) {
            setSelectedLabel(value[0]); // Update the selected label in context
        }
    };

    return (
        <div>
            <h5>Этикетка</h5>
            <Cascader options={options} onChange={onChange} placeholder="Выберите" />
        </div>
    );
};

export default CascaderLabel;