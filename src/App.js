import React, { Component } from "react";
import { ButtonProvider } from './contexts/ButtonContext';
import { BrowserRouter, Routes, Route } from "react-router-dom"; // Используем BrowserRouter
import Layout from "./components/layout/Layout";
import Auth from "./pages/Auth";
import NotFoundPage from "./pages/NotFoundPage";
import WorkInProgress from "./pages/WorkInProgress";
import ReadyProduction from "./pages/ReadyProduction";
import Certificates from "./pages/Certificates";
import Shipment from "./pages/Shipment";
import Invoice from "./pages/Invoice";
import Main from "./pages/Main";
import "./styles/global.scss";

class App extends Component {
render() {
    return (
    <ButtonProvider>
    <BrowserRouter>
        <Routes>
        <Route path="/" element={<Layout />}>
            <Route index element={<Auth />} />
            <Route path="home" element={<Main />} />
            <Route path="auth" element={<Auth />} />
            <Route path="nzp" element={<WorkInProgress />} />
            <Route path="gp" element={<ReadyProduction />} />
            <Route path="/documents/certificates" element={<Certificates />} />
            <Route path="/documents/shipment" element={<Shipment />} />
            <Route path="/documents/transfers" element={<Invoice />} />
            <Route path="*" element={<NotFoundPage />} />
        </Route>
        </Routes>
    </BrowserRouter>
    </ButtonProvider>
    );
}
}

export default App;
