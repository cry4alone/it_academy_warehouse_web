import React, { Component } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom"; // Используем BrowserRouter
import Header from "./header/Header";
import Auth from "../pages/Auth";
import NotFoundPage from "../pages/NotFoundPage";
import ReadyProduction from "../pages/ReadyProduction";
import "../styles/global.scss";

class App extends Component {
    render() {
        return (
            <BrowserRouter>
                <Header />
                <Routes>
                    <Route index element={<Auth />} /> 
                    <Route path="/auth" element={<Auth />} />
                    <Route path="*" element={<NotFoundPage />} /> 
                    <Route path="/ReadyProduction" element={<ReadyProduction />} />
                </Routes>
            </BrowserRouter>
        );
    }
}

export default App;
