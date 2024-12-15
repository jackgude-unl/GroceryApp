const db = require('./db'); // MySQL connection setup

class Product {
    constructor(productId, name, description, price) {
        this.productId = productId;
        this.name = name;
        this.description = description;
        this.price = price;
    }
}

class ProductAccessor {
    // Get all products
    async getAllProducts() {
        const query = 'SELECT * FROM Products';
        try {
            const [rows] = await db.promise().query(query);
            return rows.map(row => new Product(row.ProductID, row.ProductName, row.ProductDescription, row.Price));
        } catch (error) {
            console.error('Error fetching all products:', error);
            throw error;
        }
    }

    // Get products by category ID
    async getProductsByCategoryId(categoryId) {
        const query = `
            SELECT p.ProductID, p.ProductName, p.ProductDescription, p.Price
            FROM Categories c
            JOIN CategoriesProducts cp ON c.CategoryID = cp.CategoryID
            JOIN Products p ON p.ProductID = cp.ProductID
            WHERE c.CategoryID = ?`;
        try {
            const [rows] = await db.promise().query(query, [categoryId]);
            return rows.map(row => new Product(row.ProductID, row.ProductName, row.ProductDescription, row.Price));
        } catch (error) {
            console.error('Error fetching products by category ID:', error);
            throw error;
        }
    }

    // Get products on sale
    async getProductsOnSale() {
        const query = `
            SELECT p.ProductID, p.ProductName, p.ProductDescription, p.Price
            FROM Sales s
            JOIN SalesCategories sc ON s.SaleID = sc.SaleID
            JOIN CategoriesProducts cp ON cp.CategoryID = sc.CategoryID
            JOIN Products p ON p.ProductID = cp.ProductID
            WHERE s.StartDate < NOW() AND s.EndDate > NOW()`;
        try {
            const [rows] = await db.promise().query(query);
            return rows.map(row => new Product(row.ProductID, row.ProductName, row.ProductDescription, row.Price));
        } catch (error) {
            console.error('Error fetching products on sale:', error);
            throw error;
        }
    }

    // Get a product by ID
    async getProductById(productId) {
        const query = 'SELECT * FROM Products WHERE ProductID = ?';
        try {
            const [rows] = await db.promise().query(query, [productId]);
            if (rows.length === 0) {
                return null;
            }
            const row = rows[0];
            return new Product(row.ProductID, row.ProductName, row.ProductDescription, row.Price);
        } catch (error) {
            console.error('Error fetching product by ID:', error);
            throw error;
        }
    }
}

module.exports = new ProductAccessor();
