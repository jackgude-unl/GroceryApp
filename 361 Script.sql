IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CSCE361')
BEGIN
	CREATE DATABASE CSCE361;
END;
GO

USE CSCE361;

DROP TABLE  IF EXISTS SalesCategories;
DROP TABLE  IF EXISTS Sales;
DROP TABLE  IF EXISTS CategoriesProducts;
DROP TABLE  IF EXISTS Categories;
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


CREATE TABLE Categories (
    CategoryID INT IDENTITY(1, 1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE CategoriesProducts (    
    CategoryID INT NOT NULL,
	ProductID INT NOT NULL,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);


CREATE TABLE Sales (
    SaleID INT IDENTITY(1, 1) PRIMARY KEY,
    SaleName VARCHAR(100),
    DiscountPercentage DECIMAL(5, 2),
	DiscountValue DECIMAL(8, 2),
    StartDate DATE,
    EndDate DATE
);

CREATE TABLE SalesCategories (
	SaleID INT NOT NULL,
    CategoryID INT NOT NULL,    
    PRIMARY KEY (CategoryID, SaleID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (SaleID) REFERENCES Sales(SaleID)
);



/* ---------------------------------------------------------------------*/



INSERT INTO Users (FirstName, LastName, eMail, UserPassword)
VALUES
	('Alice', 'Adams', 'alice@test.com', 'ecila'),
	('Barry', 'Bobson', 'barryB@test.com', 'barry123'),
	('Carol', 'Craft', 'cc@test.com', 'not-password'),
	('Denise', 'Domino', 'denis@test.com', 'odomino');

INSERT INTO Products (ProductName, ProductDescription, Price)
VALUES
	('Apple', 'Organic Apples - Variety', 1.11),
	('Orange', 'Organic Oranges - Variety', 0.67),
	('Bananas', 'One lb. of Bananas', 0.55),
	('Blueberries', 'One Pint of Blueberries', 2.99),
	('Pear', 'Organic Bartlett Pears', 2.99),
	('Ground Beef', 'One lb. of 80/20 ground beef', 5.99),
	('New York Strip Steak','8 oz New York Strip Steak',8.99),
	('Pork Chops', '1 lb. Boneless Pork Loin Chop', 4.99),
	('Whole Frozen Turkey', '1 lb. Whole Frozen Turkey', 19.99),
	('Salmon Filet', '4 oz Farm Raised Atlantic Salmon', 5.99),
	('Tilapia Fillet', '4 oz Fresh Tilapia', 3.15),
	('Ice Cream', 'One Pint of Ice Cream - Variety', 7.99),
	('Milk', 'One Gallon of Milk', 3.99),
	('Eggs', '1 dozen Grade A Large Eggs', 4.49),
	('Butter', '1 lb. Salted Butter', 4.99),
	('Cheese', '8 oz. Pre-sliced Cheese - Variety', 3.99),
	('Hamburger Buns', '8 Pre-sliced Hamburger Buns', 3.99),
	('Hot Dog Buns', '8 Pre-sliced Hot Dog Buns', 3.99),
	('French Bread', 'French Bread - Baked Fresh Daily', 3.49);

INSERT INTO Carts (UserID)
VALUES
	(1), (2), (3), (4);
	
INSERT INTO CartProducts(CartID, ProductID, Quantity)
VALUES
	(1, 1, 3), (1, 5, 2), (1, 10, 1), (1, 13, 1),
	(2, 7, 2), (2, 15, 1), (2, 19, 1), (2, 4, 1),
	(3, 1, 5), (3, 3, 3), (3, 6, 2), (3, 12, 2), (3, 17, 1),
	(4, 2, 3), (4, 8, 1), (4, 10, 2), (4, 14, 1);

INSERT INTO Categories (CategoryName)
VALUES
	('Meat and Seafood'),
	('Fruits and Vegetables'),
	('Dairy, Eggs, and Cheese'),
	('Bakery'),
	('Frozen'),
	('Vegitarian'),
	('Vegan');

INSERT INTO CategoriesProducts (ProductID, CategoryID)
VALUES
	(1, 2),	(1, 6),	(1, 7),
	(2, 2),	(2, 6),	(2, 7),
	(3, 2),	(3, 6),	(3, 7),
	(4, 2),	(4, 6),	(4, 7),
	(5, 2),	(5, 6),	(5, 7),
	(6, 1),
	(7, 1),
	(8, 1),
	(9, 1),	(9, 5),
	(10, 1),
	(11, 1), (11, 5),
	(12, 3), (12, 5), (12, 6),
	(13, 3), (13, 6),
	(14, 3), (14, 6),
	(15, 3), (15, 6),
	(16, 3), (16, 6),
	(17, 4), (17, 6),
	(18, 4), (18, 6),
	(19, 4), (19, 6), (19, 7);

INSERT INTO Sales (SaleName, DiscountPercentage, DiscountValue, StartDate, EndDate)
VALUES
	('Post-Thanksgiving Sale', 8.0, 0.0, '2024-11-29', '2024-12-20')

INSERT INTO SalesCategories (SaleID, CategoryID)
VALUES
	(1, 1);
