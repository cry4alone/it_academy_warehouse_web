import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import { ColumnsType } from 'antd/es/table';
import { fetchReady } from '@/pages/ReadyProductionPage/api/fetchReady';
import {useDefaultPropsContext, useFiltersContext} from '../Context';
import {applyFilters} from "../filters/filterService/filterService.tsx";


export interface Item {
    id: number;
    meltNumber: string;
    packageNumber: number;
    date: string;
    status: string;
    length: number;
    specification: string;
    brand: string;
    certificateNumber: number;
    section: number;
    controlScheme: string;
    material: string;
    net: number;
    gross: number;
    package?: string;
    packageWeight?: number;
    comment?: string;
    key?: number;
}

export const transformReadyDataToItem = (data: any): Item => {
    return {
        id: Number(data.id) || 0,
        meltNumber: data.meltNumber,
        packageNumber: data.packageNumber,
        date: data.date,
        status: data.status,
        length: Number(data.length),
        specification: data.specification,
        brand: data.brand,
        certificateNumber: Number(data.certificateNumber),
        section: Number(data.section),
        controlScheme: data.controlScheme,
        material: data.material,
        net: Number(data.net),
        gross: Number(data.gross),
        package: undefined,
        packageWeight: undefined,
        comment: undefined,
    };
};

const TableReadyProduction: React.FC = () => {
    const [dataSource, setDataSource] = useState<Item[]>([]);
    const [loading, setLoading] = useState(true);
    const { setSelectedRows, setSelectedData } = useDefaultPropsContext();
    const {filters} = useFiltersContext()


    useEffect(() => {
        fetchReady({
            dateFrom: filters.dateFrom,
            dateTo: filters.dateTo,
            controlScheme: filters.controlScheme
        })
            .then((readyProduction) => {
                const filteredData = applyFilters(readyProduction, filters)
                const formattedData = filteredData.map(transformReadyDataToItem).map((item) => ({
                    ...item,
                    key: item.id,
                }));
                setDataSource(formattedData);

                console.log(dataSource)
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
            })
            .finally(() => {
                setLoading(false);
            });
    }, [filters]);



    const columns: ColumnsType<Item> = [
        {
            title: '№ плавки',
            dataIndex: 'meltNumber',
            key: 'meltNumber',
        },
        {
            title: '№ пакета',
            dataIndex: 'packageNumber',
            key: 'packageNumber',
            sorter: (a, b) => a.packageNumber - b.packageNumber,
        },
        {
            title: 'Дата',
            dataIndex: 'date',
            key: 'date',
            sorter: (a, b) => new Date(a.date).getTime() - new Date(b.date).getTime(),
        },
        {
            title: 'Схема контроля',
            dataIndex: 'controlScheme',
            key: 'controlScheme',
            filters: [
                { text: 'ГОСТ 11059-2019', value: 'ГОСТ 11059-2019' },
                { text: 'ГОСТ 11069-2001', value: 'ГОСТ 11069-2001' },
                { text: 'ГОСТ 4784-2019', value: 'ГОСТ 4784-2019' },
            ],
            onFilter: (value, record) => record.controlScheme.includes(value as string),
        },
        {
            title: 'Нетто, кг',
            dataIndex: 'net',
            key: 'net',
            sorter: (a, b) => a.net - b.net,
        },
        {
            title: 'Брутто, кг',
            dataIndex: 'gross',
            key: 'gross',
            sorter: (a, b) => a.gross - b.gross,
        },
        {
            title: 'Упаковка',
            dataIndex: 'package',
            key: 'package',
            filters: [
                { text: 'Плёнка', value: 'Плёнка' },
                { text: 'Картон', value: 'Картон' },
                { text: 'Деревянный ящик', value: 'Деревянный ящик' },
                { text: 'Металлический контейнер', value: 'Металлический контейнер' },
            ],
            onFilter: (value, record) => Boolean(record.package?.includes(value as string)),
        },
        {
            title: 'Вес упаковки',
            dataIndex: 'packageWeight',
            key: 'packageWeight',
        },
        {
            title: 'Длина',
            dataIndex: 'length',
            key: 'length',
            sorter: (a, b) => a.length - b.length,
            filters: [
                { text: '10', value: 10 },
                { text: '15', value: 15 },
                { text: '20', value: 20 },
            ],
            onFilter: (value, record) => record.length === value,
        },
        {
            title: 'Комментарий',
            dataIndex: 'comment',
            key: 'comment',
        },
    ];

    return (
        <>
            {/*<div className='filter'  style={{ display: "flex", justifyContent: "space-between"  }}>*/}
            {/*<div> Дата: */}
            {/*    От <DatePicker id="DateFrom" onChange={handleDateFromChange} /> - До <DatePicker id="DateTo" onChange={handleDateToChange} />*/}
            {/*</div>*/}
            {/*<AutoComplete*/}
            {/*        style={{ width: 250 }}*/}
            {/*        options={controlSchemes?.map(scheme => ({ value: scheme }))}*/}
            {/*        placeholder="Выберите схему контроля"*/}
            {/*        filterOption={(inputValue, option) =>*/}
            {/*            option!.value.toUpperCase().indexOf(inputValue.toUpperCase()) !== -1*/}
            {/*        }*/}
            {/*        onChange={(value) => {setSelectedScheme(value); console.log(selectedScheme)}}*/}
            {/*        onSelect={(value: string) => setSelectedScheme(value)} */}
            {/*        onClear={() => setSelectedScheme('')}*/}
            {/*        allowClear*/}
            {/*    />*/}
            {/*</div>*/}
           
            <Table
                rowSelection={{
                    type: 'checkbox',
                    onChange: (selectedRowKeys, selectedRows) => {
                        setSelectedRows(selectedRowKeys); 
                        setSelectedData(selectedRows); 
                    },
                }}
                dataSource={dataSource}
                columns={columns}
                scroll={{ x: 'max-content' }}
                loading={loading}
            />
        </>
    );
};

export default TableReadyProduction;