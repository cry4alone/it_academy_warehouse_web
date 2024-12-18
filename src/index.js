import React from "react";
import { createRoot } from "react-dom/client";
import App from "./App";
import "./styles/global.scss";
import { AuthProvider } from "./Context";

const container = document.getElementById("root");
const root = createRoot(container);
root.render(
  <React.StrictMode>
    <AuthProvider>
      <App />
    </AuthProvider>
  </React.StrictMode>
);
