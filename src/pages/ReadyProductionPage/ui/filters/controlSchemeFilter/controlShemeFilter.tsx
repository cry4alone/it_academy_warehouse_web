import React, {useEffect, useState} from "react";
import {fetchControlSchemes} from "../../../api/fetchControlScheme.ts";
import {AutoComplete} from "antd";
import {useFiltersContext} from "../../Context.tsx";

const ControlShemeFilter = () =>{
    const [controlSchemes, setControlSchemes] = useState<string[] | undefined>([]);
    const {filters, setFilters} = useFiltersContext();
    const handleSelectedSchemeChange = (value) => {

        setFilters(prev => ({
            ...prev,
            controlScheme: value
        }));

    };

    useEffect(() => {
        fetchControlSchemes().then(schemes => setControlSchemes(schemes));
    }, []);

    return(
        <AutoComplete
            style={{ width: 250 }}
            options={controlSchemes?.map(scheme => ({ value: scheme }))}
            placeholder="Выберите схему контроля"
            filterOption={(inputValue, option) =>
                option!.value.toUpperCase().indexOf(inputValue.toUpperCase()) !== -1
            }
            onChange={(value) => {handleSelectedSchemeChange(value); }}
            onSelect={(value: string) => handleSelectedSchemeChange(value)}
            onClear={() => handleSelectedSchemeChange('')}
            allowClear
        />
    )
}
export default ControlShemeFilter;