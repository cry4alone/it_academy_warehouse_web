import React, { createContext, useState, useContext, useMemo } from 'react';
import '../types/certificateTypes'
import { ICertificateData } from '../types/certificateTypes';


const Certificate = createContext<ICertificateData[] | undefined>(undefined);
const SelectedData = createContext<ICertificateData[] | undefined>(undefined);

interface IDefaultProps {
    setCertificates: React.Dispatch<React.SetStateAction<ICertificateData[]>>;
    setSelectedData: React.Dispatch<React.SetStateAction<ICertificateData[]>>;
}

const DefaultProps = createContext<IDefaultProps | undefined>(undefined);

interface IProps {
    children: React.ReactNode;
}

export const CertificateProvider = (props: IProps) => {
    const { children } = props;
    const [certificates, setCertificates] = useState<ICertificateData[]>([]);
    const [selectedData, setSelectedData] = useState<ICertificateData[]>([]);

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


export const useCertificateContext = () => {
    const certificates = useContext(Certificate);
    if (!certificates) throw new Error('useCertificateContext must be used within a CertificateProvider');
    return certificates;
};
export const useSelectedDataContext = () => {
    const selectedData = useContext(SelectedData);
    if (!selectedData) throw new Error('useSelectedDataContext must be used within a CertificateProvider');
    return selectedData;
};
export const useDefaultPropsContext = (): IDefaultProps => {
    const context = useContext(DefaultProps);
    if (!context) {
        throw new Error('useDefaultPropsContext must be used within an InvoiceProvider');
    }
    return context;
};
