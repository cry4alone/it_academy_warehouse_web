import React, { createContext, useState, useContext, useMemo } from 'react';
import { IFilters, IReadyData } from '../types/readyTypes';

// Создаем интерфейс для контекста фильтров
interface IFiltersContext {
    filters: IFilters;
    setFilters: React.Dispatch<React.SetStateAction<IFilters>>;
}

const ReadyContext = createContext<IReadyData[] | undefined>(undefined);
const SelectedDataContext = createContext<IReadyData[] | undefined>(undefined);
const SelectedRowsContext = createContext<string[] | undefined>(undefined);
const FiltersContext = createContext<IFiltersContext | undefined>(undefined);
const DefaultPropsContext = createContext<IDefaultProps | undefined>(undefined);

interface IProps {
    children: React.ReactNode;
}

interface IDefaultProps {
    setReadys: React.Dispatch<React.SetStateAction<IReadyData[]>>;
    setSelectedRows: React.Dispatch<React.SetStateAction<string[]>>;
    setSelectedData: React.Dispatch<React.SetStateAction<IReadyData[]>>;
}

export const ReadyProvider = (props: IProps) => {
    const { children } = props;

    const [readys, setReadys] = useState<IReadyData[]>([]);
    const [selectedRows, setSelectedRows] = useState<string[]>([]);
    const [selectedData, setSelectedData] = useState<IReadyData[]>([]);
    const [filters, setFilters] = useState<IFilters>({});

    const defaultProps = useMemo(() => ({
        setReadys,
        setSelectedRows,
        setSelectedData,
    }), []);

    // Создаем значение для контекста фильтров
    const filtersContextValue = useMemo(() => ({
        filters,
        setFilters
    }), [filters]);

    return (
        <ReadyContext.Provider value={readys}>
            <SelectedDataContext.Provider value={selectedData}>
                <SelectedRowsContext.Provider value={selectedRows}>
                    <FiltersContext.Provider value={filtersContextValue}>
                        <DefaultPropsContext.Provider value={defaultProps}>
                            {children}
                        </DefaultPropsContext.Provider>
                    </FiltersContext.Provider>
                </SelectedRowsContext.Provider>
            </SelectedDataContext.Provider>
        </ReadyContext.Provider>
    );
};

// Обновленный хук для фильтров
export const useFiltersContext = () => {
    const context = useContext(FiltersContext);
    if (!context) {
        throw new Error('useFiltersContext must be used within a ReadyProvider');
    }
    return context;
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
