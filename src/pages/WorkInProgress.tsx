import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import TableWorkInProgress from '../components/table/TableWorkInProgress';
import PositiveModal from '../widgets/modal/PositiveModal';
import NegativeModal from '../widgets/modal/NegativeModal';
import { Button } from 'antd';
import { ButtonContext } from '../contexts/ButtonContext';
import '../app/styles/global.scss';

function WorkInProgress() {
    const { showAdditionalButtons } = useContext(ButtonContext);
    const navigate = useNavigate();
    const [selectedRows, setSelectedRows] = useState([]);
    const [isPositiveModalOpen, setIsPositiveModalOpen] = useState(false);
    const [isNegativeModalOpen, setIsNegativeModalOpen] = useState(false);

    const handleMeasureProduct = () => {
        if (selectedRows.length > 0) {
            navigate('/handMeasure');
        }
    };

    const showPositiveModal = () => {
        setIsPositiveModalOpen(true);
    };

    const handlePositiveOk = () => {
        setIsPositiveModalOpen(false);
    };

    const showNegativeModal = () => {
        setIsNegativeModalOpen(true);
    };

    const handleNegativeOk = () => {
        setIsNegativeModalOpen(false);
    };

    return (
        <>
            <div className="tab__title">Незавершённое производство</div>
            <TableWorkInProgress onSelectionChange={setSelectedRows} />
            <div className="button-container">
                {!showAdditionalButtons && (
                    <>
                        <Button onClick={handleMeasureProduct} disabled={selectedRows.length === 0}>Ручное взвешивание</Button>
                        <Button onClick={showNegativeModal}>Обработка накладных возврата</Button>
                        <Button onClick={showPositiveModal}>Создание сертификата</Button>
                    </>
                )}
                {showAdditionalButtons && (
                    <>
                        <Button>Отмена</Button>
                        <Button type="primary">Добавить выбранные позиции</Button>
                    </>
                )}
            </div>
            <PositiveModal isPositiveModalOpen={isPositiveModalOpen} handlePositiveOk={handlePositiveOk} />
            <NegativeModal isNegativeModalOpen={isNegativeModalOpen} handleNegativeOk={handleNegativeOk} />
        </>
    );
}

export default WorkInProgress;
