import React, { useEffect, useState } from 'react';
import '../App.css';

function ProductsPage() {
    const [products, setProducts] = useState([]); // State to store products
    const [error, setError] = useState(null); // State to handle errors

    // Fetch products from the backend
    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await fetch('http://localhost:8081/products'); // Fetch from backend
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                const data = await response.json();
                setProducts(data); 
            } catch (err) {
                setError(err.message); 
            }
        };

        fetchProducts();
    }, []); 

    return (
        <div className="products-page">
            <h2>Our Products</h2>

            {/* Handle errors */}
            {error && <p className="error">Error: {error}</p>}

            {/* Display products */}
            <div className="product-list">
                {products.length > 0 ? (
                    products.map(product => (
                        <div key={product.ProductID} className="product-card">
                            <h3>{product.ProductName}</h3>
                            <p>{product.ProductDescription}</p>
                            <p><strong>Price:</strong> ${product.Price.toFixed(2)}</p>
                        </div>
                    ))
                ) : (
                    <p>Loading products...</p>
                )}
            </div>
        </div>
    );
}

export default ProductsPage;