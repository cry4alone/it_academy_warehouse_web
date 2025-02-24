import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import axios from 'axios';

const TableWorkInProgress = () => {
    const [dataSource, setDataSource] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios
            .get('http://localhost:3000/workInProgress')
            .then((response) => {
                const workInProgress = response.data.map((item) => ({ ...item, key: item.id }));
                setDataSource(workInProgress);
            })
            .catch((err) => {
                console.log('Error fetching data:', err);
            })
            .finally(() => {
                setLoading(false);
            });
        // const fetchData = async () => {
        //     try {
        //         const response = await fetch('http://localhost:3000/workInProgress');
        //         const data = await response.json();
        //         const workInProgress = data.map(item => ({ ...item, key: item.id }));
        //         setDataSource(workInProgress);
        //     } catch (error) {
        //         console.error('Error fetching data:', error);
        //     } finally {
        //         setLoading(false);
        //     }
        // };

        // fetchData();
    }, []);

    const columns = [
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
            sorter: (a, b) => new Date(a.date) - new Date(b.date),
        },
        {
            title: '№ статус',
            dataIndex: 'status',
            key: 'status',
        },
        {
            title: 'Длина',
            dataIndex: 'length',
            key: 'length',
            sorter: (a, b) => a.length - b.length,
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
            onFilter: (value, item) => item.length === value,
        },
        {
            title: 'Спецификация',
            dataIndex: 'specification',
            key: 'specification',
            filters: [
                {
                    text: 'ГОСТ 11089-2019',
                    value: 'ГОСТ 11089-2019',
                },
                {
                    text: 'ГОСТ 11059-2019',
                    value: 'ГОСТ 11059-2019',
                },
                {
                    text: 'ГОСТ 4784-97',
                    value: 'ГОСТ 4784-97',
                },
            ],
            onFilter: (value, item) => item.specification.includes(value),
        },
        {
            title: 'Марка',
            dataIndex: 'brand',
            key: 'brand',
            filters: [
                {
                    text: 'A8',
                    value: 'A8',
                },
                {
                    text: '1915',
                    value: '1915',
                },
                {
                    text: 'D16',
                    value: 'D16',
                },
            ],
            onFilter: (value, item) => item.brand.includes(value),
        },
        {
            title: '№ сертификата',
            dataIndex: 'certificateNumber',
            key: 'certificateNumber',
        },
        {
            title: 'Секция',
            dataIndex: 'section',
            key: 'section',
            sorter: (a, b) => a.section - b.section,
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
            onFilter: (value, item) => item.controlScheme.includes(value),
        },
        {
            title: 'Материал',
            dataIndex: 'material',
            key: 'material',
            filters: [
                {
                    text: 'Жидкий',
                    value: 'Жидкий',
                },
                {
                    text: 'Твёрдый',
                    value: 'Твёрдый',
                },
            ],
            onFilter: (value, item) => item.material.includes(value),
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

export default TableWorkInProgress;
