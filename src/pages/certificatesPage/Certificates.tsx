import React, { useState } from "react";
import TableCertificates from "../../components/table/documents/TableCertificates";
import ControlSchemeModal from "./components/modals/ControlSchemeModal";
import PackageModal from "./components/modals/PackageModal";
import { Button } from 'antd';
import { Flex } from "antd";

function Certificates() {
    const [isControlSchemeModalVisible, setIsControlSchemeModalVisible] = useState(false);

    const showControlSchemeModal = () => {
        setIsControlSchemeModalVisible(true);
    };

    const handleOk = () => {
        setIsControlSchemeModalVisible(false);
    };

    const handleCancel = () => {
        setIsControlSchemeModalVisible(false);
    };

    const [isPackageModalVisible, setIsPackageModalVisible] = useState(false);

    const showPackageModal = () => {
        setIsPackageModalVisible(true);
    };

    const handlePackageOk = () => {
        setIsPackageModalVisible(false);
    };

    const handlePackageCancel = () => {
        setIsPackageModalVisible(false);
    };

    return (
        <>
            <div className="tab__title">Документы | Сертификат</div>
            <TableCertificates />
            <Flex gap="middle" justify="flex-end">
                <Button type="primary" onClick={showControlSchemeModal}>
                    Проверка схемы контроля
                </Button>
                <Button type="primary" onClick={showPackageModal}>Проверка упаковки</Button>
            </Flex>
            <PackageModal isPackageModalVisible={isPackageModalVisible}
            handlePackageOk={handlePackageOk}
            handlePackageCancel={handlePackageCancel}/>
            <ControlSchemeModal
                isControlSchemeModalVisible={isControlSchemeModalVisible}
                handleOk={handleOk}
                handleCancel={handleCancel}
            />
        </>
    );
}

export default Certificates;
