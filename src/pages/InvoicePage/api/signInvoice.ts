import axios from 'axios';
import { IInvoiceData } from '../types/invoiceTypes';

export const signInvoice = async (invoice: IInvoiceData[], items: any[]) => {
    console.log(invoice);
    console.log(items);

    try {
        await Promise.all(
            items.map(async (item) => {
                const id = item.id;
                await axios.delete(`http://localhost:3000/readyProduction/${id}`);
            })
        );
    } catch (error) {
        console.error('Error signing invoice:', error);
    }

    // вернуть столбец в НЗП, который отменили
};
