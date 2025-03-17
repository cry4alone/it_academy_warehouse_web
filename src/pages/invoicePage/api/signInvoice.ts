import axios from "axios"
import { InvoiceData } from "../types/invoiceTypes";

export const signInvoice = async (invoice: InvoiceData[], items: any[] ) => {
    console.log(invoice);
    console.log(items);
    //logic for api call here
    
    //prob delete items from readyProd 
    //and add new row to table of returns
}