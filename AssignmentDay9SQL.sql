-- Create the database
--CREATE DATABASE BookStoreDB;
--GO

USE BookStoreDB;
GO

-- Create Tables with Constraints
CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    Country NVARCHAR(100) NOT NULL
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL UNIQUE,
    AuthorID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    PublishedYear INT NOT NULL,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL,
    OrderDate DATE NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY,
    OrderID INT NOT NULL,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    SubTotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- DML: Insert Data
INSERT INTO Authors (Name, Country) VALUES 
('Chetan Bhagat', 'India'),
('Ravinder Singh', 'India'),
('Amish Tripathi', 'India'),
('Ruskin Bond', 'India'),
('R.K. Narayan', 'India');

INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES 
('Five Point Someone', 1, 500, 2004),
('I Too Had a Love Story', 2, 300, 2008),
('The Immortals of Meluha', 3, 600, 2010),
('The Blue Umbrella', 4, 250, 1974),
('Malgudi Days', 5, 400, 1943);

INSERT INTO Customers (Name, Email, PhoneNumber) VALUES 
('Amit Sharma', 'amit.sharma@example.com', '9876543210'),
('Pooja Verma', 'pooja.verma@example.com', '8765432109'),
('Rahul Mehta', 'rahul.mehta@example.com', '7654321098'),
('Sneha Iyer', 'sneha.iyer@example.com', '6543210987'),
('Jay Patel', 'jay.patel@example.com', '5432109876');

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES 
(1, '2024-01-15', 900),
(2, '2024-02-10', 600),
(3, '2024-03-05', 300),
(1, '2024-03-25', 500),
(4, '2024-04-01', 400);

INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal) VALUES 
(1, 1, 2, 1000),
(1, 3, 1, 600),
(2, 5, 1, 400),
(3, 2, 1, 300),
(4, 1, 1, 500);

-- DML: Update & Delete
UPDATE Books SET Price = Price * 1.1 WHERE Title = 'The Immortals of Meluha';
DELETE FROM Customers WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders);

-- Operators Queries
SELECT * FROM Books WHERE Price > 500;
SELECT COUNT(*) AS TotalBooks FROM Books;
SELECT * FROM Books WHERE PublishedYear BETWEEN 2015 AND 2023;
SELECT DISTINCT Customers.* FROM Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID;
SELECT * FROM Books WHERE Title LIKE '%Love%';
SELECT TOP 1 * FROM Books ORDER BY Price DESC;
SELECT * FROM Customers WHERE Name LIKE 'A%' OR Name LIKE 'J%';
SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders;

-- Joins Queries
SELECT Books.Title, Authors.Name FROM Books INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID;
SELECT Customers.Name, Orders.OrderID FROM Customers LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID;
SELECT * FROM Books WHERE BookID NOT IN (SELECT DISTINCT BookID FROM OrderItems);
SELECT Customers.Name, COUNT(Orders.OrderID) AS OrderCount FROM Customers LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID GROUP BY Customers.Name;
SELECT Books.Title, OrderItems.Quantity FROM OrderItems INNER JOIN Books ON OrderItems.BookID = Books.BookID;
SELECT Customers.Name, Orders.OrderID FROM Customers LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID;
SELECT Authors.Name FROM Authors LEFT JOIN Books ON Authors.AuthorID = Books.AuthorID WHERE Books.BookID IS NULL;