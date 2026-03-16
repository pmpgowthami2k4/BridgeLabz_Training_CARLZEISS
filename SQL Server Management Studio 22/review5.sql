USE REVIEW8 
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL UNIQUE,
    Price DECIMAL(10,2) NOT NULL CHECK (Price > 0),
    Stock INT NOT NULL CHECK (Stock >= 0),
    CreatedDate DATE DEFAULT GETDATE()
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Phone VARCHAR(15) UNIQUE,
    City VARCHAR(50),
    CreatedDate DATE DEFAULT GETDATE()
);

CREATE TABLE Bills (
    BillID INT PRIMARY KEY,
    CustomerID INT NOT NULL,
    BillDate DATE DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) DEFAULT 0 CHECK (TotalAmount >= 0),

    CONSTRAINT fk_Bills_Customers
    FOREIGN KEY (CustomerID)
    REFERENCES Customers(CustomerID)
);

CREATE TABLE BillItems (
    BillItemID INT PRIMARY KEY,
    BillID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(10,2) NOT NULL CHECK (Price > 0),

    CONSTRAINT fkBillItemsBills
    FOREIGN KEY (BillID)
    REFERENCES Bills(BillID),

    CONSTRAINT fkBillItemsProducts
    FOREIGN KEY (ProductID)
    REFERENCES Products(ProductID)
);

--trigger for stock
CREATE TRIGGER trg_ReduceStock
ON BillItems
AFTER INSERT
AS
BEGIN
UPDATE Products
SET Stock = Stock - Quantity
FROM inserted
WHERE Products.ProductID = inserted.ProductID;

END;

--bill func
CREATE FUNCTION fn_CalcBill (@BillID INT)
RETURNS DECIMAL(10,2)
AS
BEGIN
DECLARE @Total DECIMAL(10,2)

SELECT @Total = SUM(Quantity * Price)
FROM BillItems
WHERE BillID = @BillID

RETURN @Total
END;

--revenue func
CREATE FUNCTION fn_TotalRevenue()
RETURNS DECIMAL(10,3)
AS
BEGIN
DECLARE @Revenue DECIMAL(10,3)

SELECT @Revenue = SUM(TotalAmount)
FROM Bills

RETURN @Revenue
END;

--procedure w transaction
CREATE OR aLTER  PROCEDURE CreateBill
@BillID INT,
@CustomerID INT,
@ProductID INT,
@Quantity INT

AS
BEGIN
--trnsction
BEGIN TRANSACTION

DECLARE @Stock INT
DECLARE @Price DECIMAL(10,2)

SELECT @Stock = Stock, @Price = Price
FROM Products
WHERE ProductID = @ProductID

IF @Stock < @Quantity
BEGIN
PRINT 'Insufficient Stock'
ROLLBACK
RETURN
END

ELSE
INSERT INTO Bills (BillID, CustomerID)
VALUES (@BillID, @CustomerID)

    

DECLARE @Total DECIMAL(10,2)

SET @Total = dbo.fn_CalcBill(@BillID)

UPDATE Bills
SET TotalAmount = @Total
WHERE BillID = @BillID

COMMIT

--TO BE COMPLETED! :(
    
END;

--exec
EXEC CreateBill 1,101,1,2;



--view
CREATE VIEW DailySalesReport AS
SELECT 
BillDate,
SUM(TotalAmount) AS DailyRevenue,
COUNT(BillID) AS TotalBills
FROM Bills
GROUP BY BillDate;

SELECT * from DailySalesReport

--top selling product
SELECT ProductName
FROM Products
WHERE ProductID =
(
    SELECT TOP 1 ProductID
    FROM BillItems
    GROUP BY ProductID
    ORDER BY SUM(Quantity) DESC
);

-----INSERTION
INSERT INTO Products (ProductID, ProductName, Price, Stock)
VALUES
(1, 'Pen', 10.00, 100),
(2, 'Notebook', 50.00, 200),
(3, 'Pencil', 5.00, 150),
(4, 'Eraser', 3.00, 80),
(5, 'Marker', 25.00, 60);

INSERT INTO Customers (CustomerID, CustomerName, Phone, City)
VALUES
(101, 'Arun', '9876543210', 'Chennai'),
(102, 'Priya', '9876543211', 'Madurai'),
(103, 'Karthik', '9876543212', 'Coimbatore'),
(104, 'Divya', '9876543213', 'Trichy');

EXEC CreateBill 4,101,1,2;


INSERT INTO BillItems (BillItemID, BillID, ProductID, Quantity, Price)
VALUES
(1, 1, 1, 2, 10.00),
(2, 1, 2, 1, 50.00);

SELECT * FROM Products
SELECT * FROM Bills
SELECT * FROM BillItems
SELECT * FROM DailySalesReport
