import axios from "axios";
import { IShipmentData } from "../types/shipmentTypes";

export const fetchShipment = async (): Promise<IShipmentData[]> => {
    try {
        const response = await axios.get('http://localhost:3000/shipment');
        return response.data;
    } catch (error) {
        console.error('Error fetching shipments:', error);
        throw error;
    }
};