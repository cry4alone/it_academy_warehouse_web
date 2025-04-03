import React, { createContext, useState, useContext, useMemo } from 'react';

const DefaultProps = createContext<any>({} as any);

interface IProps {
    children: React.ReactNode;
}

export const ShipmentProvider = (props: IProps) => {
    const { children } = props;
    const [shipments, setShipments] = useState<any[]>([]);

    const defaultProps = useMemo(
        () => ({
            shipments,
            setShipments
        }),
        [shipments]
    );

    return (
        <DefaultProps.Provider value={defaultProps}>
            {children}
        </DefaultProps.Provider>
    );
};

export const useDefaultPropsContext = () => useContext(DefaultProps);