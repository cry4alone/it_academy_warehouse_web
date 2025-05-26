import React from 'react'
import BtnCheckControl from './btnCheckControl/BtnCheckControl'
import BtnCheckPackage from './btnCheckPackage/BtnCheckPackage'
import BtnPrintCertificate from './btnPrintCertificate/BtnPrintCertificate'
import BtnCancelSign from "./btnCancelSign/BtnCancelSign.tsx";

const Buttons = () => {
return (
    <div className='button-container'>
        <BtnCancelSign/>
        <BtnCheckControl />
        <BtnCheckPackage />
        <BtnPrintCertificate />
    </div>
)
}

export default Buttons
