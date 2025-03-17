import axios from "axios";
import { InvoiceData } from '../types/invoiceTypes';

export const createInvoice = async (data: InvoiceData) => {
    try {
        const response = await axios.post('http://localhost:3000/invoice', data);
        return response.data;
    }
    catch (error) {
        console.error('Error creating invoice:', error);
    }
}