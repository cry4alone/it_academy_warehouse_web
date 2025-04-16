import React, { createContext, useState, useContext, useMemo } from 'react';
import { IReadyData } from '../types/readyTypes';

const ReadyContext = createContext<IReadyData[] | undefined>(undefined);
const SelectedDataContext = createContext<IReadyData[] | undefined>(undefined);
const SelectedRowsContext = createContext<string[] | undefined>(undefined);
const DefaultPropsContext = createContext<IDefaultProps | undefined>(undefined);

interface IProps {
    children: React.ReactNode;
}

interface IDefaultProps {
    setReadys: React.Dispatch<React.SetStateAction<any[]>>;
    setSelectedRows: React.Dispatch<React.SetStateAction<any[]>>;
    setSelectedData: React.Dispatch<React.SetStateAction<any[]>>;
}

export const ReadyProvider = (props: IProps) => {
    const { children } = props;

    const [readys, setReadys] = useState<any[]>([]);
    const [selectedRows, setSelectedRows] = useState<any[]>([]);
    const [selectedData, setSelectedData] = useState<any[]>([]);

    const defaultProps = useMemo(
        () => ({
            setReadys,
            setSelectedRows,
            setSelectedData,
        }),
        []
    );

    return (
        <ReadyContext.Provider value={readys}>
            <SelectedDataContext.Provider value={selectedData}>
                <SelectedRowsContext.Provider value={selectedRows}>
                    <DefaultPropsContext.Provider value={defaultProps}>{children}</DefaultPropsContext.Provider>
                </SelectedRowsContext.Provider>
            </SelectedDataContext.Provider>
        </ReadyContext.Provider>
    );
};

export const useReadyContext = () => {
    const readyProd = useContext(ReadyContext)
    if (!readyProd) {
        throw new Error('useReadyContext must be used within a ReadyProvider');
    }
    return readyProd;
};
export const useSelectedDataContext = () => {
    const selectedData = useContext(SelectedDataContext);
    if (!selectedData) throw new Error('useSelectedDataContext must be used within a ReadyProvider');
    return selectedData;
};
export const useSelectedRowsContext = () => {
    const selectedRows = useContext(SelectedRowsContext);
    if (!selectedRows) throw new Error('useSelectedRowsContext must be used within a ReadyProvider');
    return selectedRows;
};

export const useDefaultPropsContext = () => {
    const defaultProps = useContext(DefaultPropsContext);
    if (!defaultProps) throw new Error('useDefaultPropsContext must be used within a ReadyProvider');
    return defaultProps;
};
