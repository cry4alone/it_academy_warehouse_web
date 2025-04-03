import React from 'react';
import { Modal, Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import Question from '@shared/assets/QuestionMark.svg';
import './PrintModal.scss';

interface PrintModalProps {
    isPrintModalOpen: boolean;
    handleCancel: () => void;
    handleConfirm: () => void;
}

const PrintModal: React.FC<PrintModalProps> = ({ isPrintModalOpen, handleCancel, handleConfirm }) => {
    const navigate = useNavigate();

    const handleConfirmNavigation = () => {
        handleConfirm();
        navigate('/Print');
    };

    return (
        <Modal
            open={isPrintModalOpen}
            onCancel={handleCancel}
            footer={null}
            centered
            closeIcon={null}
            className="custom-modal"
        >
            <div className="modal-content">
                <img src={Question} alt="Question" />
                <h2>Вы уверены, что хотите распечатать выбранную продукцию?</h2>
            </div>

            <div className="modal-footer">
                <Button key="cancel" onClick={handleCancel}>
                    Нет
                </Button>
                <Button key="confirm" type="primary" onClick={handleConfirmNavigation}>
                    Да
                </Button>
            </div>
        </Modal>
    );
};

export default PrintModal;