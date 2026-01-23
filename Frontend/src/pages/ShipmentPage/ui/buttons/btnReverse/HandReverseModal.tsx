import React from 'react';
import {Table, Button, Modal, Input, DatePicker, Typography, notification} from 'antd';
import { useSelectedDataContext } from "../../Context";
import { IShipmentData } from "../../../types/shipmentTypes";
import dayjs from 'dayjs';
import {revokeShipment} from "../../../api/revokeShipment";
import {signShipment} from "../../../api/signShipment";

interface HandReverseModalProps {
    visibleModal: boolean;
    onCancel: () => void;
}

const { TextArea } = Input;
const { Text } = Typography;

const HandReverseModal: React.FC<HandReverseModalProps> = ({ visibleModal, onCancel }) => {
    const selectedData = useSelectedDataContext();
    const [reason, setReason] = React.useState('');
    const [reverseDate, setReverseDate] = React.useState(dayjs());
    const [isLoading, setIsLoading] = React.useState(false);

    const handleReverse = async () => {
        if (!selectedData.length) return;

        setIsLoading(true);
        try {
            await revokeShipment({
                shipments: selectedData,
                reason,
                revokedAt: reverseDate.toISOString()
            });


            notification.success({
                message: `Сторнировано ${selectedData.length} документов`
            });
            onCancel();
        } catch (error) {
            notification.error({
                message: 'Ошибка при сторнировании',
                description: error instanceof Error ? error.message : 'Неизвестная ошибка'
            });
        } finally {
            setIsLoading(false);
        }
    };

    const columns = [
        {
            title: '№ отгрузки',
            dataIndex: 'shipmentNumber',
            key: 'shipmentNumber',
        },
        {
            title: 'Склад отправитель',
            dataIndex: 'warehouseSender',
            key: 'warehouseSender',
        },
        {
            title: 'Подписант',
            dataIndex: 'signatory',
            key: 'signatory',
        },
        {
            title: 'Сертификаты',
            dataIndex: 'certificates',
            key: 'certificates',
        },
    ];

    return (
        <Modal
            title="Сторнирование документа"
            visible={visibleModal}
            onCancel={onCancel}
            footer={[
                <Button key="cancel" onClick={onCancel}>
                    Отменить
                </Button>,
                <Button key="reverse" type="primary" danger onClick={handleReverse}>
                    Сторнировать
                </Button>,
            ]}
            width={800}
            destroyOnClose
        >
            <div style={{ marginBottom: 16 }}>
                <Text strong>Дата сторнирования: </Text>
                <DatePicker
                    value={reverseDate}
                    onChange={(date) => setReverseDate(date || dayjs())}
                    style={{ marginLeft: 8 }}
                />
            </div>

            <Table
                dataSource={selectedData}
                columns={columns}
                pagination={false}
                bordered
                rowKey="key"
                style={{ marginBottom: 16 }}
            />

            <div>
                <Text strong>Причина сторнирования:</Text>
                <TextArea
                    rows={4}
                    placeholder="Укажите реальную причину сторнирования"
                    value={reason}
                    onChange={(e) => setReason(e.target.value)}
                    style={{ marginTop: 8 }}
                />
            </div>
        </Modal>
    );
};

export default HandReverseModal;