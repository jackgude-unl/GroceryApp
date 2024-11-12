import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';

function HomePage() {
    return (
        <div className="home">
            <p>Welcome to our grocery store! Browse products and more.</p>
        </div>
    );
}

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

function App() {
    return (
        <Router>
            <div className="App">
                <header className="App-header">
                    <h1 className="App-title">Group 12's Groceries</h1>
                    <nav className="App-nav">
                        <Link to="/">Home</Link>
                        <Link to="/login">Login</Link>
                        <Link to="/products">Products</Link>
                        <Link to="/cart">Cart</Link>
                    </nav>
                </header>
                <main>
                    <Routes>
                        <Route path="/" element={<HomePage />} />
                        <Route path="/login" element={<LoginPage />} />
                    </Routes>
                </main>
            </div>
        </Router>
    );
}

export default App;




