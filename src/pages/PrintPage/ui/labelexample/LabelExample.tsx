import React from 'react';
import label from './label.svg';
import './style.scss';

const LabelExample = () => {
  return (
    <div>
        <h3>Пример выбранных этикеток</h3>
        <img src={label} alt="Label" />
    </div>
  )
}

export default LabelExample
