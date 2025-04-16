import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import axios from 'axios';
import { ColumnsType } from 'antd/es/table';


interface Item {
    id: number;
    idClient: number;
    customer: string;
    size?: string;
    specification: string;
    typeDelivery: string;
    idDelivary: number;
    
}

interface TableOrderProps {
    selectedDeliveryNumber: number | null;
    onSelectionChange: (selectedRowKeys: React.Key[], selectedRows: any[]) => void;
}

const OrderTable: React.FC<TableOrderProps> = ({ selectedDeliveryNumber, onSelectionChange }) => {
    const [dataSource, setDataSource] = useState<Item[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios
            .get('http://localhost:3000/nzpCreateCertificateOrder')
            .then((response) => {
                const orders = response.data.map((item: Item) => ({
                    ...item,
                    key: item.id,
                }));
                setDataSource(orders);
            })
            .catch((error) => {
                console.error('Error fetching data: ', error);
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);

     // Фильтрация данных по номеру поставки
     const filteredData = selectedDeliveryNumber
     ? dataSource.filter((item) => item.idDelivary === selectedDeliveryNumber)
     : dataSource;

    const columns: ColumnsType<Item> = [
        {
            title: '№ клиента',
            dataIndex: 'idClient',
            key: 'idClient', 
        },
        {
            title: 'Заказчик',
            dataIndex: 'customer',
            key: 'customer', 
        },
        {
            title: 'Размер',
            dataIndex: 'size',
            key: 'size', 
        },
        {
            title: 'Спецификация',
            dataIndex: 'specification',
            key: 'specification', 
        },
        {
            title: 'Тип доставки',
            dataIndex: 'typeDelivery',
            key: 'typeDelivery', 
        },
        {
            title: '№ поставки',
            dataIndex: 'idDelivary',
            key: 'idDelivary', 
        },
    ];

    return (
        <Table 
            className='table'
            rowSelection={{
                type: 'radio',
                onChange: onSelectionChange,
            }}
            dataSource={filteredData}
            columns={columns}
            scroll={{x: 'max-content'}}
            loading={loading}
            />
    );

};

export default OrderTable;