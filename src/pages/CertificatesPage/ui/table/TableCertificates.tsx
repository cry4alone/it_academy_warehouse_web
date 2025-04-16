import React, { useEffect} from 'react';
import { Table } from 'antd';
import { ColumnsType } from 'antd/es/table';
import { RowSelectMethod } from 'antd/es/table/interface';
import { useDefaultPropsContext, useCertificateContext } from '../Context';
import { fetchCertificate } from '@/pages/CertificatesPage/api/fetchCertificate';
import { ICertificateData } from '@/pages/CertificatesPage/types/certificateTypes';

const TableCertificates = () => {
    const certificates  = useCertificateContext();
    const { setSelectedData, setCertificates } = useDefaultPropsContext();

    useEffect(() => {
        const loadCertificates = async () => {
            try {
                const data = await fetchCertificate();
                setCertificates(data.map((item) => ({ ...item, key: item.id })));
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        loadCertificates();
    }, []);

    const handleSelectionChanged = (
        selectedRowKeys: React.Key[],
        selectedRows: ICertificateData[],
        info: { type: RowSelectMethod }
    ) => {
        setSelectedData(selectedRows);
    };

    const columns: ColumnsType<ICertificateData> = [
        {
            title: '№ сертификата',
            dataIndex: 'certificateNumber',
            key: 'certificateNumber',
            sorter: (a, b) => a.certificateNumber - b.certificateNumber,
        },
        {
            title: 'Схема контроля',
            dataIndex: 'controlScheme',
            key: 'controlScheme',
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
            onFilter: (value, item) => item.controlScheme.includes(String(value)),
        },
        {
            title: 'Дата',
            dataIndex: 'date',
            key: 'date',
            sorter: (a, b) => new Date(a.date).getTime() - new Date(b.date).getTime(),
        },
        {
            title: 'Склад',
            dataIndex: 'warehouse',
            key: 'warehouse',
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
            onFilter: (value, item) => item.warehouse.includes(String(value)),
        },
        {
            title: 'Подписант',
            dataIndex: 'signatory',
            key: 'signatory',
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
            onFilter: (value, item) => item.signatory.includes(String(value)),
        },
        {
            title: 'Количество позиций',
            dataIndex: 'countPosition',
            key: 'countPosition',
            sorter: (a, b) => a.countPosition - b.countPosition,
        },
    ];

    return (
        <Table
            rowSelection={{
                type: 'checkbox',
                onChange: handleSelectionChanged,
            }}
            dataSource={certificates}
            columns={columns}
            scroll={{ x: 'max-content' }}
        />
    );
};

export default TableCertificates;
