import React from "react";
import Header from "../header/header";
import Sidebar from "../sidebar/sidebar";
import "./layout.scss";
import { Outlet } from "react-router-dom";

const Layout = () => {
  return (
    <>
      <Header />
      <div className="mainlayout">
        <Sidebar />
        <div className="contentpage">
          <Outlet />
        </div>
      </div>
    </>
  );
};

export default Layout;
