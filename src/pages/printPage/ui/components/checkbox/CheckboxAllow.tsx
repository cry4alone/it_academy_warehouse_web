import React from 'react';
import { Checkbox } from 'antd';
import type { CheckboxProps } from 'antd';

const onChange: CheckboxProps['onChange'] = (e) => {
  console.log(`checked = ${e.target.checked}`);
};

const CheckboxAllow = () => <Checkbox onChange={onChange}>Логотип ALLOW</Checkbox>;

export default CheckboxAllow;