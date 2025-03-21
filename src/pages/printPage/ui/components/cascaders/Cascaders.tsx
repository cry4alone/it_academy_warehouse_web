import React from 'react';
import CascaderPrinter from './cascaderPrinter/CascaderPrinter'
import CascaderLabel from './cascaderLabel/CascaderLabel';
import './style.scss';

const Buttons = () => {
    return (
        <div className='cascader-container'>
            <CascaderPrinter />
            <CascaderLabel />
        </div>
    );
};

export default Buttons;
