
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



update EMPLOYEE
set name = 'Anubha',
dept = 'HR'
where empId =2

select name,dept from EMPLOYEE
select * from EMPLOYEE order by empId desc
select * from EMPLOYEE order by dept asc

select * from EMPLOYEE where empId = 1 and name = 'Clark'
select * from EMPLOYEE where name like '%a'
select * from EMPLOYEE where name not like '%a'
--select distint * from EMPLOYEE
select top 2 * from EMPLOYEE

select * from EMPLOYEE where empId between 2 and 3

select LEN('OUR STRING') as Length_of_String
select LEFT('DELHI',2) as city
select right('Delhi',3) as city
select trim('stream') as trimmed
select DATEDIFF(year,'2020/11/23','2024/06/17') as DaysThisyear

insert  into EMPLOYEE values('shriya','HR',Year('2020/12/13'), GETDATE())
--alter table employee

SELECT * FROM EMPLOYEE;