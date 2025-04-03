import { Button } from 'antd';
import React, { useState } from 'react';
import PackageModal from './PackageModal';

const BtnCheckPackage = () => {
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
            <Button type='primary' onClick={showPackageModal}>
                Проверка упаковки
            </Button>
            <PackageModal
                isPackageModalVisible={isPackageModalVisible}
                handlePackageOk={handlePackageOk}
                handlePackageCancel={handlePackageCancel}
            />
        </>
    );
};

export default BtnCheckPackage;
