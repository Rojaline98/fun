create table Orders (
order_id INT,
customer_id INT,
order_date DATE,
total_amount DECIMAL(10,2)
);
INSERT INTO Orders (order_id, customer_id, order_date, total_amount) VALUES (1, 101, '2024-07-15', 150.50), (2, 102, '2024-07-14', 200.25), (3, 103, '2024-07-12', 75.80), (4, 104, '2024-07-13', 300.00);
SELECT * FROM Orders;

create table OrderItems (
order_id INT,
product_id INT,
quantity INT,
price DECIMAL(10,2)
);
INSERT INTO OrderItems (order_id, product_id, quantity, price) VALUES (1, 101, 2, 25.50), (2, 102, 1, 50.00), (3, 103, 4, 10.75), (4, 104, 3, 30.00);
select * from OrderItems;

SELECT TOP 5 customer_id, SUM(total_amount) AS total_spent FROM Orders WHERE order_date >= DATEADD(month, -1, GETDATE()) GROUP BY customer_id ORDER BY total_spent DESC;

create table Employees (
employee_id INT,
name VARCHAR(100),
department VARCHAR(100)
);
INSERT INTO Employees (employee_id, name, department) VALUES (1,'Shriya Singh', 'IT'), (2,'Sunil Kumar', 'HR'), (3,'Susil', 'Digital');  
SELECT * FROM Employees;

CREATE TABLE Attendance (
employee_id INT,
date DATE,
status VARCHAR(50),
--FOREIGN KEY (employee_id) REFERENCES Employees(employee_id)
);
INSERT INTO Attendance (employee_id, date, status) VALUES (1, '2024-07-01', 'Present'), (1, '2024-07-02', 'Present'), (2, '2024-07-01', 'Absent'), (2, '2024-07-02', 'Present'), (3, '2024-07-01', 'Present'), (3, '2024-07-02', 'Absent');
SELECT * FROM Attendance;

SELECT e.name, COUNT(a.status) AS present_days FROM Employees e JOIN Attendance a ON e.employee_id = a.employee_id  WHERE a.status = 'Present' AND a.date >= DATEADD(month, -3, GETDATE()) GROUP BY e.name; 

CREATE TABLE Customers (
customer_id INT,
name VARCHAR(50),
region VARCHAR(50)
);
INSERT INTO Customers (customer_id, name, region) VALUES  (1, 'Sunil', 'America'), (2, 'Susil', 'Austrelia'), (3, 'Titi', 'India'), (4, 'Google', 'Europe');
select * from Customers; 

CREATE TABLE Purchases (
purchase_id INT,
customer_id INT, 
purchase_date DATE,
amount DECIMAL(10,2)
);

INSERT INTO Purchases (purchase_id, customer_id, purchase_date, amount) VALUES (1, 1, '2023-01-10', 100.00), (2, 2, '2023-02-15', 75.20), (3, 3, '2023-03-20', 200.00), (4, 4, '2023-04-25', 150.75); 
select * from Purchases;

SELECT region, AVG(total_amount) AS avg_purchase FROM (SELECT c.region, p.customer_id, SUM(p.amount) AS total_amount FROM Customers c JOIN Purchases p ON c.customer_id = p.customer_id GROUP BY c.region, p.customer_id) AS regional_purchases GROUP BY region ORDER BY avg_purchase DESC; 

CREATE TABLE Sales(
sale_id INT,
product_id INT,
sale_date DATE,
amount DECIMAL(10,2)
); 
INSERT INTO Sales (sale_id, product_id, sale_date, amount) VALUES (1, 1, '2024-01-10', 200.00), (2, 2, '2024-02-15', 250.00), (3, 3, '2024-03-20', 150.00), (4, 4, '2024-04-25', 300.00);
SELECT * FROM Sales;



CREATE TABLE Products(
product_id INT,
category VARCHAR(50)
); 
INSERT INTO Products (product_id, category) VALUES (1, 'Books'), (2, 'Clothing'), (3, 'Home'), (4, 'Toys');
select * from Products;

