import React from 'react';
import BtnSign from './btnSign/BtnSign';
import BtnCancel from './btnCancel/BtnCancel';
import '@app/styles/global.scss';
import BtnReverse from "./btnReverse/btnReverse";

const Buttons = () => {
    return (
        <div className='button-container'>
            <BtnCancel />
            <BtnReverse/>
            <BtnSign />
        </div>
    );
};

export default Buttons;
