import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import axios from 'axios';
import { ColumnsType } from 'antd/es/table';

interface Item {
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
    package?: string;
    packageWeight?: number;
    comment?: string;
}

interface TableReadyProductionProps {
    onSelectionChange: (selectedRowKeys: React.Key[], selectedData: Item[] ) => void;
}

const TableReadyProduction: React.FC<TableReadyProductionProps> = ({ onSelectionChange }) => {
    const [dataSource, setDataSource] = useState<Item[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios
            .get('http://localhost:3000/readyProduction')
            .then((response) => {
                const readyProduction = response.data.map((item: Item) => ({
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
    }, []);

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
        <Table
            rowSelection={{
                type: 'checkbox',
                onChange: onSelectionChange,
            }}
            dataSource={dataSource}
            columns={columns}
            scroll={{ x: 'max-content' }}
            loading={loading}
        />
    );
};

export default TableReadyProduction;
