import React from 'react';
import PropTypes from 'prop-types';
import './PrimaryButton.scss';

const PrimaryButton = ({ onClick, children, type = 'button' }) => {
  return (
    <button className="primarybutton" onClick={onClick} type={type}>
      {children}
    </button>
  );
};

PrimaryButton.propTypes = {
  onClick: PropTypes.func.isRequired,
  children: PropTypes.node.isRequired,
  type: PropTypes.string,
};

export default PrimaryButton;
