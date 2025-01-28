import React from "react";
<<<<<<< HEAD
import { createRoot } from "react-dom/client";
import App from "./App";
import "./styles/global.scss";
import { AuthProvider } from "./Context";
=======
import ReactDOM from "react-dom"; // Чистый react-dom не поддерживается
import App from "./components/App";
import 'antd/dist/reset.css';
>>>>>>> 78c94d6e93668807d0c55491bc45785a66493e04

const container = document.getElementById("root");
const root = createRoot(container);
root.render(
  <React.StrictMode>
    <AuthProvider>
      <App />
    </AuthProvider>
  </React.StrictMode>
);
