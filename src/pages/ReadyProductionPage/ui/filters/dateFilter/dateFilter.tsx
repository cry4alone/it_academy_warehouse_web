import { DatePicker } from "antd";
import React from "react";
import { useFiltersContext } from "../../Context.tsx";

const DateFilter = () => {
    const { filters, setFilters } = useFiltersContext();

    const handleDateFromChange = (date: any, dateString: string | string[]) => {
        console.log(filters)
        setFilters(prev => ({
            ...prev,
            dateFrom: Array.isArray(dateString) ? dateString[0] : dateString || undefined
        }));
        console.log(filters)
    };

    const handleDateToChange = (date: any, dateString: string | string[]) => {
        setFilters(prev => ({
            ...prev,
            dateTo: Array.isArray(dateString) ? dateString[0] : dateString || undefined
        }));
    };

    return (
        <div>
            Дата:
            От <DatePicker id="DateFrom" onChange={handleDateFromChange} />
            До <DatePicker id="DateTo" onChange={handleDateToChange} />
        </div>
    );
};

export default DateFilter;