import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route, Link, useNavigate } from "react-router-dom";
import "./App.css";
import HomePage from "./js-pages/home";
import LoginPage from "./js-pages/login";
import CartPage from "./js-pages/cart";
import ProductsPage from "./js-pages/product";
import CreateUserPage from "./js-pages/createuser";

function App() {
    const [user, setUser] = useState(null);
    const navigate = useNavigate();

    const handleLogin = (userData) => {
        setUser(userData);
    };

    const handleLogout = () => {
        localStorage.removeItem('userId');
        localStorage.removeItem('userEmail');
        window.dispatchEvent(new Event('storage'));
        setUser(null);
        navigate("/login");
    };

    return (
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
                        {user ? (
                            <>
                                <span>Welcome, {user.firstName}</span>
                                <button onClick={handleLogout} className="logout-button">
                                    Logout
                                </button>
                            </>
                        ) : (
                            <Link to="/login">Login</Link>
                        )}
                    </div>
                </nav>
            </header>
            <main>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/login" element={<LoginPage onLogin={handleLogin} />} />
                    <Route path="/create-user" element={<CreateUserPage />} />
                    <Route path="/products" element={<ProductsPage userId={user?.userId} />} />
                    <Route path="/cart" element={<CartPage userId={user?.userId} />} />
                </Routes>
            </main>
        </div>
    );
}
export default App;