import React from "react";
import "./PrimaryButton.scss";

interface ButtonProps {
    type?: "button" | "submit" | "reset";
    children: React.ReactNode;
    onClick?: (event: React.MouseEvent<HTMLElement>) => void;
}

const PrimaryButton: React.FC<ButtonProps> = ({ onClick, children, type = "button" }) => {
  return (
    <button className="primarybutton" onClick={onClick} type={type}>
      {children}
    </button>
  );
};

export default PrimaryButton;
