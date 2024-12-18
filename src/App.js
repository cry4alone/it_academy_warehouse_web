import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Auth from "./pages/Auth";
import NotFoundPage from "./pages/NotFoundPage";
import ReadyProduction from "./pages/ReadyProduction";
import "./styles/global.scss";
import Layout from "./components/layout/Layout";

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Auth />} />
          <Route path="auth" element={<Auth />} />
          <Route path="ReadyProduction" element={<ReadyProduction />} />
          <Route path="*" element={<NotFoundPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default App;
