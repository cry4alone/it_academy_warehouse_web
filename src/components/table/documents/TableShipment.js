import React from 'react';
import { Table } from 'antd';
import { dataShipment } from "../../data";

const dataSource = dataShipment.map(item => ({...item, key: item.id}));

const columns = [
    {
        title: '№ отгрузки',
        dataIndex: 'shipmentNumber',
        key: 'shipmentNumber',
    },
    {
        title: 'Дата',
        dataIndex: 'date',
        key: 'date',
        sorter: (a, b) => new Date(a.date) - new Date(b.date),
    },
    {
        title: 'Склад отправитель',
        dataIndex: 'warehouseSender',
        key: 'warehouseSender',
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
            {
                text: 'Склад ГП-4',
                value: 'Склад ГП-4',
            },
          ],
          onFilter: (value, item) => item.warehouseSender.includes(value),
    },
    {
        title: 'Подписант',
        dataIndex: 'signatory',
        key: 'signatory',
        filters: [
          {
            text: 'Коваленко Д. Д.',
            value: 'Коваленко Д. Д.',
          },
          {
            text: 'Смирнов М. М.',
            value: 'Смирнов М. М.',
          },
          {
            text: 'Сидоров С. С.',
            value: 'Сидоров С. С.',
          },
        ],
        onFilter: (value, item) => item.signatory.includes(value),
    },
    {
        title: 'Общий вес',
        dataIndex: 'totalWeight',
        key: 'totalWeight',
        sorter: (a, b) => a.totalWeight - b.totalWeight,
    },
    {
        title: 'Количество позиций',
        dataIndex: 'countPosition',
        key: 'countPosition',
        sorter: (a, b) => a.countPosition - b.countPosition,
        filters: [
            {
              text: 5,
              value: 5,
            },
            {
              text: 7,
              value: 7,
            },
            {
              text: 9,
              value: 9,
            },
          ],
          onFilter: (value, item) => item.countPosition === value,
    },
    {
        title: 'Сертификаты',
        dataIndex: 'certificates',
        key: 'certificates',
        sorter: (a, b) => a.certificates - b.certificates,
    },
    {
        title: 'Поставки',
        dataIndex: 'supplies',
        key: 'supplies',
    },
];

function TableShipment() {
    return (
        <Table
            rowSelection={{
                type: 'checkbox',
            }}
            dataSource={dataSource}
            columns={columns}
            scroll={{ x: 'max-content' }}
        />
    );
}

export default TableShipment;