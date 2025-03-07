CREATE DATABASE BookStoreDB1;
GO
USE BookStoreDB1;
GO

-- Start===============================================================================
CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Country NVARCHAR(100) NOT NULL
);

-- Books Table with basic info
CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    AuthorID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price > 0),
    PublishedYear INT CHECK (PublishedYear BETWEEN 1900 AND 2100),
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

-- Customers Table with basic info
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15) UNIQUE NOT NULL
);

-- Orders Table with info
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATE NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- OrderItems Table with info
CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    SubTotal DECIMAL(10,2) NOT NULL CHECK (SubTotal >= 0),
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderItems_Books FOREIGN KEY (BookID) REFERENCES Books(BookID)
);


--DML Data ============================================================================
-- Insert Authors
INSERT INTO Authors (Name, Country) VALUES 
('Chetan Bhagat', 'India'),
('Amish Tripathi', 'India'),
('Ravinder Singh', 'India'),
('Durjoy Datta', 'India'),
('R.K. Narayan', 'India');

-- Insert Books
INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES 
('Five Point Someone', 1, 399.99, 2004),
('Immortals of Meluha', 2, 499.99, 2010),
('Can Love Happen Twice?', 3, 299.99, 2011),
('Of Course I Love You!', 4, 350.00, 2008),
('Malgudi Days', 5, 599.00, 1982),
('SQL Mastery', 1, 2200.00, 2019);

-- Insert Customers
INSERT INTO Customers (Name, Email, PhoneNumber) VALUES 
('Akshay Godbole', 'akshay@example.com', '9876543210'),
('Omkar Madhgut', 'omkar@example.com', '8765432109'),
('Prathmesh Aghao', 'prathmesh@example.com', '7654321098'),
('Ajay Patil', 'ajay@example.com', '6543210987'),
('Jay Shah', 'jay@example.com', '5432109876');

-- Insert Orders
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES 
(1, '2024-03-01', 999.99),
(2, '2024-03-02', 1500.00),
(3, '2024-03-03', 299.99),
(4, '2024-03-04', 599.00),
(5, '2024-03-05', 2500.00);

-- Insert OrderItems
INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal) VALUES 
(1, 1, 1, 399.99),
(2, 2, 1, 499.99),
(3, 3, 1, 299.99),
(4, 5, 1, 599.00),
(5, 6, 1, 2500.00);
