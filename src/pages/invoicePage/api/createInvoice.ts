import axios from "axios";
import { IInvoiceData } from '../types/invoiceTypes';

export const createInvoice = async (data: IInvoiceData) => {
    try {
        const response = await axios.post('http://localhost:3000/invoice', data);
        return response.data;
    }
    catch (error) {
        console.error('Error creating invoice:', error);
    }
}