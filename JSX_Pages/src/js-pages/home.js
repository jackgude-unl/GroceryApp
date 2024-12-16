import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../App.css';
import '../css-pages/home.css';

function HomePage() {
    const [searchQuery, setSearchQuery] = useState('');
    const navigate = useNavigate();
    const updatePage = () => { navigate(`/products?search=${encodeURIComponent(searchQuery)}`) };
    return (
        <div className="home">
            <section className="hero">
                <div className="hero-content">
                    <h2>Your One-Stop Shop for Fresh and Quality Groceries!</h2>
                    <input type="text" placeholder="Search for products..." className="search-bar" value={searchQuery} onChange={(e) => setSearchQuery(e.target.value)} />
                    <button className="find-btn" onClick={updatePage}>Find </button>
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

export default HomePage;