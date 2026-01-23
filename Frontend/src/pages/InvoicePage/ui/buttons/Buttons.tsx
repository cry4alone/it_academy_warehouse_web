import React from 'react';
import BtnSign from './btnSign/BtnSign';
import BtnCreateInvoice from './btnCreateInvoice/BtnCreateInvoice';
import BtnCancel from './btnCancel/BtnCancel';
import '@app/styles/global.scss';

const Buttons = () => {
    return (
        <div className='button-container'>
            <BtnCancel />
            <BtnSign />
            <BtnCreateInvoice />
        </div>
    );
};

export default Buttons;
