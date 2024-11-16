import React from 'react';
import { Layout, theme } from 'antd';
import RusalLogo from '../shared/assets/Русал.svg';

const { Header } = Layout;

const HeaderComponent = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();

  return (
    <Header
      style={{
        display: 'flex',
        justifyContent: 'space-between',
        alignItems: 'center',
        padding: '0 16px',
        background: colorBgContainer,
      }}
    >
      <div style={{ display: 'flex', alignItems: 'center' }}>
        <img src={RusalLogo} alt="Русал" style={{ height: '40px', marginRight: '16px' }} />
      </div>
      <div style={{ display: 'flex', alignItems: 'center' }}>
        <h1 style={{ margin: 0 }}>Header</h1>
      </div>
    </Header>
  );
};

export default HeaderComponent;
