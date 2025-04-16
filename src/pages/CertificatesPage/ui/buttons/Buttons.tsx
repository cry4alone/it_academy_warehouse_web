import React from 'react'
import BtnCheckControl from './btnCheckControl/BtnCheckControl'
import BtnCheckPackage from './btnCheckPackage/BtnCheckPackage'
import BtnPrintCertificate from './btnPrintCertificate/BtnPrintCertificate'

const Buttons = () => {
return (
    <div className='button-container'>
        <BtnCheckControl />
        <BtnCheckPackage />
        <BtnPrintCertificate />
    </div>
)
}

export default Buttons
