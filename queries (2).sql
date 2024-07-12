
-- create
CREATE TABLE EMPLOYEE (
  empId int,
  name varchar(15),
  dept varchar(10)
);

-- insert
INSERT INTO EMPLOYEE(empId,name,dept) VALUES (1, 'Clark', 'Sales');
INSERT INTO EMPLOYEE(empId,name,dept) VALUES (2, 'Dave', 'Accounting');
INSERT INTO EMPLOYEE(empId,name,dept) VALUES (3, 'Ava', 'Sales');

-- fetch 
SELECT * FROM EMPLOYEE;


CREATE TABLE Place (
  placeId int,
  placename varchar(15),
  placedescription varchar(10),
  placetype int,
  visitingemployeeid int,
);

-- insert
INSERT INTO Place(placeid,placename,placedescription,placetype,visitingemployeeid) VALUES (1, 'puri', 'best',100,null);
INSERT INTO Place(placeid,placename,placedescription,placetype,visitingemployeeid) VALUES (2, 'nimapara', 'good',200,3);
INSERT INTO Place(placeid,placename,placedescription,placetype,visitingemployeeid) VALUES (3, 'bbsr', 'better',400,6);

-- fetch 
SELECT * FROM Place;


--join GFGemployees

CREATE TABLE Products (
  productId int,
  productname varchar(15)
);

-- insert
INSERT INTO Products(productId,productname) VALUES (1, 'HP');
INSERT INTO Products(productId,productname) VALUES (2, 'DELL');
INSERT INTO Products(productId,productname) VALUES (3, 'LENOVO');

-- fetch 
SELECT * FROM Products;



select * from Place
join EMPLOYEE on Place.placeid= EMPLOYEE.empId
join Products
on Place.placeid = Products.productid
