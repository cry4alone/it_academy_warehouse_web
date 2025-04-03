import React, { createContext, useState, useContext } from 'react';

const ReadyContext = createContext<any>({} as any);
const SelectedDataContext = createContext<any>({} as any);
const SelectedRowsContext = createContext<any>({} as any);

interface IProps {
    children: React.ReactNode;
}

export const ReadyProvider = (props: IProps) => {
    const { children } = props;

    const [readys, setReadys] = useState<any[]>([]);

    const [selectedRows, setSelectedRows] = useState<any[]>([]);

    const [selectedData, setSelectedData] = useState<any[]>([]);

    return (
        <ReadyContext.Provider value={{ readys, setReadys }}>
            <SelectedDataContext.Provider value={{ selectedData, setSelectedData }}>
                <SelectedRowsContext.Provider value={{ selectedRows, setSelectedRows }}>
                    {children}
                </SelectedRowsContext.Provider>
            </SelectedDataContext.Provider>
        </ReadyContext.Provider>
    );
};

export const useReadyContext = () => useContext(ReadyContext);
export const useSelectedDataContext = () => useContext(SelectedDataContext);
export const useSelectedRowsContext = () => useContext(SelectedRowsContext);