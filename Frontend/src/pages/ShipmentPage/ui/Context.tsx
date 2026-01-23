import React, { createContext, useState, useContext, useMemo } from 'react';
import { IShipmentData } from '../types/shipmentTypes';

const DefaultPropsContext = createContext<IDefaultProps | undefined>(undefined);
const shipmentsContext = createContext<IShipmentData[] | undefined>(undefined);
const selectedDataContext = createContext<IShipmentData[] | undefined>(undefined);

interface IProps {
    children: React.ReactNode;
}

interface IDefaultProps {
    setShipments: React.Dispatch<React.SetStateAction<IShipmentData[]>>;
    setSelectedData: React.Dispatch<React.SetStateAction<IShipmentData[]>>;
}

export const ShipmentProvider = (props: IProps) => {
    const { children } = props;
    const [shipments, setShipments] = useState<IShipmentData[]>([]);
    const [selectedData, setSelectedData] = useState<IShipmentData[]>([]);

    const defaultProps = useMemo(
        () => ({
            setShipments,
            setSelectedData
        }),
        []
    );

    return (
        <selectedDataContext.Provider value={selectedData}>
            <shipmentsContext.Provider value={shipments}>
                <DefaultPropsContext.Provider value={defaultProps}>{children}</DefaultPropsContext.Provider>
            </shipmentsContext.Provider>
        </selectedDataContext.Provider>
    );
};

export const useDefaultPropsContext = (): IDefaultProps => {
    const defaultProps = useContext(DefaultPropsContext);
    if (!defaultProps) throw new Error('useDefaultPropsContext must be used within a ShipmentProvider');
    return defaultProps;
};

export const useShipmentContext = () => {
    const context = useContext(shipmentsContext);
    if (!context) {
        throw new Error('useShipmentContext must be used within a ShipmentProvider');
    }
    return context;
};

export const useSelectedDataContext = (): IShipmentData[] => {
    const context = useContext(selectedDataContext);
    if (!context) {
        throw new Error('useSelectedDataContext must be used within a ShipmentProvider');
    }
    return context;
};
