import axios from "axios";
import { ICertificateData } from "../types/certificateTypes";

export const cancelCertificate = async (certificateId: string) => {
    if (!certificateId) {
        throw new Error('Certificate ID is required');
    }

    try {
        const response = await axios.delete(
            `http://localhost:3000/certificates/${certificateId}`
        );
        return response.data;
    } catch (error) {
        console.error('Delete error:', {
            url: `http://localhost:3000/certificates/${certificateId}`,
            error: error instanceof Error ? error.message : error
        });
        throw error;
    }
};