import axios from "axios";
import { IReadyData } from "../types/readyTypes";

export const fetchReady = async (): Promise<IReadyData[]> => {
    try {
        const response = await axios.get('http://localhost:3000/readyProduction');
        return response.data;
    } catch (error) {
        console.error('Error fetching ready:', error);
        return []; 
    }
};