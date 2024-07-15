CREATE TABLE Sales ( 
SaleID INT PRIMARY KEY, 
ProductID INT, 
SaleDate DATE, 
SaleAmount DECIMAL(10, 2) 
);
INSERT INTO Sales (SaleID, ProductID, SaleDate, SaleAmount) VALUES (1, 101, '2024-01-01', 150.00), (2, 102, '2024-01-03', 200.00), (3, 101, '2024-01-07', 100.00), (4, 103, '2024-01-10', 250.00), (5, 102, '2024-01-15', 300.00);
select * from Sales;
SELECT AVG(SaleAmount) AS AverageSaleAmount FROM Sales;

SELECT ProductID, MAX(SaleAmount) AS MaxSaleAmount FROM Sales GROUP BY ProductID; 

SELECT YEAR(SaleDate) AS Year, MONTH(SaleDate) AS Month, COUNT(*) AS SalesCount FROM Sales GROUP BY YEAR(SaleDate), MONTH(SaleDate); 

CREATE TABLE Products ( 
ProductID INT PRIMARY KEY, 
ProductName VARCHAR(100)
);

INSERT INTO Products (ProductID, ProductName) VALUES (101, 'Product A'), (102, 'Product B'), (103, 'Product C'), (104, 'Product D'); 

select * from Products;

SELECT p.ProductID, p.ProductName FROM Products p LEFT JOIN Sales s ON p.ProductID = s.ProductID WHERE s.SaleID IS NULL; 

SELECT ProductID, SUM(SaleAmount) AS TotalSalesAmount FROM Sales GROUP BY ProductID;

SELECT * FROM Sales WHERE DATEPART(WEEKDAY, SaleDate) IN (1, 7); 

SELECT SaleID, ProductID, SaleAmount, RANK() OVER (ORDER BY SaleAmount DESC) AS SaleRank FROM Sales; 

SELECT TOP 3 SaleID, ProductID, SaleAmount FROM Sales ORDER BY SaleAmount DESC; 

WITH YearlySales AS ( SELECT YEAR(SaleDate) AS Year, SUM(SaleAmount) AS TotalSales FROM Sales GROUP BY YEAR(SaleDate) ) SELECT Year, TotalSales, LAG(TotalSales) OVER (ORDER BY Year) AS PreviousYearSales, (TotalSales - LAG(TotalSales) OVER (ORDER BY Year)) / LAG(TotalSales) OVER (ORDER BY Year) * 100 AS SalesGrowth FROM YearlySales;

SELECT ProductID, SaleDate, SaleAmount, COUNT(*) AS Count FROM Sales GROUP BY ProductID, SaleDate, SaleAmount HAVING COUNT(*) > 1; 