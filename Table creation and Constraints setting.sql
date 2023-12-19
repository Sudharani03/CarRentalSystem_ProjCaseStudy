--Database :- Car_Rental_Application ---
--Creating tables ---

--Creating Vehicles Table --

Create Table Vehicles (VehicleID int Identity(1,1) Primary key not null ,
Make varchar(50) not null ,
Model varchar(50) not null ,
Year int not null ,
DailyRate int not null,
Status varchar(50) not null ,
PassengerCapacity int not null,
EngineCapacity int  not null ) ;

--Creating Customer Table---

Create Table Customers (CustomerID int Identity(1,1) Primary Key not null ,
FirstName varchar(50) not null,
LastName  varchar(50) not null,
Email varchar(60) not null ,
PhoneNumber int not null);

--Creating Lease Table --

Create Table Lease (LeaseID int Identity(1,1) Primary Key not null ,
VehicleID int not null ,
CustomerID int not null , 
StartDate Date not null ,
EndDate Date not null ,
Type varchar(50) not null,
Foreign key (VehicleID) References Vehicles(VehicleID),
Foreign key (CustomerID) References Customers(CustomerID));

--Creating Payment Table --

Create Table Payments (PaymentID int Identity(1,1) Primary Key not null ,
LeaseID int not null,
PaymentDate Date not null,
Amount int not null ,
Foreign key (LeaseID) References Lease(LeaseID));


