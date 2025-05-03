import React, { createContext, useState, useContext } from "react";

//inteface user

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState();
  // const defaultProps = useMemo(
  //   () => ({
  //     setState,
  //   }),
  //   []
  // );
  return (
    <AuthContext.Provider value={{ user, setUser }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);

