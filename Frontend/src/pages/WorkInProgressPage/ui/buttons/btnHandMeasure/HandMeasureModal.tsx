import React from 'react';
import { Table, InputNumber, Button, Modal } from 'antd';
import { ITableRow } from '../../../types/workInProgressTypes';
import { useSelectedRowsContext, useSelectedDataContext, useDefaultPropsContext } from '../../Context';
import { updataWork } from '../../../api/updataWork';

interface HandMeasureModalProps {
    visibleModal: boolean;
    onCancel: () => void;
}

const HandMeasureModal: React.FC<HandMeasureModalProps> = ({visibleModal, onCancel }) => {

    const selectedRows = useSelectedRowsContext();
    const selectedData = useSelectedDataContext();
    const {setSelectedData, setUpdataWorkInProgress} = useDefaultPropsContext();

    React.useEffect(() => {
        setSelectedData(selectedRows);
    }, [selectedRows]);

    const handleWeightChange = (value: number | null, record: ITableRow) => {
        console.log('Weight changed for record:', record.key, 'New value:', value);
        const updatedData = selectedData.map((item) =>
            item.key === record.key ? { ...item, net: value || 0, isModified: true } : item
        );
        setSelectedData(updatedData);
    };

    const handleSave = async () => { 
        await updataWork(selectedData)
        setUpdataWorkInProgress(true);
        onCancel();
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
        <Modal
            title="Ручное взвешивание"
            visible={visibleModal}
            onCancel={onCancel}
            footer={null}
            destroyOnClose
        >
            <div>
                <Table
                    dataSource={selectedData}
                    columns={columns}
                    pagination={false}
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
        </Modal>
    );
};

export default HandMeasureModal;