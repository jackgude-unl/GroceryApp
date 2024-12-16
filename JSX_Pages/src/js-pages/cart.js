import React, { useEffect, useState } from 'react';
import '../App.css';
import '../css-pages/cart.css';

function CartPage() {
    const [cart, setCart] = useState(null);
    const [products, setProducts] = useState({});
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        if (!localStorage.getItem('userId')) {
            setCart(null);
            setProducts({});
            setError('Please log in to view your cart');
            setLoading(false);
            return;
        }

        fetchCart();
    }, [localStorage.getItem('userId')]);

    const fetchCart = async () => {
        const userId = localStorage.getItem('userId');
        if (!userId) {
            setLoading(false);
            setError('Please log in to add to cart');
            return;
        }

        try {
            const response = await fetch(`http://localhost:5156/api/carts/user/${userId}`);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();
            setCart(data);

            const productDetails = {};
            for (const item of data.productsInCart) {
                const productResponse = await fetch(`http://localhost:5156/api/products/${item.productId}`);
                if (productResponse.ok) {
                    const productData = await productResponse.json();
                    productDetails[item.productId] = productData;
                }
            }
            setProducts(productDetails);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    if (loading) return <div className="cart-page"><p>Loading cart...</p></div>;
    if (error) return <div className="cart-page"><p className="error">Error: {error}</p></div>;
    if (!cart || cart.productsInCart.length === 0) {
        return <div className="cart-page"><p>Your cart is empty</p></div>;
    }

    const calculateItemTotal = (productId, quantity) => {
        return products[productId] ? products[productId].price * quantity : 0;
    };

    const calculateCartTotal = () => {
        return cart.productsInCart.reduce((total, item) => {
            return total + calculateItemTotal(item.productId, item.quantity);
        }, 0);
    };

    return (
        <div className="cart-page">
            <h2>Your Cart</h2>
            <div className="cart-items">
                {cart.productsInCart.map(item => {
                    const product = products[item.productId];
                    return (
                        <div key={item.productId} className="cart-item">
                            <div className="product-image">
                                <img
                                    src={`http://localhost:5156/Images/${product?.name}.jpg`}
                                    alt={product?.name || `Product ${item.productId}`}
                                    onError={(e) => e.target.src = '/placeholder.jpg'}
                                />
                            </div>
                            <div className="product-details">
                                <h3>{product?.name || `Product ${item.productId}`}</h3>
                                <p>{product?.description}</p>
                                <p className="price">${product?.price?.toFixed(2) || '0.00'} each</p>
                                <div className="quantity-control">
                                    <span>Quantity: {item.quantity}</span>
                                </div>
                                <p className="item-total">
                                    Total: ${calculateItemTotal(item.productId, item.quantity).toFixed(2)}
                                </p>
                            </div>
                        </div>
                    );
                })}
            </div>
            <div className="cart-summary">
                <h3>Cart Total: ${calculateCartTotal().toFixed(2)}</h3>
                <button className="checkout-button">Proceed to Checkout</button>
            </div>
        </div>
    );
}
export default CartPage;