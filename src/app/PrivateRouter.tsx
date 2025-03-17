import React from 'react'
import { Navigate, Outlet, useLocation } from 'react-router-dom' 
import { useAuth } from "@contexts/Context"

const PrivateRouter = () => {
    const { user } = useAuth();
    const location = useLocation();

    // if (!user) return <Navigate to="/auth" state={
    //     { from: location }
    // } />

    return <Outlet />
}

export default PrivateRouter