SELECT p.category, MONTH(s.sale_date) AS sale_month, SUM(s.amount) AS total_sales 
FROM Sales s         
JOIN Products p ON s.product_id = p.product_id        
WHERE YEAR(s.sale_date) = YEAR(GETDATE())        
GROUP BY p.category, MONTH(s.sale_date)        
ORDER BY p.category, sale_month; 

CREATE TABLE Patients (
patient_id INT PRIMARY KEY,
name VARCHAR(50),
age INT
);
INSERT INTO Patients (patient_id, name, age) VALUES (1,'Shriya Singh', 35), (2,'Sunil Kumar', 28), (3,'Susil', 45);
SELECT * FROM Patients;

CREATE TABLE Visits1 (
visit_id INT PRIMARY KEY,
patient_id INT,
visit_date DATE, 
diagnosis VARCHAR(100),
FOREIGN KEY (patient_id) REFERENCES Patients(patient_id)
); 

INSERT INTO Visits1 (visit_id, patient_id, visit_date, diagnosis) VALUES (1, 1, '2025-01-10', 'Fever'), (2, 2, '2025-02-15', 'headache'), (3, 3, '2025-05-20', 'cough and cold');
SELECT * FROM Visits1;

SELECT p.name, COUNT(v.visit_id) AS visit_count
FROM Patients p 
JOIN Visits1 v ON p.patient_id = v.patient_id 
WHERE v.visit_date >= DATEADD(year, -1, GETDATE()) 
GROUP BY p.name
HAVING COUNT(v.visit_id) > 3; 


CREATE TABLE Accounts (
account_id INT,
customer_id INT, 
balance Decimal(10,2)
);
INSERT INTO Accounts (account_id, customer_id, balance) VALUES (1, 101, 1200.00), (2,102, 1000.00), (3, 103, 200.00);
SELECT * FROM Accounts;


CREATE TABLE Transactions (
transaction_id INT,
account_id INT,
transaction_date DATE,
amount DECIMAL(10,2),
type VARCHAR(50) 
);

INSERT INTO Transactions (transaction_id, account_id, transaction_date, amount, type) VALUES (1, 1, '2024-07-15', 200.00, 'Deposit'), (2, 2, '2024-07-12', 100.00, 'Withdrawal'), (3, 3, '2024-07-10', 300.00, 'Deposit');
SELECT * FROM Transactions;

 SELECT account_id,  
 SUM(CASE WHEN type = 'Deposit' THEN amount ELSE 0 END) AS total_deposits,     
 SUM(CASE WHEN type = 'Withdrawal' THEN amount ELSE 0 END) AS total_withdrawals   
 FROM Transactions  
 WHERE transaction_date >= DATEADD(month, -6, GETDATE())    
 GROUP BY account_id; 

CREATE TABLE Students (
student_id INT PRIMARY KEY, 
name VARCHAR (50),
major VARCHAR (50)
);
INSERT INTO Students (student_id, name, major) VALUES (1, 'Sunil', 'Physics'), (2, 'Gulu', 'MATHS'), (3, 'lipi', 'Biology');
select * from Students;

CREATE TABLE Courses (
course_id INT PRIMARY KEY,
course_name VARCHAR(50)
); 
INSERT INTO Courses ( course_id, course_name) VALUES (101, 'SCIENCE'), (102, 'PCM'), (103, 'CBZ');
SELECT * FROM Courses;

CREATE TABLE Enrollments (
enrollment_id INT PRIMARY KEY,
student_id INT, 
course_id INT,
enrollment_date DATE
);
INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) VALUES (1, 1, 101, '2024-07-01'), (2, 2, 102, '2024-07-02'), (3, 3, 103, '2024-07-04');
SELECT * FROM Enrollments;

SELECT c.course_name, COUNT(e.student_id) AS student_count       
FROM Courses c 
JOIN Enrollments e ON c.course_id = e.course_id
GROUP BY c.course_name   
ORDER BY student_count DESC; 

