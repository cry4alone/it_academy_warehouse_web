import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import axios from 'axios';
import { ColumnProps } from 'antd/es/table'

const TableReadyProduction = () => {
    const [dataSource, setDataSource] = useState<item[]>([]);
    const [loading, setLoading] = useState(true);

    interface item {
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
        key?: number;
    }

    useEffect(() => {
        axios
            .get('http://localhost:3000/readyProduction')
            .then((response) => {
                const readyProduction = response.data.map((item: item) => ({
                    ...item,
                    key: item.id,
                }));
                setDataSource(readyProduction);
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
            })
            .finally(() => {
                setLoading(false);
            });

        // const fetchData = async () => {
        //     try {
        //         const response = await fetch('http://localhost:3000/readyProduction');
        //         const data = await response.json();
        //         const readyProduction = data.map(item => ({ ...item, key: item.id }));
        //         setDataSource(readyProduction);
        //     } catch (error) {
        //         console.error('Error fetching data:', error);
        //     } finally {
        //         setLoading(false);
        //     }
        // };

        // fetchData();
    }, []);

    const columns: ColumnProps<item>[] = [
        {
            title: '№ плавки',
            dataIndex: 'meltNumber',
            key: 'meltNumber',
        },
        {
            title: '№ пакета',
            dataIndex: 'packageNumber',
            key: 'packageNumber',
            sorter: (a: item, b: item) => a.packageNumber - b.packageNumber,
        },
        {
            title: 'Дата',
            dataIndex: 'date',
            key: 'date',
            sorter: (a: item, b: item) => new Date(a.date).getDate() - new Date(b.date).getDate(),
        },
        {
            title: 'Схема контроля',
            dataIndex: 'controlScheme',
            key: 'controlScheme',
            filters: [
                {
                    text: 'ГОСТ 11059-2019',
                    value: 'ГОСТ 11059-2019',
                },
                {
                    text: 'ГОСТ 11069-2001',
                    value: 'ГОСТ 11069-2001',
                },
                {
                    text: 'ГОСТ 4784-2019',
                    value: 'ГОСТ 4784-2019',
                },
            ],
            //onFilter: (value: string | number, item: item) => item.controlScheme.includes(value),
        },
        {
            title: 'Нетто, кг',
            dataIndex: 'net',
            key: 'net',
            sorter: (a: item, b: item) => a.net - b.net,
        },
        {
            title: 'Брутто, кг',
            dataIndex: 'gross',
            key: 'gross',
            sorter: (a: item, b: item) => a.gross - b.gross,
        },
        // {
        //     title: 'Упаковка',
        //     dataIndex: 'package',
        //     key: 'package',
        //     filters: [
        //         {
        //             text: 'Плёнка',
        //             value: 'Плёнка',
        //         },
        //         {
        //             text: 'Картон',
        //             value: 'Картон',
        //         },
        //         {
        //             text: 'Деревянный ящик',
        //             value: 'Деревянный ящик',
        //         },
        //         {
        //             text: 'Металлический контейнер',
        //             value: 'Металлический контейнер',
        //         },
        //     ],
        //     onFilter: (value: string, item: item) => item.package.includes(value),
        // },
        // {
        //     title: 'Вес упаковки',
        //     dataIndex: 'packageWeight',
        //     key: 'packageWeight',
        // },
        {
            title: 'Длина',
            dataIndex: 'length',
            key: 'length',
            sorter: (a: item, b: item) => a.length - b.length,
            filters: [
                {
                    text: '10',
                    value: 10,
                },
                {
                    text: '15',
                    value: 15,
                },
                {
                    text: '20',
                    value: 20,
                },
            ],
            //onFilter: (value: number, item: item) => item.length === value,
        },
        // {
        //     title: 'Комментарий',
        //     dataIndex: 'comment',
        //     key: 'comment',
        // },
    ];

    return (
        <Table
            rowSelection={{
                type: 'checkbox',
            }}
            dataSource={dataSource}
            columns={columns}
            scroll={{ x: 'max-content' }}
            loading={loading}
        />
    );
};

export default TableReadyProduction;
