import React from 'react';
import InputQuantity from './inputQuantity/InputQuantity';
import InputX from './inputX/InputX';
import InputY from './inputY/inputY';
import './style.scss';

const Inputs = () => {
    return (
        <div className='input-container'>
            <InputQuantity />
            <InputX />
            <InputY />
        </div>
    );
};

export default Inputs;
