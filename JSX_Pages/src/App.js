import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import HomePage from './pages/home';
import LoginPage from './pages/login';
import CartPage from './pages/login';
import ProductsPage from './pages/product';

function App() {
    return (
        <Router>
            <div className="App">
                <header className="App-header">
                    <h1 className="App-title">Group 12's Groceries</h1>
                    <nav className="App-nav">
                        <div className="nav-links">
                            <Link to="/">Home</Link>
                            <Link to="/products">Products</Link>
                            <Link to="/cart">Cart</Link>
                        </div>
                        <div className="login-link">
                            <Link to="/login">Login</Link>
                        </div>
                    </nav>
                </header>
                <main>
                    <Routes>
                        <Route path="/" element={<HomePage />} />
                        <Route path="/login" element={<LoginPage />} />
                        <Route path="/products" element={<ProductsPage />} />
                        <Route path="/cart" element={<CartPage />} />
                    </Routes>
                </main>
            </div>
        </Router>
    );
}

export default App;




