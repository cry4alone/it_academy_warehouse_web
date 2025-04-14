import React from 'react';
import { Typography } from 'antd';

const NotFoundPage = () => {
    const { Title } = Typography;
  return (
    <div className='pageNotFound'>
      <Title>404 - Страница не найдена</Title>
    </div>
  );
};

export default NotFoundPage;
