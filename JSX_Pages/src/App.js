import React from 'react';
import './App.css';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <h1 className="App-title">Group 12's Groceries</h1>
                <nav className="App-nav">
                    <a href="/">Home</a>
                    <a href="/products">Products</a>
                    <a href="/cart">Cart</a>
                </nav>
            </header>
            <main>
                {/* Additional components can be added here, such as Product List or Featured Items */}
            </main>
        </div>
    );
}

export default App;


