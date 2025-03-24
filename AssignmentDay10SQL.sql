-- ====== Database Creation ======
CREATE DATABASE BookStoreDB1;
GO
USE BookStoreDB1;
GO

-- ====== Table Creation ======
CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Country NVARCHAR(100) NOT NULL
);

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    AuthorID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price > 0),
    PublishedYear INT CHECK (PublishedYear BETWEEN 1900 AND 2100),
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15) UNIQUE NOT NULL
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATE NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    SubTotal DECIMAL(10,2) NOT NULL CHECK (SubTotal >= 0),
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderItems_Books FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- ====== Data Insertion ======
INSERT INTO Authors (Name, Country) VALUES 
('Chetan Bhagat', 'India'),
('Amish Tripathi', 'India'),
('Ravinder Singh', 'India'),
('Durjoy Datta', 'India'),
('R.K. Narayan', 'India');

INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES 
('Five Point Someone', 1, 399.99, 2004),
('Immortals of Meluha', 2, 499.99, 2010),
('Can Love Happen Twice?', 3, 299.99, 2011),
('Of Course I Love You!', 4, 350.00, 2008),
('Malgudi Days', 5, 599.00, 1982),
('SQL Mastery', 1, 2200.00, 2019);

INSERT INTO Customers (Name, Email, PhoneNumber) VALUES 
('Akshay Godbole', 'akshay@example.com', '9876543210'),
('Omkar Madhgut', 'omkar@example.com', '8765432109'),
('Prathmesh Aghao', 'prathmesh@example.com', '7654321098'),
('Ajay Patil', 'ajay@example.com', '6543210987'),
('Jay Shah', 'jay@example.com', '5432109876');

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES 
(1, '2024-03-01', 999.99),
(2, '2024-03-02', 1500.00),
(3, '2024-03-03', 299.99),
(4, '2024-03-04', 599.00),
(5, '2024-03-05', 2500.00);

INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal) VALUES 
(1, 1, 1, 399.99),
(2, 2, 1, 499.99),
(3, 3, 1, 299.99),
(4, 5, 1, 599.00),
(5, 6, 1, 2500.00);

-- ====== DML Queries ======
UPDATE Books SET Price = Price * 1.1 WHERE Title = 'SQL Mastery';

DELETE FROM Customers WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders);

-- ====== Operators Queries ======
SELECT * FROM Books WHERE Price > 2000;
SELECT COUNT(*) AS TotalBooks FROM Books;
SELECT * FROM Books WHERE PublishedYear BETWEEN 2015 AND 2023;
SELECT DISTINCT c.* FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID;
SELECT * FROM Books WHERE Title LIKE '%SQL%';
SELECT TOP 1 * FROM Books ORDER BY Price DESC;
SELECT * FROM Customers WHERE Name LIKE 'A%' OR Name LIKE 'J%';
SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders;

-- ====== Joins Queries ======
SELECT b.Title, a.Name AS AuthorName FROM Books b INNER JOIN Authors a ON b.AuthorID = a.AuthorID;
SELECT c.*, o.* FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID;
SELECT * FROM Books WHERE BookID NOT IN (SELECT DISTINCT BookID FROM OrderItems);
SELECT c.Name, COUNT(o.OrderID) AS TotalOrders FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID GROUP BY c.Name;
SELECT oi.OrderID, b.Title, oi.Quantity FROM OrderItems oi INNER JOIN Books b ON oi.BookID = b.BookID;
SELECT c.* FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID;
SELECT * FROM Authors WHERE AuthorID NOT IN (SELECT DISTINCT AuthorID FROM Books);

-- ====== SubQueries ======
SELECT * FROM Customers WHERE CustomerID IN (SELECT CustomerID FROM Orders WHERE OrderDate = (SELECT MIN(OrderDate) FROM Orders));
SELECT TOP 1 CustomerID, COUNT(*) AS OrderCount FROM Orders GROUP BY CustomerID ORDER BY OrderCount DESC;
SELECT * FROM Customers WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders);
SELECT * FROM Books WHERE Price < (SELECT MAX(Price) FROM Books);
SELECT * FROM Customers WHERE (SELECT SUM(TotalAmount) FROM Orders WHERE Customers.CustomerID = Orders.CustomerID) > (SELECT AVG(TotalAmount) FROM Orders);

-- ====== Stored Procedures ======
GO
CREATE PROCEDURE GetCustomerOrders 
    @CustomerID INT
AS
BEGIN
    SELECT * FROM Orders WHERE CustomerID = @CustomerID;
END;
GO

GO
CREATE PROCEDURE GetBooksByPriceRange
    @MinPrice DECIMAL(10,2),
    @MaxPrice DECIMAL(10,2)
AS
BEGIN
    SELECT * FROM Books WHERE Price BETWEEN @MinPrice AND @MaxPrice;
END;
GO

-- ====== Views ======
GO
CREATE VIEW AvailableBooks AS
SELECT BookID, Title, AuthorID, Price, PublishedYear FROM Books;
GO
