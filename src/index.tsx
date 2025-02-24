import React from 'react';
import { createRoot } from 'react-dom/client';
import App from './app/App';
import './app/styles/global.scss';
import { AuthProvider } from './contexts/Context';
import { ButtonProvider } from './contexts/ButtonContext';

const container = document.getElementById('root');

if (container) {
    const root = createRoot(container);
    root.render(
        <React.StrictMode>
            <AuthProvider>
                <ButtonProvider>
                    <App />
                </ButtonProvider>
            </AuthProvider>
        </React.StrictMode>
    );
}
