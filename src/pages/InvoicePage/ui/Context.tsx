import React, { createContext, useState, useContext, useMemo, Key } from 'react';
import { IInvoiceData } from '../types/invoiceTypes';

interface IDefaultProps {
    setInvoices: React.Dispatch<React.SetStateAction<IInvoiceData[]>>;
    setSelectedRows: React.Dispatch<React.SetStateAction<Key[]>>;
    setSelectedData: React.Dispatch<React.SetStateAction<IInvoiceData[]>>;
}

const Invoice = createContext<IInvoiceData[] | undefined>(undefined);
const SelectedData = createContext<IInvoiceData[] | undefined>(undefined);
const SelectedRows = createContext<Key[] | undefined>(undefined);
const DefaultProps = createContext<IDefaultProps | undefined>(undefined);

interface IProps {
    children: React.ReactNode;
}

export const InvoiceProvider = (props: IProps) => {
    const { children } = props;

    const [invoices, setInvoices] = useState<IInvoiceData[]>([]);
    const [selectedRows, setSelectedRows] = useState<Key[]>([]);
    const [selectedData, setSelectedData] = useState<IInvoiceData[]>([]);

    const defaultProps = useMemo(
        () => ({
            setInvoices,
            setSelectedRows,
            setSelectedData,
        }),
        []
    );

    return (
        <Invoice.Provider value={invoices}>
            <SelectedData.Provider value={selectedData}>
                <SelectedRows.Provider value={selectedRows}>
                    <DefaultProps.Provider value={defaultProps}>{children}</DefaultProps.Provider>
                </SelectedRows.Provider>
            </SelectedData.Provider>
        </Invoice.Provider>
    );
};

export const useInvoiceContext = (): IInvoiceData[] => {
    const context = useContext(Invoice);
    if (!context) {
        throw new Error('useInvoiceContext must be used within an InvoiceProvider');
    }
    return context;
};

export const useSelectedDataContext = (): IInvoiceData[] => {
    const context = useContext(SelectedData);
    if (!context) {
        throw new Error('useSelectedDataContext must be used within an InvoiceProvider');
    }
    return context;
};

export const useSelectedRowsContext = (): Key[] => {
    const context = useContext(SelectedRows);
    if (!context) {
        throw new Error('useSelectedRowsContext must be used within an InvoiceProvider');
    }
    return context;
};

export const useDefaultPropsContext = (): IDefaultProps => {
    const context = useContext(DefaultProps);
    if (!context) {
        throw new Error('useDefaultPropsContext must be used within an InvoiceProvider');
    }
    return context;
};