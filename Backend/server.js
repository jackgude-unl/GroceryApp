const express = require('express');
const cors = require('cors');
const sql = require('mssql');

const app = express();
app.use(cors());
app.use(express.json()); 


const dbConfig = {
    server: 'localhost', 
    port: 1433, 
    database: 'CSCE361',
    user: 'gmiel', 
    password: 'Grant7400!', 
    options: {
        encrypt: false, 
        enableArithAbort: true,
    },
};


app.get('/test-connection', async (req, res) => {
    try {
        console.log('Attempting to connect to the database...');
        await sql.connect(dbConfig); 
        res.json({ message: 'Database connection successful' });
    } catch (err) {
        console.error('Database connection failed:', err); // Log detailed error
        res.status(500).json({ error: 'Database connection failed', details: err.message });
    }
});

// Get all products
app.get('/products', async (req, res) => {
    try {
        const connection = await sql.connect(dbConfig);
        const result = await connection.request().query('SELECT * FROM Products'); 
        res.json(result.recordset);
        connection.close();
    } catch (err) {
        console.error('Error fetching products:', err);
        res.status(500).json({ error: 'Failed to fetch products', details: err.message });
    }
});


// Get product by ID
app.get('/products/:id', async (req, res) => {
    try {
        const productId = req.params.id;
        const connection = await sql.connect(dbConfig);
        const result = await connection.request()
            .input('ProductId', sql.Int, productId) // Parameterized query
            .query('SELECT * FROM Products WHERE ProductID = @ProductId');
        if (result.recordset.length === 0) {
            return res.status(404).json({ error: 'Product not found' });
        }
        res.json(result.recordset[0]);
        connection.close();
    } catch (err) {
        console.error('Error fetching product by ID:', err);
        res.status(500).json({ error: 'Failed to fetch product' });
    }
});

// Start the server
const PORT = 8081;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});

