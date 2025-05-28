import React from "react";
import DateFilter from "./dateFilter/dateFilter.tsx";
import ControlShemeFilter from "./controlSchemeFilter/controlShemeFilter.tsx";
import {useFiltersContext} from "../Context.tsx";
import '../style.scss'

const Filters = ()=>{
    const {filters } = useFiltersContext()

    return (
        <div className='filter' style={{display: "flex", justifyContent: "space-between"}}>
            <DateFilter/>
            <ControlShemeFilter/>
        </div>
    )
}

export default Filters;