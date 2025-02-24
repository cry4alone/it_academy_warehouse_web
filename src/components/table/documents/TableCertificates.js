import React, { useEffect, useState } from "react";
import { Table } from "antd";
import axios from "axios";

const TableCertificates = () => {
    const [dataSource, setDataSource] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios.get('http://localhost:3000/certificates')
        .then(response => {
            setDataSource(response.data.map(item => ({ ...item, key: item.id })));
        })
        .catch(err => {
            console.log('Error fetching data:', err);
        })
        .finally(
            setLoading(false)
        )
        // const fetchData = async () => {
        //     try {
        //         const response = await fetch('http://localhost:3000/certificates');
        //         const data = await response.json();
        //         const certificates = data.map(item => ({ ...item, key: item.id }));
        //         setDataSource(certificates);
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
            title: "№ сертификата",
            dataIndex: "certificateNumber",
            key: "certificateNumber",
            sorter: (a, b) => a.certificateNumber - b.certificateNumber,
        },
        {
            title: "Схема контроля",
            dataIndex: "controlScheme",
            key: "controlScheme",
            filters: [
                {
                    text: 'ГОСТ 11069-2024',
                    value: 'ГОСТ 11069-2024',
                },
                {
                    text: 'ГОСТ 11070-2024',
                    value: 'ГОСТ 11070-2024',
                },
                {
                    text: 'ГОСТ 11071-2024',
                    value: 'ГОСТ 11071-2024',
                },
            ],
            onFilter: (value, item) => item.controlScheme.includes(value),
        },
        {
            title: "Дата",
            dataIndex: "date",
            key: "date",
            sorter: (a, b) => new Date(a.date) - new Date(b.date),
        },
        {
            title: "Склад",
            dataIndex: "warehouse",
            key: "warehouse",
            filters: [
                {
                    text: 'Склад ГП-1',
                    value: 'Склад ГП-1',
                },
                {
                    text: 'Склад ГП-2',
                    value: 'Склад ГП-2',
                },
                {
                    text: 'Склад ГП-3',
                    value: 'Склад ГП-3',
                },
            ],
            onFilter: (value, item) => item.warehouse.includes(value),
        },
        {
            title: "Подписант",
            dataIndex: "signatory",
            key: "signatory",
            filters: [
                {
                    text: 'Шишкин Е. Н.',
                    value: 'Шишкин Е. Н.',
                },
                {
                    text: 'Кузнецов А. С.',
                    value: 'Кузнецов А. С.',
                },
                {
                    text: 'Иванова М. И.',
                    value: 'Иванова М. И.',
                },
                {
                    text: 'Петров В. В.',
                    value: 'Петров В. В.',
                },
                {
                    text: 'Смирнов О. Д.',
                    value: 'Смирнов О. Д.',
                },
            ],
            onFilter: (value, item) => item.signatory.includes(value),
        },
        {
            title: "Количество позиций",
            dataIndex: "countPosition",
            key: "countPosition",
            sorter: (a, b) => a.countPosition - b.countPosition,
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

export default TableCertificates;
