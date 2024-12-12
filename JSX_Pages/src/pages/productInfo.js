import React from 'react';
import '../App.css';

function ProductInfoPage() {
    return(
        <div className="productInfo-page">
            <h1>Product Name</h1>
            <h3>Price</h3>
            <body>Product Description:</body>
            <button className='cartAdd-btn'>Add to cart</button>
        </div> 
    );
}
export default ProductInfoPage;