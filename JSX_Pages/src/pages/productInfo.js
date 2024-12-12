import React from 'react';
import '../App.css';

function ProductInfoPage() {
    return(
        <div className="productInfo-page">
            {/* Change the layout of the page to account for product images/information */}
            <h1>Product Name (placeholder)</h1>
            <h3>Unit Price: $</h3>
            <body>Product Description:</body>
            <body>Ratings: </body>
            {/* Update the button perhaps?? */}
            <button className='cartAdd-btn'>Add to cart</button> 
        </div> 
    );
}
export default ProductInfoPage;