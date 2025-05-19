import {IShipmentData} from "./shipmentTypes.ts";

export interface IRevokedShipment {
    id?: number; // Для json-server
    shipmentNumber: string;
    originalData: IShipmentData; // Полные данные оригинальной отгрузки
    revokedAt: string; // Дата в ISO формате
    reason: string;
    revokedBy?: string; // Опционально: кто выполнил сторно
}