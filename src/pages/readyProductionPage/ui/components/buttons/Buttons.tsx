import React from 'react';
import BtnPrints from './btnPrint/BtnPrints';
import BtnRedistribute from './btnRedistribute/BtnRedistribute';
import BtnCertificate from './btnCertificate/BtnCertificate';
import { Flex } from 'antd';
import BtnReturn from './btnReturn/btnReturn';

const Buttons = () => {
    return (
        <div className='button-container'>
            <Flex gap='middle' justify='flex-end'>
                <BtnPrints />
                <BtnReturn />
                <BtnRedistribute />
                <BtnCertificate />
            </Flex>
        </div>
    );
};

export default Buttons;
