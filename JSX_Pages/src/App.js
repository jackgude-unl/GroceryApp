import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';

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
                    </Routes>
                </main>
            </div>
        </Router>
    );
}
function HomePage() {
    return (
        <div className="home">
            <section className="hero">
                <div className="hero-content">
                    <h2>Your One-Stop Shop for Fresh and Quality Groceries!</h2>
                    <input type="text" placeholder="Search for products..." className="search-bar" />
                    <button className="find-btn">Find</button>
                </div>
            </section>
            <section className="categories">
                <h3>Shop by Category</h3>
                <div className='categories-banner'>
                    <div className="category-list">
                        <div className="category-item">Fresh Foods</div>
                        <div className="category-item">Pantry Essentials</div>
                        <div className="category-item">Frozen & Prepared Foods</div>
                        <div className="category-item">Beverages</div>
                        <div className="category-item">Snacks & Desserts</div>
                    </div>
                </div>
            </section>
        </div>
    );
}
export default App;




