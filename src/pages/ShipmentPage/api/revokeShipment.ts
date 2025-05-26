import axios from 'axios';
import { IRevokedShipment } from '../types/revokeShipmentType.ts';
import {IShipmentData} from "../types/shipmentTypes.ts";

export const revokeShipment = async (params: {
    shipments: IShipmentData[];
    reason: string;
    revokedAt: string; // ISO string
}): Promise<void> => {
    try {
        // Создаем записи о сторнировании
        const revokedPromises = params.shipments.map(shipment =>
            axios.post<IRevokedShipment>('http://localhost:3000/revokedShipments', {
                shipmentNumber: shipment.shipmentNumber,
                originalData: shipment,
                reason: params.reason,
                revokedAt: params.revokedAt,
                revokedBy: 'current_user' // Можно получить из контекста/авторизации
            })
        );

        // Удаляем оригинальные отгрузки
        const deletePromises = params.shipments.map(shipment =>
            axios.delete(`http://localhost:3000/shipment/${shipment.id}`)
        );

        await Promise.all([...revokedPromises, ...deletePromises]);
    } catch (error) {
        console.error('Revoke error:', error);
        throw new Error('Failed to revoke shipments');
    }
};