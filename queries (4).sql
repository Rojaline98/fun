
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

--simple view
create VIEW ReportPlace
as
SELECT * from Place
GO

select * from ReportPlace
GO

select placename, placetype from ReportPlace
GO

select * from Place join People on Place.placeid=People.empId
GO

create VIEW ReportPlacePeople

as select * from Place join People
on Place.placeId=People.empId

SELECT * FROM ReportPlacePeople

select placetype, dept from ReportPlacePeople
GO

--complex view
alter VIEW ReportPlacePeople

as select * from Place join People
on Place.placeid=People.empId
GO



declare @age int
set @age= 10
print @age
select @age=max(empage) from People
print @age


alter procedure SP_DisplayMaxAgeOfEmployee
as
declare @age int
set @age=10

select @age = max(EmpAge) from People
print @age
GO
exec SP_DisplayMaxAgeOfEmployee

create procedure SP_Params(@age int, @name varchar(10))
as
select * from People where EmpAge= @age
GO

alter procedure SP_Params(@age int, @name varchar(10) ='default')
as
select * from People where EmpAge= @age

exec SP_WithParams 23


--scalar value functions
create function FindAOC(@radius decimal(10,2))
RETURNS decimal(10,2)
as
BEGIN
declare @area decimal(10,2)
set @area = 3.14 * @radius * @radius
return @area
end

SELECT dbo.FindAOC(2)

--table valued functions
create function GetCustomerOrders1(@placeID int)
RETURNS TABLE AS RETURNS
(
    SELECT *
    FROM Place
    WHERE placeid=@placeid

);
select from GetCustomerOrders1(2)


alter procedure demoTwo2 (@Qty INT, @QtyRetrieved INT =0 OUTPUT, @optional int= 45)
AS
IF @QtyRetrieved = 0
BEGIN
    print 'yay its zero'
END
IF @QtyRetrieved is null
BEGIN
    print 'wtf its null'
END
SET @QtyRetrieved = @Qty
RETURN


declare @QR int
exec demoTwo2 100,@QR OUTPUT,34
print '@QR=' +coalesce(convert(varchar,@QR),'NULL')


--scalar value functions
create function dbo.CalculateDiscount(@price demical(10,2), @discountRate int)
RETURNS decimal(10,2)
AS
BEGIN
  DECLARE @discountAmount decimal(10,2)
  SET @discountAmount = @price * @discountRate/100.0;
  RETURN @price - @discountAmount;
END;

select dbo.CalculateDiscount(23.22,34)

--single valued table functions

CREATE FUNCTION GetMergedTables()
RETURNS TABLE 
AS
RETURN select * from Place
join People on Place.placeid = People.empId
join Product
on Place.placeid= Product.productid
join GFGemployees
on Product.productid = GFGemployees.employee_id
GO
select * from GetMergedTables()

