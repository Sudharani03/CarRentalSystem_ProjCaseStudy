-------------------- Car Management ------------------
--Query 1 :- void addCar(Car car); where car inputs are given by user 
select * from Vehicles 

Declare @Make varchar(50) = 'Skoda ',
@Model varchar(50) = 'Octavia',
@Year int = 2023 ,
@DailyRate int = 100,
@Status varchar(50) = 'Available',
@PassengerCapacity int = 5,
@EngineCapacity int = 90 ;

Insert into Vehicles (Make , Model , Year , DailyRate , Status , PassengerCapacity , EngineCapacity)
values 
(@Make ,@Model , @Year , @DailyRate , @Status , @PassengerCapacity , @EngineCapacity)

--Query 2 :- void removeCar(int carID);

Declare @CarId int = 13

Delete from Vehicles 
where VehicleID = @CarId 

select * from Vehicles 

--Query 3 :- List<Car> listAvailableCars(); --

Select Vehicles.VehicleID , Vehicles.Make , Vehicles.Model , Vehicles.Status
from Vehicles where Vehicles.Status = 'Available'

--Query 4 :- List<Car> listRentedCars();

select * from Vehicles
select * from Lease 


select Vehicles.VehicleID , Vehicles.Make+' '+Vehicles.Model as RentedVehicles 
from Vehicles join Lease 
on Vehicles.VehicleID = Lease.VehicleID 

--Query 5 :- Car findCarById(int carID);

Declare @VehicleID int = 5

select Vehicles.Make+' '+Vehicles.Model as VehicleName
from Vehicles where Vehicles.VehicleID = @VehicleID 




------------ Customer Management ---------------

--Query 1 :- void addCustomer(Customer customer);

select * from Customers 



Declare @FirstName varchar(50) = 'Taylor',
@LastName varchar(50) ='Swift' ,
@Email varchar(60) = 'TaylorSwift@gmail.com' ,
@PhoneNumber varchar(50) = '5698741'

Insert into Customers (FirstName,LastName , Email,PhoneNumber) 
values 
(@FirstName , @LastName , @Email , @PhoneNumber)

--Query 2 :- void removeCustomer(int customerID);

Declare @CustomerID int = 12

Delete from Customers 
where CustomerID = @CustomerID


select * from Customers 

--Query 3 :- List<Customer> listCustomers();

select FirstName+' '+LastName as Customers , PhoneNumber 
from Customers 

--Query 4 :- Customer findCustomerById(int customerID);

Declare @CustomerID int = 5

Select FirstName+' '+LastName as CustomerName , Email,PhoneNumber 
from Customers 
Where CustomerID = @CustomerID 

-------------------Lease Management-----------------

---Query 1 :- Lease createLease(int customerID, int carID, Date startDate, Date endDate,varchar Type);

Declare @v_Id int = 10 , @C_Id int = 10 , @startdate date = '2023-12-01', @enddate date = '2024-01-01' , @type varchar(50)= 'MonthlyLease'

Insert into Lease(VehicleID,CustomerID,StartDate,EndDate,Type) 
values (@v_Id,@C_Id,@startdate,@enddate,@type)

select * from Lease

--Query 2 :- void returnCar(int leaseID);
select * from Lease 
select * from Vehicles

Declare @LeaseId int = 3

select Make+' '+Model from Vehicles 
join Lease on Vehicles.VehicleID = Lease.VehicleID 
where LeaseID = @LeaseId

--Query 3 :- List<Lease> listActiveLeases();

select * from Lease
where GETDATE() between StartDate and EndDate

--Query 4 :- List<Lease> listLeaseHistory();

select * from Lease 
order by StartDate desc 

-------------------Payment Handling ------------------

--Query 1 :void recordPayment(Lease lease, int amount);

select * from Payments
select * from Lease

Declare @L_ID int = 7 , @Amount int = 1000

Insert into Payments (LeaseID , PaymentDate , Amount) 
values 
(@L_Id , GetDate() , @Amount)

--Query 2 :- List<Payment> listPayments(Lease lease);

select * from Payments
select * from Lease

select Payments.PaymentID ,Lease.CustomerID,Payments.PaymentDate, Payments.Amount , Lease.Type 
from Payments join Lease
on Payments.LeaseID = Lease.LeaseID









