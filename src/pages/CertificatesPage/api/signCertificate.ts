import axios from 'axios';
import { ICertificateData } from '../types/certificateTypes';

export const signCertificate = async (certificateId: string, signatory: string) => {
    try {
        const prevData = await axios.get(`http://localhost:3000/certificates/${certificateId}`);
        if (!prevData.data) {
            throw new Error('Certificate not found');
        }

        const response = await axios.put(`http://localhost:3000/certificates/${certificateId}`, {
            ...prevData.data,
            signatory, 
        }); // later change to /certificates/sign/:id
        return response.data;
    } catch (error) {
        console.error('Error signing Certificate:', error);
        throw error;
    }
};
