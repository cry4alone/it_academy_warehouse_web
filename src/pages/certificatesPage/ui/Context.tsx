import React, { createContext, useState, useContext, useMemo } from 'react';

const DefaultProps = createContext<any>({} as any);

interface IProps {
    children: React.ReactNode;
}

export const CertificateProvider = (props: IProps) => {
    const { children } = props;
    const [certificates, setCertificates] = useState<any[]>([]);

    const defaultProps = useMemo(
        () => ({
            certificates,
            setCertificates
        }),
        [certificates]
    );

    return (
        <DefaultProps.Provider value={defaultProps}>
            {children}
        </DefaultProps.Provider>
    );
};

export const useDefaultPropsContext = () => useContext(DefaultProps);