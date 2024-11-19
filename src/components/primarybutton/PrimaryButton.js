import React from "react";
import "./PrimaryButton.scss";

const PrimaryButton = ({ onClick, children, type = "button" }) => {
  return (
    <button className="primarybutton" onClick={onClick} type={type}>
      {children}
    </button>
  );
};

export default PrimaryButton;
