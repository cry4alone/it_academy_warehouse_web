import React from "react";
import ReactDOM from "react-dom"; // Чистый react-dom не поддерживается
import App from "./components/App";
import 'antd/dist/reset.css';

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);