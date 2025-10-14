import { Table } from 'antd';
import React, { useEffect } from 'react';
import { ColumnsType } from 'antd/es/table';
import { RowSelectMethod } from 'antd/es/table/interface';
import { IInvoiceData } from '../../types/invoiceTypes';
import { useInvoiceContext, useDefaultPropsContext } from '../Context';
import { fetchInvoices } from '../../api/fetchInvoices';

const TableInvoice = () => {
    const invoices = useInvoiceContext();
    const { setSelectedData, setSelectedRows, setInvoices } = useDefaultPropsContext();

    const handleSelectionChanged = (
        selectedRowKeys: React.Key[],
        selectedRows: IInvoiceData[],
        info: { type: RowSelectMethod }
    ) => {
        setSelectedData(selectedRows);
        setSelectedRows(selectedRowKeys);
    };

    useEffect(() => {
        const loadInvoices = async () => {
            try {
                const data = await fetchInvoices();
                setInvoices(data.map((item) => ({ ...item, key: item.id })));
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        loadInvoices();
    }, []);

    const columns: ColumnsType<IInvoiceData> = [
        {
            title: 'Автор',
            dataIndex: 'author',
            key: 'author',
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
            onFilter: (value, item) => item.author.includes(String(value)),
        },
        {
            title: 'Куда',
            dataIndex: 'where',
            key: 'where',
            filters: [
                {
                    text: 'Склад ЛО-1',
                    value: 'Склад ЛО-1',
                },
                {
                    text: 'Склад ЛО-2',
                    value: 'Склад ЛО-2',
                },
                {
                    text: 'Склад ЛО-3',
                    value: 'Склад ЛО-3',
                },
            ],
            onFilter: (value, item) => item.warehouse.includes(String(value)),
        },
        {
            title: 'Тип возврата',
            dataIndex: 'type',
            key: 'type',
            filters: [
                {
                    text: 'Доработка',
                    value: 'Доработка',
                },
                {
                    text: 'Переплав',
                    value: 'Переплав',
                },
            ],
            onFilter: (value, item) => item.type.includes(String(value)),
        },
        {
            title: 'Причина возврата',
            dataIndex: 'reason',
            key: 'reason',
            filters: [
                {
                    text: 'Невостребованная продукция',
                    value: 'Невостребованная продукция',
                },
                {
                    text: 'Дефект',
                    value: 'Дефект',
                },
            ],
            onFilter: (value, item) => item.returnReason.includes(String(value)),
        },
        {
            title: 'Дефекты',
            dataIndex: 'defect',
            key: 'defect',
        },
        {
            title: 'Дата отчета',
            dataIndex: 'date',
            key: 'date',
            sorter: (a, b) => new Date(a.date).getTime() - new Date(b.date).getTime(),
        },
    ];

    return (
        <Table
            rowSelection={{
                type: 'checkbox',
                onChange: handleSelectionChanged,
            }}
            dataSource={invoices}
            columns={columns}
            scroll={{ x: 'max-content' }}
        />
    );
};

export default TableInvoice;
