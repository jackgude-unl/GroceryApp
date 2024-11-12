import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

// Initialize the root using createRoot
const root = ReactDOM.createRoot(document.getElementById('root'));

// Render only the App component
root.render(
    <React.StrictMode>
        <App />
    </React.StrictMode>
);

// Log performance metrics (optional)
reportWebVitals();

