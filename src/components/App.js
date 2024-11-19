import React, { Component } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom"; // Используем BrowserRouter
import Layout from "./layout/layout";
import Auth from "../pages/Auth";
import NotFoundPage from "../pages/NotFoundPage";
import ReadyProduction from "../pages/ReadyProduction";
import "../styles/global.scss";

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Auth />} />
            <Route path="auth" element={<Auth />} />
            <Route path="*" element={<NotFoundPage />} />
            <Route path="ReadyProduction" element={<ReadyProduction />} />
          </Route>
        </Routes>
      </BrowserRouter>
    );
  }
}

export default App;
