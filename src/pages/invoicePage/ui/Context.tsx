import React, { createContext, useState, useContext, useMemo } from 'react';

//interface user

const Invoice = createContext<any>({} as any);
const SelectedData = createContext<any>({} as any);
const SelectedRows = createContext<any>({} as any);
const DefaultProps = createContext<any>({} as any);

interface IProps {
    children: React.ReactNode;
}

export const InvoiceProvider = (props: IProps) => {
    const { children } = props;
    const [invoices, setInvoices] = useState<any[]>([]);
    const [selectedRows, setSelectedRows] = useState<any>({});
    const [selectedData, setSelectedData] = useState<any[]>([]);

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

export const useInvoiceContext = () => useContext(Invoice);
export const useSelectedDataContext = () => useContext(SelectedData);
export const useSelectedRowsContext = () => useContext(SelectedRows);
export const useDefaultPropsContext = () => useContext(DefaultProps);
