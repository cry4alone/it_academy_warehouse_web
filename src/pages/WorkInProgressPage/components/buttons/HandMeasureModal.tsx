import React from 'react';
import { Table, InputNumber, Button } from 'antd';
import { ITableRow } from '../../types/workInProgressTypes';

interface HandMeasureModalProps {
    visible?: boolean; 
    selectedRows: ITableRow[];
    onSave: (updatedRows: ITableRow[]) => void;
    onCancel: () => void;
}

const HandMeasureModal: React.FC<HandMeasureModalProps> = ({ selectedRows, onSave, onCancel }) => {
    const [data, setData] = React.useState<ITableRow[]>(selectedRows);

    React.useEffect(() => {
        setData(selectedRows);
    }, [selectedRows]);

    const handleWeightChange = (value: number | null, record: ITableRow) => {
        console.log('Weight changed for record:', record.key, 'New value:', value);
        const updatedData = data.map((item) =>
            item.key === record.key ? { ...item, net: value || 0, isModified: true } : item
        );
        setData(updatedData);
    };

    const handleSave = () => {
        onSave(data); 
    };

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
        },
        {
            title: 'Материал',
            dataIndex: 'material',
            key: 'material',
        },
        {
            title: 'Нетто, кг',
            dataIndex: 'net',
            key: 'net',
            render: (text: number, record: ITableRow) => (
                <InputNumber
                    value={record.net}
                    min={0}
                    onChange={(value) => handleWeightChange(value, record)}
                    style={{ width: '100%' }}
                />
            ),
        },
    ];

    return (
        <div>
            <Table
                dataSource={data}
                columns={columns}
                pagination={false}
                rowKey="key"
                bordered
            />
            <div style={{ marginTop: 16, textAlign: 'right' }}>
                <Button onClick={onCancel} style={{ marginRight: 8 }}>
                    Отмена
                </Button>
                <Button type="primary" onClick={() => handleSave()}>
                    Изменить
                </Button>
            </div>
        </div>
    );
};

export default HandMeasureModal;