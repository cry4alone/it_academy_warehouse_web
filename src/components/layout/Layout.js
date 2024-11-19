import React from "react";
import Header from "../header/Header";
import Sidebar from "../sidebar/Sidebar";
import "./layout.scss";
import { Outlet } from "react-router-dom";

const Layout = () => {
  return (
    <div className="layout">
      <Header />
      <div className="layout-content">
        <Sidebar />
        <main className="layout-main">
          <Outlet />
        </main>
      </div>
    </div>
  );
};

export default Layout;
