import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Header from './components/header/Header';
import Auth from './pages/Auth';
import NotFoundPage from './pages/NotFoundPage';
import ReadyProduction from './pages/ReadyProduction';
import './styles/global.scss';

const App = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route index element={<Auth />} />
        <Route path="/auth" element={<Auth />} />
        <Route path="/ready-production" element={<ReadyProduction />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;
