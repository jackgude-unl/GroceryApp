import React from 'react';
import '../App.css';
import '../css-pages/home.css'

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

export default HomePage;