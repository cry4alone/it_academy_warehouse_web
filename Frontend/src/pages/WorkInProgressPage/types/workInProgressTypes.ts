export interface ITableRow {
    key: string;
    meltNumber: string;
    packageNumber: number;
    date: string;
    status: string;
    length: number;
    specification: string;
    brand: string;
    certificateNumber: number;
    section: number;
    controlScheme: string;
    material: string;
    net: number;
    gross: number;
    isModified?: boolean;
}

export interface WorkInProgressData {
    id?: string;
    meltNumber: string;
    packageNumber: number;
    date: string;
    status: string;
    length: number;
    specification: string;
    brand: string;
    certificateNumber: number;
    section: number;
    controlScheme: string;
    material: string;
    net: number;
    gross: number;
    isModified?: boolean;
}

