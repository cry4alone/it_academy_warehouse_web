import React from 'react';
import BtnPrint from './btnPrint/BtnPrint';
import BtnCancel from './btnCancel/BtnCancel';
import './style.scss';

const Buttons = () => {
    return (
        <div className='button-container'>
            <BtnCancel />
            <BtnPrint />
        </div>
    );
};

export default Buttons;
