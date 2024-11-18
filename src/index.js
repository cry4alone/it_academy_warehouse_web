import React from "react";
import ReactDOM from "react-dom"; // Чистый react-dom не поддерживается
import App from "./components/App";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);