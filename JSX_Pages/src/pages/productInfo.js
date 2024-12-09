import React from 'react';
import '../App.css';

function productInfoPage() {
    return(
        <div className="productInfo">
            <h1>Product Name</h1>
            <h3>Price</h3>
            <body>Product Description</body>
            <button type="submit">Add to cart</button>
        </div>
    );
}
