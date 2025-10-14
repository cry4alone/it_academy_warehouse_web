import axios from "axios";
import { WorkInProgressData } from "../types/workInProgressTypes";

export const fetchWork = async (): Promise<WorkInProgressData[]> => {
    try {
        const response = await axios.get('http://localhost:3000/workInProgress');
        return response.data;
    } catch (error) {
        console.error('Error fetching workInProgress:', error);
        throw error;
    }
};