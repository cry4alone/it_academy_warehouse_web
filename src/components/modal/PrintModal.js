import React from 'react';
import { Modal, Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import Question from "../../shared/assets/Question Mark.svg";
import './Modal.scss';

const PrintModal = ({ isPrintModalOpen, handleCancel, handleConfirm }) => {
    const navigate = useNavigate();

    const handleConfirmNavigation = () => {
        handleConfirm();
        navigate('/print');
    };

    return (
        <Modal
            open={isPrintModalOpen}
            onCancel={handleCancel}
            footer={null}
            centered
            closeIcon={null}
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
