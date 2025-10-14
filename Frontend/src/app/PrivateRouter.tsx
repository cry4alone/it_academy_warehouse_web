import React from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { useAuth } from '@/app/contexts/AuthContext';

const PrivateRouter = ({ children }: { children: React.ReactNode }) => {
    const { user } = useAuth();
    const location = useLocation();

    if (!user) return <Navigate to='/auth' state={{ from: location }} />;

    return <>{children}</>;
};

export default PrivateRouter;
