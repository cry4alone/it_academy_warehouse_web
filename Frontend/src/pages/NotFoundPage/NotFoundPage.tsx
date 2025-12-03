import React from 'react';
import { Typography } from 'antd';

export const NotFoundPage = () => {
    const { Title } = Typography;
  return (
    <div className='pageNotFound'>
      <Title>404 - Страница не найдена</Title>
    </div>
  );
};

