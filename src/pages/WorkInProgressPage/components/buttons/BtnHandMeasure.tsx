import React, { useState } from 'react';
import { Button, Modal, notification } from 'antd';
import HandMeasureModal from './HandMeasureModal';
import { ITableRow } from '../../types/workInProgressTypes';

interface BtnHandMeasureProps {
  selectedRows: ITableRow[];
  onSave: (updatedRows: ITableRow[]) => void;
}

const BtnHandMeasure: React.FC<BtnHandMeasureProps> = ({ selectedRows, onSave }) => {
  const [isModalVisible, setIsModalVisible] = useState(false);

  const handleSave = (updatedRows: ITableRow[]) => {
    console.log('Updated rows in BtnHandMeasure:', updatedRows);
    setIsModalVisible(false);
    onSave(updatedRows);
};

  const handleCancel = () => {
    setIsModalVisible(false); 
  };

  const handleMeasureProduct = () => {
    if (selectedRows.length > 0) {
      setIsModalVisible(true); 
    } else {
      notification.error({
        message: 'Ошибка',
        description: 'Пожалуйста, выберите хотя бы одну строку для ручного взвешивания.',
      });
    }
  };

  return (
    <div>
      <Button
        onClick={handleMeasureProduct}
        disabled={selectedRows.length === 0}
        aria-label="Ручное взвешивание"
      >
        Ручное взвешивание
      </Button>
      <Modal
        title="Ручное взвешивание"
        visible={isModalVisible}
        onCancel={handleCancel}
        footer={null}
        destroyOnClose 
      >
        <HandMeasureModal
          visible={isModalVisible}
          selectedRows={selectedRows}
          onSave={handleSave}
          onCancel={handleCancel}
        />
      </Modal>
    </div>
  );
};

export default BtnHandMeasure;