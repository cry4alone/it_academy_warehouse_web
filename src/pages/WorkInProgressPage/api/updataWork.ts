import axios from "axios"
import { WorkInProgressData, ITableRow } from "../types/workInProgressTypes";

export const updataWork = async (rows: ITableRow[]) : Promise<void> => {
    try {
        rows.map(async (row) => {
            const rowData: WorkInProgressData = {
                id: row.key,
                meltNumber: row.meltNumber,
                packageNumber: row.packageNumber,
                date: row.date,
                status: row.status,
                length: row.length,
                specification: row.specification,
                brand: row.brand,
                certificateNumber: row.certificateNumber,
                section: row.section,
                controlScheme: row.controlScheme,
                material: row.material,
                net: row.net,
                gross: row.gross,
                isModified: row.isModified
            }
            await axios.put(`http://localhost:3000/workInProgress/${row.key}`, rowData);
        })
    } catch (error) {
        console.error('Error updating workInProgress:', error);
        throw error;
    }
};