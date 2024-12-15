const sql = require('mssql');

const config = {
    user: '', 
    password: '', 
    server: 'localhost',
    database: 'CSCE361', 
    options: {
        encrypt: false, 
        enableArithAbort: true, 
    },
};

// Create a pool of connections
const poolPromise = new sql.ConnectionPool(config)
    .connect()
    .then(pool => {
        console.log('Connected to SQL Server');
        return pool;
    })
    .catch(err => {
        console.error('Database Connection Failed:', err);
        throw err;
    });

module.exports = {
    sql,
    poolPromise,
};

