import React from "react";
import "./PrimaryButton.scss";

const PrimaryButton = ({ onClick, children, type = "button" }) => {
  return (
    <button className="primarybutton" onClick={onClick} type={type}>
      {children}
    </button>
  );
};

<<<<<<< HEAD
=======


>>>>>>> 2e8bc9f6c349a4aebf3029c4b1996e1a22307544
export default PrimaryButton;
