CREATE TABLE Inventory( 
item_id INT IDENTITY(1,1) PRIMARY KEY,
product_name VARCHAR (20) NOT NULL, 
stock_level INT
);

INSERT INTO Inventory (product_name, stock_level) VALUES ('ABC',8), ('XYZ',7),('ASD',9);
select * from Inventory;

CREATE TABLE Sales ( 
sale_id INT IDENTITY(1,1) PRIMARY KEY,
item_id INT FOREIGN KEY(item_id) REFERENCES Inventory(item_id),
sale_date DATE,
quantity_sold INT
);

INSERT INTO Sales(item_id,sale_date,quantity_sold) VALUES (1,'2024-11-09',234), (2,'2024-11-08',524), (3,'2024-11-07',744);
select * from Sales;

SELECT i.product_name, i.stock_level - COALESCE (SUM (s.quantity_sold), 0) AS remaining_stock 
FROM Inventory i 
LEFT JOIN Sales s ON i.item_id = s.item_id 
GROUP BY i.product_name, i.stock_level;

CREATE TABLE Flights (
flight_id INT IDENTITY (1,1) PRIMARY KEY, 
item_id INT,
airline VARCHAR(20),
departure_date DATE,
arrival_date DATE
);

INSERT INTO Flights (item_id, airline, departure_date, arrival_date) VALUES (201, 'INDIGO', '2024-11-24','2024-11-24'), (207, 'AIRAKASH', '2024-11-24','2024-11-24'), (208, 'AIRINDIA', '2024-11-24','2024-11-24');
select * from Flights;

CREATE TABLE Passengers (
passenger_id INT,
name VARCHAR(20),
flight_id INT,
FOREIGN KEY (flight_id) REFERENCES Flights (flight_id)
);

INSERT INTO Passengers (passenger_id, name, flight_id) VALUES (101, 'SWATI', 1), (101, 'SANDHYA', 2), (101, 'SUSHREE', 3);
select * from Passengers;


CREATE TABLE Users (
    user_id INT PRIMARY KEY,
    username VARCHAR(50),
    signup_date DATE
);
INSERT INTO Users (user_id, username, signup_date) VALUES (1, 'miu', '2023-07-12'), (2, 'adi', '2023-08-13'), (3, 'subha', '2023-09-16');
select * from Users;

CREATE TABLE Posts (
    post_id INT PRIMARY KEY,
    user_id INT,
    post_date DATE,
    content TEXT,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

INSERT INTO Posts (post_id, user_id, post_date, content) VALUES (1, 1, '2023-05-11', 'Hello'), (2, 2, '2023-06-20', 'Hii'), (3, 3, '2023-07-05', 'Say');
select * from Posts;

CREATE TABLE Likes (
    like_id INT PRIMARY KEY,
    post_id INT,
    user_id INT,
    FOREIGN KEY (post_id) REFERENCES Posts(post_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
INSERT INTO Likes (like_id, post_id, user_id) VALUES (1, 1, 2),  (2, 1, 3),  (3, 2, 1),  (4, 3, 2);
select * from Likes;