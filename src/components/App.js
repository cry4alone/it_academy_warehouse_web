import React, { Component } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom"; // Используем BrowserRouter
import Header from "./Header";
import Footer from "./Footer";
import Auth from "../pages/Auth";
import NotFoundPage from "../pages/NotFoundPage";

class App extends Component {
    render() {
        return (
            <BrowserRouter>
                <Header />
                <Routes>
                    <Route index element={<Auth />} /> 
                    <Route path="/auth" element={<Auth />} />
                    <Route path="*" element={<NotFoundPage />} /> 
                </Routes>
                <Footer />
            </BrowserRouter>
        );
    }
}

export default App;
