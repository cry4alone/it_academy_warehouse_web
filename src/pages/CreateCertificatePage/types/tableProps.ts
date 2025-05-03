export interface Item {
    id: number;
    idClient: number;
    customer: string;
    size?: string;
    specification: string;
    typeDelivery: string;
    idDelivary: number;
};

export interface TableOrderProps {
    selectedDeliveryNumber: number | null;
    onSelectionChange: (selectedRowKeys: React.Key[], selectedRows: any[]) => void;
};