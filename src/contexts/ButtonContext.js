import React, { createContext, useState } from 'react';

const ButtonContext = createContext();

const ButtonProvider = ({ children }) => {
  const [showAdditionalButtons, setShowAdditionalButtons] = useState(false);

  return (
    <ButtonContext.Provider value={{ showAdditionalButtons, setShowAdditionalButtons }}>
      {children}
    </ButtonContext.Provider>
  );
};

export { ButtonContext, ButtonProvider };
