import axios from "axios";
import { InvoiceData } from "../types/invoiceTypes";

export const fetchInvoices = async (): Promise<InvoiceData[]> => {
    try {
        const response = await axios.get('http://localhost:3000/invoice');
        return response.data;
    } catch (error) {
        console.error('Error fetching invoices:', error);
        throw error;
    }
};