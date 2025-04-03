import React from 'react';
import PrintModal from './printModal/PrintModal';
import { Button } from 'antd';
import { useSelectedRowsContext } from '../../../Context';

const BtnPrints = () => {
    const { selectedRows } = useSelectedRowsContext(); 
    const [isPrintModalOpen, setIsPrintModalOpen] = React.useState<boolean>(false);

    const showPrintModal = () => {
        setIsPrintModalOpen(true);
    };

    return (
        <div>
            <Button
                onClick={showPrintModal}
                disabled={selectedRows.length === 0} 
            >
                Печать этикеток
            </Button>
            <PrintModal
                isPrintModalOpen={isPrintModalOpen}
                handleCancel={() => setIsPrintModalOpen(false)}
                handleConfirm={() => setIsPrintModalOpen(false)}
            />
        </div>
    );
};

export default BtnPrints;