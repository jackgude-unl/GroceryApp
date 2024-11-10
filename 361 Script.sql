IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CSCE361')
BEGIN
	CREATE DATABASE CSCE361;
END;
GO

USE CSCE361;

DROP TABLE  IF EXISTS CartProducts;
DROP TABLE  IF EXISTS Carts;
DROP TABLE  IF EXISTS Products;
DROP TABLE  IF EXISTS Users;
CREATE TABLE Users (
	UserID INT IDENTITY(1, 1) PRIMARY KEY,
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
	eMail	VARCHAR(100),
	UserPassword	VARCHAR(100)
);

CREATE TABLE Products (
	ProductID INT IDENTITY(1, 1) PRIMARY KEY,
	ProductName VARCHAR(100) NOT NULL,
	ProductDescription TEXT,
	Price DECIMAL(8, 2) NOT NULL,
	ImagePath TEXT
);

CREATE TABLE Carts (
	CartID INT IDENTITY(1, 1) PRIMARY KEY,
	UserID INT NOT NULL,
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE CartProducts (
	CartID INT NOT NULL,
	ProductID INT NOT NULL,
	Quantity INT DEFAULT 1,
	PRIMARY KEY(CartID, ProductID),
	FOREIGN KEY (CartID) REFERENCES Carts(CartID),
	FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Users (FirstName, LastName, eMail, UserPassword)
VALUES
	('Alice', 'Adams', 'alice@test.com', 'ecila'),
	('Barry', 'Bobson', 'barryB@test.com', 'barry123'),
	('Carol', 'Craft', 'cc@test.com', 'not-password'),
	('Denise', 'Domino', 'denise@test.com', 'odomino');

INSERT INTO Products (ProductName, ProductDescription, Price)
VALUES
	('Apple', 'Organic Apples - Variety', 0.99),
	('Orange', 'Organic Oranges - Variety', 1.49),
	('Bananas', 'A bunch of bananas', 2.99),
	('Ice Cream', 'One pint of ice cream - variety', 7.99),
	('Milk', 'One gallon of milk', 3.99);

INSERT INTO Carts (UserID)
VALUES
	(1), (2), (3), (4);
	
INSERT INTO CartProducts(CartID, ProductID, Quantity)
VALUES
	(1, 1, 3),
	(1, 2, 2),
	(2, 2, 4),
	(2, 5, 1),
	(3, 1, 1),
	(3, 3, 1),
	(4, 3, 3),
	(4, 5, 1);

/*
SELECT 
	p.ProductName,
	p.ProductDescription,
	cp.Quantity,
	u.FirstName + ' ' + u.LastName AS FullName,
	cp.Quantity * p.Price AS TotalPrice
FROM CartProducts cp
	JOIN Products p on p.ProductID = cp.ProductID
	JOIN Carts c on c.CartID = cp.CartID
	JOIN Users u on c.UserID = u.UserID
*/