import React, { createContext, useState, useContext, useMemo } from 'react';

const Certificate = createContext<any>({} as any);
const SelectedData = createContext<any>({} as any);
const DefaultProps = createContext<any>({} as any);

interface IProps {
    children: React.ReactNode;
}

export const CertificateProvider = (props: IProps) => {
    const { children } = props;
    const [certificates, setCertificates] = useState<any[]>([]);
    const [selectedData, setSelectedData] = useState<any[]>([]);

    const defaultProps = useMemo(
        () => ({
            setCertificates,
            setSelectedData
        }),
        []
    );

    return (
        <Certificate.Provider value={certificates}>
            <SelectedData.Provider value={selectedData}>
                <DefaultProps.Provider value={defaultProps}>{children}</DefaultProps.Provider>
            </SelectedData.Provider>
        </Certificate.Provider>
    );
};


export const useCertificateContext = () => useContext(Certificate);
export const useSelectedDataContext = () => useContext(SelectedData);
export const useDefaultPropsContext = () => useContext(DefaultProps);
