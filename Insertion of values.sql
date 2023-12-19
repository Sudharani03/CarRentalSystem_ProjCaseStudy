--Inserting records into tables --

Insert into Vehicles (Make , Model , Year , DailyRate , Status , PassengerCapacity , EngineCapacity )
values 
('Toyota', 'Camry', 2022, 50, 'Available', 5, 60),
('Honda', 'Civic', 2021, 45, 'Available', 5, 90),
('Ford', 'F-150', 2020, 70, 'NotAvailable', 3, 100),
('Chevrolet', 'Malibu', 2022, 55, 'Available', 5, 50),
('Harley-Davidson', 'Sportster', 2021, 80, 'Available', 4, 1200),
('Yamaha', 'YZF-R6', 2020, 75, 'NotAvailable', 2, 600),
('Tesla', 'Model 3', 2022, 100, 'Available', 5, 90),
('Nissan', 'Altima', 2021, 60, 'Available', 5, 90),
('BMW', 'X5', 2022, 90, 'Available', 7, 100),
('Ducati', 'Monster', 2020, 85, 'Available', 2, 800);

select * from Vehicles 

--INSERTING RECORDS INTO CUSTOMERS TABLE ---

Insert into Customers (FirstName , LastName , Email , PhoneNumber)
values
('John', 'Doe', 'john.doe@email.com', 5551234),
('Jane', 'Smith', 'jane.smith@email.com', 5555678),
('Michael', 'Johnson', 'michael.johnson@email.com', 5559876),
('Emily', 'Williams', 'emily.williams@email.com', 5554321),
('Daniel', 'Miller', 'daniel.miller@email.com', 5558765),
('Olivia', 'Davis', 'olivia.davis@email.com', 5552345),
('Christopher', 'Jones', 'christopher.jones@email.com', 5556789),
('Sophia', 'Wilson', 'sophia.wilson@email.com', 5553456),
('Ethan', 'Taylor', 'ethan.taylor@email.com', 5557890),
('Ava', 'Brown', 'ava.brown@email.com', 5554005);

select * from Customers 

--INSERTING RECORDS INTO LEASE TABLE--

Insert into Lease (VehicleID , CustomerID , StartDate , EndDate , Type )
values
(1, 1, '2023-01-01', '2023-01-05', 'DailyLease'),
(2, 2, '2023-02-10', '2023-03-10', 'MonthlyLease'),
(3, 3, '2023-03-15', '2023-03-20', 'DailyLease'),
(4, 4, '2023-04-02', '2023-05-02', 'MonthlyLease'),
(5, 5, '2023-05-10', '2023-05-12', 'DailyLease'),
(6, 6, '2023-06-15', '2023-07-15', 'MonthlyLease'),
(7, 7, '2023-08-01', '2023-08-03', 'DailyLease'),
(8, 8, '2023-09-05', '2023-10-05', 'MonthlyLease'),
(9, 9, '2023-11-10', '2023-11-15', 'DailyLease'),
(10, 10, '2023-12-20', '2023-12-30', 'MonthlyLease');

select * from Lease

--INSERTING RECORDS INTO PAYMENTS TABLE --

Insert into Payments ( LeaseID , PaymentDate , Amount) 
values
(1, '2023-01-01', 500),
(2, '2023-02-01', 600),
(3, '2023-03-01', 700),
(4, '2023-04-01', 800),
(5, '2023-05-01', 900),
(6, '2023-06-01', 1000),
(7, '2023-07-01', 1100),
(8, '2023-08-01', 1200),
(9, '2023-09-01', 1300),
(10, '2023-10-01', 1400);

select * from Payments 


--Retrieving data from all tables --

select * from Customers 
select * from Lease
select * from Payments 
select * from Vehicles

