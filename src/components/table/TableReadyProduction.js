import React from "react";
import { Table } from 'antd';
import { dataReadyProduction } from "../data";


const dataSource = dataReadyProduction.map(item => ({...item, key: item.id}));

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
    sorter: (a, b) => a.packageNumber - b.packageNumber
  },
  {
    title: 'Дата',
    dataIndex: 'date',
    key: 'date',
    sorter: (a, b) => new Date(a.date) - new Date(b.date),
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
    title: 'Нетто, кг',
    dataIndex: 'net',
    key: 'net',
    sorter: (a, b) => a.net - b.net,
  },
  {
    title: 'Брутто, кг',
    dataIndex: 'gross',
    key: 'gross',
    sorter: (a, b) => a.gross - b.gross
  },
  {
    title: 'Упаковка',
    dataIndex: 'package',
    key: 'package',
    filters: [
      {
        text: 'Плёнка',
        value: 'Плёнка',
      },
      {
        text: 'Картон',
        value: 'Картон',
      },
      {
        text: 'Деревянный ящик',
        value: 'Деревянный ящик',
      },
      {
        text: 'Металлический контейнер',
        value: 'Металлический контейнер',
      },
    ],
    onFilter: (value, item) => item.package.includes(value),
  },
  {
    title: 'Вес упаковки',
    dataIndex: 'packageWeight',
    key: 'PackageWeight',
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
    title: 'Комментарий',
    dataIndex: 'comment',
    key: 'comment',
  },
];

function TableReadyProduction() {
  
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
  
  export default TableReadyProduction;