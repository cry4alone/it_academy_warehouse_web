import React, { createContext, useState, useContext } from 'react';


interface IPrintContextType {
    selectedPrinter: string | null;
    selectedLabel: string | null;
    setSelectedPrinter: (printer: string | null) => void;
    setSelectedLabel: (label: string | null) => void;
    isPrinterAndLabelSelected: boolean;
}

const PrintContext = createContext<IPrintContextType | undefined>(undefined);

export const PrintProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [selectedPrinter, setSelectedPrinter] = useState<string | null>(null);
    const [selectedLabel, setSelectedLabel] = useState<string | null>(null);

    const isPrinterAndLabelSelected = !!selectedPrinter && !!selectedLabel;

    return (
        <PrintContext.Provider
            value={{
                selectedPrinter,
                selectedLabel,
                setSelectedPrinter,
                setSelectedLabel,
                isPrinterAndLabelSelected,
            }}
        >
            {children}
        </PrintContext.Provider>
    );
};

export const usePrintContext = () => {
    const context = useContext(PrintContext);
    if (!context) {
        throw new Error('usePrintContext must be used within a PrintProvider');
    }
    return context;
};