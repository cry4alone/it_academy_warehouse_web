import React from 'react';
import { Modal, Button } from 'antd';
import check from "../../shared/assets/Checkmark.svg";
import './Modal.scss';

interface PositiveModalProps {
    isPositiveModalOpen: boolean;
    handlePositiveOk: () => void;
}

const PositiveModal: React.FC<PositiveModalProps> = ({ isPositiveModalOpen, handlePositiveOk }) => {
    return (
        <Modal
            open={isPositiveModalOpen}
            onOk={handlePositiveOk}
            footer={null}
            centered
            closeIcon={null}
        >
            <div className="modal-content">
                <img src={check} alt="Checkmark" />
                <h2>Действие успешно выполнено!</h2>
            </div>
            <div className="modal-footer">
                <Button key="ok" type="primary" onClick={handlePositiveOk}>
                    OK
                </Button>
            </div>
        </Modal>
    );
};

export default PositiveModal;
