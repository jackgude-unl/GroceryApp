import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import '../App.css';
import '../css-pages/product.css';

function ProductsPage() {
    const [products, setProducts] = useState([]);
    const [error, setError] = useState(null);
    const [addingToCart, setAddingToCart] = useState({});
    const location = useLocation();
    
    useEffect(() => {
        const fetchProducts = async () => {
            const searchParams = new URLSearchParams(location.search);
            const searchQuery = searchParams.get('search');
            try {
                const response = await fetch(`http://localhost:5156/api/products?search=${encodeURIComponent(searchQuery || '')}`);
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
    }, [location.search]);

    const addToCart = async (productId) => {
        const userId = localStorage.getItem('userId');
        if (!userId) {
            alert('Please log in to add items to cart');
            return;
        }

        setAddingToCart(prev => ({ ...prev, [productId]: true }));
        
        try {
            const response = await fetch(
                `http://localhost:5156/api/carts/user/${userId}/product/${productId}?quantity=1`,
                { 
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            );

            if (!response.ok) {
                throw new Error('Failed to add to cart');
            }

            alert('Added to cart!');
        } catch (err) {
            setError('Failed to add item to cart');
            alert('Error adding to cart');
        } finally {
            setAddingToCart(prev => ({ ...prev, [productId]: false }));
        }
    };

    return (
        <div className="products-page">
            <h2>Our Products</h2>

            {error && <p className="error">Error: {error}</p>}

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
                            <p className="price"><strong>Price:</strong> ${product.price.toFixed(2)}</p>
                            <button 
                                className="add-to-cart-button"
                                onClick={() => addToCart(product.productId)}
                                disabled={addingToCart[product.productId]}
                            >
                                {addingToCart[product.productId] ? 'Adding...' : 'Add to Cart'}
                            </button>
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