import axios from "axios";
import { IInvoiceData } from "../types/invoiceTypes";

export const fetchInvoices = async (): Promise<IInvoiceData[]> => {
    try {
        const response = await axios.get('http://localhost:3000/invoice');
        return response.data;
    } catch (error) {
        console.error('Error fetching invoices:', error);
        throw error;
    }
};