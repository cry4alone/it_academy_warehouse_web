import React from 'react';
import './style.scss';
import Buttons from './buttons/Buttons';
import Cascaders from './cascaders/Cascaders'
import CheckboxAllow from './checkbox/CheckboxAllow';
import LabelExample from './labelexample/LabelExample'
import Inputs from './inputs/Inputs';
import { PrintProvider } from './Context';

export const PrintPage = () => {
    return (
        <>
            <PrintProvider>
                <div className='tab__title'>Печать этикеток</div>
                <div className='main'>
                    <div className='left_container'>
                        <Cascaders />
                        <Inputs/>
                        <CheckboxAllow />
                    </div>
                    <div className='right_container'>
                        <LabelExample />
                    </div>
                </div>
                <Buttons />
            </PrintProvider>
        </>
    );
}

