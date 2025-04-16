import axios from "axios";
import { ICertificateData } from "../types/certificateTypes";

export const fetchCertificate = async (): Promise<ICertificateData[]> => {
    try {
        const response = await axios.get('http://localhost:3000/certificates');
        return response.data;
    } catch (error) {
        console.error('Error fetching Certificates:', error);
        throw error;
    }
};