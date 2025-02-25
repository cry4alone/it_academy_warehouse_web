import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import TableReadyProduction from '../../components/table/TableReadyProduction';
import { Button } from 'antd';
import { ButtonContext, ButtonProvider } from '../../contexts/ButtonContext';
import PrintModal from "./components/modal/PrintModal";
import '../../app/styles/global.scss';

interface ButtonContextType {
    showAdditionalButtons: boolean;
}

function ReadyProduction() {
    const { showAdditionalButtons } = useContext<ButtonContextType>(ButtonContext);
    const navigate = useNavigate();
    const [selectedRows, setSelectedRows] = useState<React.Key[]>([]);
    const [isPrintModalOpen, setIsPrintModalOpen] = useState<boolean>(false);

    const showPrintModal = () => {
        setIsPrintModalOpen(true);
    };

    const handlePrintCancel = () => {
        setIsPrintModalOpen(false);
    };

    const handlePrintConfirm = () => {
        setIsPrintModalOpen(false);
    };

    const handleReturnProduct = () => {
        if (selectedRows.length > 0) {
            navigate('/documents/transfers');
        }
    };

    return (
        <>
            <div className="tab__title">Готовое производство</div>
            <TableReadyProduction onSelectionChange={setSelectedRows} />
            <div className="button-container">
                {!showAdditionalButtons && (
                    <>
                        <Button>Перераспределить сертификат</Button>
                        <Button onClick={handleReturnProduct} disabled={selectedRows.length === 0}>
                            Возврат продукции
                        </Button>
                        <Button>Работа с сертификатами</Button>
                        <Button onClick={showPrintModal} disabled={selectedRows.length === 0}>
                            Печать этикеток
                        </Button>
                    </>
                )}
                {showAdditionalButtons && (
                    <>
                        <Button>Отмена</Button>
                        <Button type="primary">Добавить пакеты</Button>
                    </>
                )}
            </div>
            <PrintModal
                isPrintModalOpen={isPrintModalOpen}
                handleCancel={handlePrintCancel}
                handleConfirm={handlePrintConfirm}
            />
        </>
    );
}

export default function WrappedReadyProduction() {
    return (
        <ButtonProvider>
            <ReadyProduction />
        </ButtonProvider>
    );
}
