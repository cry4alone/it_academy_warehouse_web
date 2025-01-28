import React, { createContext, useState, useContext } from "react";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
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

// export default Context

// import React from 'react';

// const SelectionData = React.createReact<string>({} as string);

// type IDefaultProps = {
// 	setState: ISetState<string>
// }
// const DefaultProps = React.createReact<string>({} as string);

// const [state, setState] = useState('');

// const defaultProps = useMemo(() => ({
// 	setState,
// }), []);

// <DefaultProps.Provider value={defaultProps}>
// 	<SelectionData.Provider value={state}>
// 		{children}
// 	</SelectionData.Provider>
// </DefaultProps.Provider>

// export const useContextDefaultProps = React.useContext(defaultProps);
