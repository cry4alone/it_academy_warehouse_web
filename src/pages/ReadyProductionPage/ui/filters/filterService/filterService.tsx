import { IReadyData } from "../../../types/readyTypes";

export const applyFilters = (
    data: IReadyData[],
    filters: {
        dateFrom?: string;
        dateTo?: string;
        controlScheme?: string;
    }
): IReadyData[] => {
    let result = [...data];

    if (filters.dateFrom) {
        result = result.filter(item => item.date >= filters.dateFrom!);
    }

    if (filters.dateTo) {
        result = result.filter(item => item.date <= filters.dateTo!);
    }

    if (filters.controlScheme) {
        result = result.filter(item =>
            item.controlScheme.includes(filters.controlScheme!)
        );
    }

    return result;
};