import React from 'react'
import { Navigate, Outlet } from 'react-router-dom' 
import { useAuth } from "../contexts/Context"

const PrivateRouter = () => {
    const { user } = useAuth();

    if (!user) return <Navigate to="/auth" />
    return <Outlet />
}

export default PrivateRouter