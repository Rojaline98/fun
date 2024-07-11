

create table Hostels (
hostel_id INT PRIMARY KEY,
hostel_name VARCHAR(30) UNIQUE,
location VARCHAR(50) NOT NULL,
total_rooms INT NOT NULL CHECK (total_rooms IS NOT NULL),
warden_name VARCHAR(40)

)

insert into Hostels values(201,'alpha','main',50,'roja')
select * from Hostels;


create table Rooms (
Room_id INT PRIMARY KEY,
floor INT NOT NULL,
capacity INT NOT NULL CHECK(CAPACITY>0),
status NVARCHAR(30) CHECK(status='occupied' or status='vacant' or status='under maintenance') DEFAULT 'vacant',
hostel_id INT,FOREIGN KEY (hostel_id) REFERENCES Hostels(hostel_id) ON DELETE CASCADE

)

insert into Rooms values(101,1,4,'vacant',201)
select * from Rooms;


create table Students (

Student_id INT PRIMARY KEY,
Student_name varchar(100) NOT NULL,
Date_of_Birth DATE NOT NULL,
Gender varchar(10) NOT NULL,
Contactnumber varchar(20) UNIQUE NOT NULL,
Email varchar(100) UNIQUE NOT NULL,
Address TEXT NOT NULL,
JoiningDate DATE NOT NULL,
Status VARCHAR(20) DEFAULT 'active',
Room_id INT,FOREIGN KEY (Room_id) REFERENCES Rooms(Room_id) ON DELETE CASCADE

)

insert into Students values(1,'John Deo','1998-07-21','Male','1234567891','johndeo@gmail.com','123 main city','2024-07-03','active',101)

select * from Students;