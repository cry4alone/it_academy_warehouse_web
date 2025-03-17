import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import TableReadyProduction from './components/table/TableReadyProduction';
import { Button } from 'antd';
import { ButtonContext, ButtonProvider } from '@contexts/ButtonContext';
import { Flex } from 'antd';
import PrintModal from './components/modal/PrintModal';
import '@app/styles/global.scss';

interface ButtonContextType {
    showAdditionalButtons: boolean;
}

interface DataType {
    id: number;
    meltNumber: string;
    packageNumber: number;
    date: string;
    status: string;
    length: number;
    specification: string;
    brand: string;
    certificateNumber: number;
    section: number;
    controlScheme: string;
    material: string;
    net: number;
    gross: number;
}

function ReadyProduction() {
    const { showAdditionalButtons } = useContext<ButtonContextType>(ButtonContext);
    const navigate = useNavigate();
    const [selectedRows, setSelectedRows] = useState<React.Key[]>([]);
    const [selectedData, setSelectedData] = useState<DataType[]>([]);
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
        if (selectedData.length > 0) {
            navigate('/documents/transfers', {
                state: { selectedData },
            });
        }
    };

    const handleWorkCertificates = () => {
        navigate('/documents/certificates');
    };

    return (
        <>
            <div className='tab__title'>Готовое производство</div>
            <TableReadyProduction
                onSelectionChange={(newSelectedRows, NewSelectedData) => {
                    setSelectedRows(newSelectedRows);
                    setSelectedData(NewSelectedData);
                }}
            />
            <div className='button-container'>
                {!showAdditionalButtons && (
                    <Flex gap='middle' justify='flex-end'>
                        <Button onClick={showPrintModal} disabled={selectedRows.length === 0}>
                            Печать этикеток
                        </Button>
                        <Button onClick={handleReturnProduct} disabled={selectedRows.length === 0}>
                            Возврат продукции
                        </Button>
                        <Button>Перераспределить сертификат</Button>

                        <Button onClick={handleWorkCertificates}>Работа с сертификатами</Button>
                    </Flex>
                )}
                {showAdditionalButtons && (
                    <>
                        <Button>Отмена</Button>
                        <Button type='primary'>Добавить пакеты</Button>
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
