import React, { createContext, useState, useContext, useMemo } from 'react';

const WorkInProgress = createContext<any>({} as any);
const SelectedData = createContext<any>({} as any);
const SelectedRows = createContext<any>({} as any);
const DefaultProps = createContext<any>({} as any);

interface IProps {
  children: React.ReactNode;
}

export const WorkInProgressProvider = (props: IProps) => {
  const { children } = props;
  const [workInProgress, setWorkInProgress] = useState<any[]>([]);
  const [selectedRows, setSelectedRows] = useState<any>({});
  const [selectedData, setSelectedData] = useState<any[]>([]);

  const defaultProps = useMemo(
    () => ({
      setWorkInProgress,
      setSelectedRows,
      setSelectedData,
    }),
    []
  );

  return (
    <WorkInProgress.Provider value={workInProgress}>
      <SelectedData.Provider value={selectedData}>
        <SelectedRows.Provider value={selectedRows}>
          <DefaultProps.Provider value={defaultProps}>{children}</DefaultProps.Provider>
        </SelectedRows.Provider>
      </SelectedData.Provider>
    </WorkInProgress.Provider>
  );
};

export const useWorkInProgressContext = () => useContext(WorkInProgress);
export const useSelectedDataContext = () => useContext(SelectedData);
export const useSelectedRowsContext = () => useContext(SelectedRows);
export const useDefaultPropsContext = () => useContext(DefaultProps);