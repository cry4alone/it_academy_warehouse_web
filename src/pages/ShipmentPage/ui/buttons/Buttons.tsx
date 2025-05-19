import React from 'react';
import BtnSign from './btnSign/BtnSign';
import BtnCancel from './btnCancel/BtnCancel';
import BtnSave from './btnSave/BtnSave';
import '@app/styles/global.scss';
import BtnReverse from "./btnReverse/btnReverse.tsx";

const Buttons = () => {
    return (
        <div className='button-container'>
            <BtnReverse/>
            <BtnCancel />
            <BtnSave />
            <BtnSign />
        </div>
    );
};

export default Buttons;
