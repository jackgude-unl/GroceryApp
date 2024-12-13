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
	eMail	VARCHAR(100) UNIQUE,
	PasswordHash	BINARY(100),
	PasswordSalt	BINARY(32)
);


CREATE TABLE Products (
	ProductID INT IDENTITY(1, 1) PRIMARY KEY,
	ProductName VARCHAR(100) NOT NULL,
	ProductDescription TEXT,
	Price DECIMAL(8, 2) NOT NULL,
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
/*
Alice - ecila
Barry - barry123
Carol - not-password
Denise - odomino
*/

INSERT INTO Users (FirstName, LastName, eMail, PasswordHash, PasswordSalt)
VALUES
	('Alice', 'Adams', 'alice@test.com', 0x765D09D7544F2F80AF54E2904274CD15C077FEB55FC412211E7E5A7DE619F3892FE0D45DA10A78A7EDAA0EB99DB13CF589039C92D7E9E0F6136857D0F7CBF4EF0C7572833168AD61C54E04D2A9110519413C426A9871D1141113E51A65452E31D97EAD0C, 0x7C9F43EF3116BFA623D459CA1ADFBE2EF265F39D5C366C0F66000D541A287015),
	('Barry', 'Bobson', 'barryB@test.com', 0xA4BB08ED77584B80C9870230F168A0630B8D2CD2B7A9CEC3AF5FDFC509C84E1A0693776915E43006CCF5E700318CE875DD49CA53B9739511E05913FC6A985E427483D18D1D3C678889179FA0F257D99F2628955F9452DAC67A549BA63E4652067FD5E2F1, 0x0351C96590DCFB71C3BE3DD87681B5AB34C1941325825B0843658D868925579F),
	('Carol', 'Craft', 'cc@test.com', 0x4764F2CAA04373C9D063341C26F14AD32D55CDD9167D480F2AF111F23256CD1AB4970237241C95787F51B1DB24B4478795CED13765EB3E92292505A00B87F7AEBB139C60644454A231738174F4960A908B5EABE4BDE437730101243348DFB227C6779293, 0xD69B4A7A64D68FFCF014EE23143B30ADC7B66C9EA7FCD545830C3F2BB7096BD0),
	('Denise', 'Domino', 'denis@test.com', 0x382E7CF61156C74FD106C229432373049DC40A85FF56A43C8640A5B05ED74AB77CC89DB09DA345EF4048CB57752BE9ADFE8C49DA108003A1F678C2F2F972F0F1E7B7D5817BA720A78CEC82FF450EE053D9EB243F4C875B127BE7CE81730EBC42D5490F39, 0x4007AAD833BFD4F9A1B541185CC12A0ED20F6C458E531B6C32499D2838C40723);

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
	('Salmon Fillet', '4 oz Farm Raised Atlantic Salmon', 5.99),
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
