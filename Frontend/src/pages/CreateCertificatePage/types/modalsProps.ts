export interface CertificateModalProps {
    isCertificateModalVisible: boolean;
    handleOk: () => void;
    handleCancel: () => void
};

export interface ControlSchemeModalProps {
    isControlSchemeModalVisible: boolean;
    handleOk: () => void;
    handleCancel: () => void;
    onSaveControlScheme: (controlScheme: string) => void;
};

export interface DelivaryModalProps {
    isDelivaryModalVisible: boolean;
    handleOk: () => void;
    handleCancel: () => void;
    onSaveDelivary: (delivary: number ) => void;
};