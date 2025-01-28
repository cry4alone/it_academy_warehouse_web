import React, { useContext, useState } from 'react';
import TableWorkInProgress from '../components/table/TableWorkInProgress';
import PositiveModal from '../components/modal/PositiveModal';
import NegativeModal from '../components/modal/NegativeModal';
import { Button } from 'antd';
import { ButtonContext } from '../contexts/ButtonContext';
import '../styles/global.scss';

function WorkInProgress() {
    const { showAdditionalButtons } = useContext(ButtonContext);
    const [isPositiveModalOpen, setIsPositiveModalOpen] = useState(false);
    const [isNegativeModalOpen, setIsNegativeModalOpen] = useState(false);

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
            <TableWorkInProgress />
            <div className="button-container">
                {!showAdditionalButtons && (
                    <>
                        <Button onClick={showPositiveModal}>Ручное взвешивание</Button>
                        <Button onClick={showNegativeModal}>Обработка накладных возврата</Button>
                        <Button>Создание сертификата</Button>
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
