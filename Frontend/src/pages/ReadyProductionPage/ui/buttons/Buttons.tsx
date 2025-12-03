import React from 'react';
import BtnPrints from './btnPrint/BtnPrints';
import BtnRedistribute from './btnRedistribute/BtnRedistribute';
import BtnCertificate from './btnCertificate/BtnCertificate';
import BtnReturn from './btnReturn/btnReturn';

const Buttons = () => {
    return (
        <div className='button-container'>
                <BtnPrints />
                <BtnReturn />
                <BtnRedistribute />
                <BtnCertificate />
        </div>
    );
};

export default Buttons;
