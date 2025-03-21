import React from 'react';
import './style.scss';
import Buttons from './components/buttons/Buttons';
import Cascaders from './components/cascaders/Cascaders'
import CheckboxAllow from './components/checkbox/CheckboxAllow';
import LabelExample from './components/labelexample/LabelExample'
import Inputs from './components/inputs/Inputs';
import { PrintProvider } from './Context';

function Print() {
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

export default Print;
