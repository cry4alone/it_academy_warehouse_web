import React from 'react';
import BtnSign from './btnSign/BtnSign';
import BtnCancel from './btnCancel/BtnCancel';
import BtnSave from './btnSave/BtnSave';
import '@app/styles/global.scss';

const Buttons = () => {
    return (
        <div className='button-container'>
            <BtnCancel />
            <BtnSave />
            <BtnSign />
        </div>
    );
};

export default Buttons;
