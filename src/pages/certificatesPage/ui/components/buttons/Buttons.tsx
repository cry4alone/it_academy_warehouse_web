import React from 'react'
import BtnCheckControl from './btnCheckControl/BtnCheckControl'
import BtnCheckPackage from './btnCheckPackage/BtnCheckPackage'

const Buttons = () => {
return (
    <div className='button-container'>
        <BtnCheckControl />
        <BtnCheckPackage />
    </div>
)
}

export default Buttons
