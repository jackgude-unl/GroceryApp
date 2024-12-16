import React, { useEffect, useState } from 'react';
import '../App.css';
import '../css-pages/product.css';

function ProductsPage() {
    const [products, setProducts] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await fetch('http://localhost:5156/api/products');
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
                        <div key={product.productId} className="product-card">
                            <h3>{product.name}</h3>
                            <img
                                src={`http://localhost:5156/Images/${product.name}.jpg`}
                                alt={product.name}
                                className="product-image"
                            />
                            <p>{product.description}</p>
                            <p><strong>Price:</strong> ${product.price.toFixed(2)}</p>
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
