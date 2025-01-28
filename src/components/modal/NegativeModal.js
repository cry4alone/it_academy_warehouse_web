import React from 'react';
import { Modal, Button } from 'antd';
import error from "../../shared/assets/Error.svg";
import './Modal.scss';

const NegativeModal = ({ isNegativeModalOpen, handleNegativeOk }) => {
    return (
        <Modal
            open={isNegativeModalOpen}
            onOk={handleNegativeOk}
            footer={null}
            centered
            closeIcon={null}
        >
            <div className="modal-content">
                <img src={error} alt="Error" />
                <h2>Ошибка выполнения действия!</h2>
            </div>
            <div className="modal-footer">
                <Button key="ok"  onClick={handleNegativeOk}>
                    OK
                </Button>
            </div>
        </Modal>
    );
};

export default NegativeModal;
