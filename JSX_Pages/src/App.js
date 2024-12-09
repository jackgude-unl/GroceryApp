import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import HomePage from './pages/home';
function LoginPage() {
    return (
        <div className="login">
            <h1>Login</h1>
            <form className="login-form">
                <label>
                    Username:
                    <input type="text" name="username" required />
                </label>
                <label>
                    Password:
                    <input type="password" name="password" required />
                </label>
                <button type="submit">Login</button>
            </form>
        </div>
    );
}

function ProductsPage() {
    return (
        <div className="products-page">
            <h2>Our Products</h2>
            {}
            <p>Product listing goes here.</p>
        </div>
    );
}

function CartPage() {
    return (
        <div className="cart-page">
            <h2>Your Cart</h2>
            <p>Your cart items will appear here.</p>
        </div>
    );
}

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




