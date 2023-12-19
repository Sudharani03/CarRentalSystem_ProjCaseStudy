using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem_CaseStudy_Final.Model;
using System.Data.SqlClient;
using CarRentalSystem_CaseStudy_Final.Utility;
using System.Numerics;
using CarRentalSystem_CaseStudy_Final.Exceptions;
using System.Data.Common;
using System.Linq.Expressions;

namespace CarRentalSystem_CaseStudy_Final.Repository
{
    public class CarLeaseRepositoryImpl : ICarLeaseRepository
    {

        public string connectionString;
        SqlCommand cmd = null;

        public CarLeaseRepositoryImpl()
        {
            connectionString = DbConnectionUtility.GetConnectionString();
            cmd = new SqlCommand();
        }

        // CAR MANAGEMENT

        #region --->Display All Vehicles
        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Vehicles";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleId = (int)reader["vehicleID"];
                    vehicle.Make = (string)reader["make"];
                    vehicle.Model = (string)reader["model"];
                    vehicle.Year = (int)reader["Year"];
                    vehicle.DailyRate = (int)reader["DailyRate"];
                    vehicle.Status = (string)reader["status"];
                    vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                    vehicle.EngineCapacity = (int)reader["EngineCapacity"];

                    vehicles.Add(vehicle);
                }
                return vehicles;
            }
        }
        #endregion


        #region ----> Add Car

        public int AddCar(Vehicle car)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Insert into Vehicles (Make , Model , Year , DailyRate , Status , PassengerCapacity , EngineCapacity) values (@Make ,@Model , @Year , @DailyRate , @Status , @PassengerCapacity , @EngineCapacity)";
                cmd.Parameters.AddWithValue("@Make", car.Make);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@DailyRate", car.DailyRate);
                cmd.Parameters.AddWithValue("@Status", car.Status);
                cmd.Parameters.AddWithValue("@PassengerCapacity", car.PassengerCapacity);
                cmd.Parameters.AddWithValue("@EngineCapacity", car.EngineCapacity);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addCarStatus = cmd.ExecuteNonQuery();
                if (addCarStatus > 0)
                {
                    Console.WriteLine($"{addCarStatus} Car Added Successfully !!!!!!!!!!");
                }
                else
                {
                    Console.WriteLine("There Was Error while Adding Car !!!!!!!!!!!!!!!");
                }

                return addCarStatus;

            }
        }
        #endregion


        #region  --->Remove Car

        public int RemoveCar(int carID)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Delete from Vehicles Where vehicleId = @CarID";
                cmd.Parameters.AddWithValue("@CarID", carID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deleteProductStatus = cmd.ExecuteNonQuery();
                if (deleteProductStatus > 0)
                {
                    Console.WriteLine($"{deleteProductStatus} Product Deleted SuccessFully !!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    throw new CarNotFoundException("Invalid CarID Entered !!!!!!!!!!!!!!!!!\n");
                }
                cmd.Parameters.Clear();
                return deleteProductStatus;
            }
        }
        #endregion


        #region---> Find Available Cars

        public List<Vehicle> ListAvailableCars()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Vehicles WHERE status = 'available'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleId = (int)reader["vehicleID"];
                    vehicle.Make = (string)reader["make"];
                    vehicle.Model = (string)reader["model"];
                    vehicle.Year = (int)reader["Year"];
                    vehicle.DailyRate = (int)reader["DailyRate"];
                    vehicle.Status = (string)reader["status"];
                    vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                    vehicle.EngineCapacity = (int)reader["EngineCapacity"];
                    vehicles.Add(vehicle);
                }
                return vehicles;
            }
        }
        #endregion


        #region --->Find Rented Cars

        public List<Vehicle> ListRentedCars()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Vehicles WHERE status = 'notAvailable'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleId = (int)reader["vehicleID"];
                    vehicle.Make = (string)reader["make"];
                    vehicle.Model = (string)reader["model"];
                    vehicle.Year = (int)reader["Year"];
                    vehicle.DailyRate = (int)reader["DailyRate"];
                    vehicle.Status = (string)reader["status"];
                    vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                    vehicle.EngineCapacity = (int)reader["EngineCapacity"];
                    vehicles.Add(vehicle);
                }
                return vehicles;
            }
        }
        #endregion


        #region ---->Find Car By Id

        public List<Vehicle> FindCarById(int carID)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Vehicles WHERE vehicleID = @C_Id";
                cmd.Parameters.AddWithValue("@C_Id", carID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleId = (int)reader["vehicleID"];
                    vehicle.Make = (string)reader["make"];
                    vehicle.Model = (string)reader["model"];
                    vehicle.Year = (int)reader["Year"];
                    vehicle.DailyRate = (int)reader["DailyRate"];
                    vehicle.Status = (string)reader["status"];
                    vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                    vehicle.EngineCapacity = (int)reader["EngineCapacity"];
                    vehicles.Add(vehicle);
                }
                cmd.Parameters.Clear();
                if(vehicles.Count() > 0)
                {
                    return vehicles;
                }
                else
                {
                    throw new CarNotFoundException("Sorry, Car not Found , Invalid Id Entered...Exit and Please Enter Valid Id !!\n");
                    
                }
            }
        }
        #endregion



        //CUSTOMERS MANAGEMENT


        #region ---->Display All Customers
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Customers";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerId = (int)reader["customerID"];
                    customer.FirstName = (string)reader["firstName"];
                    customer.LastName = (string)reader["lastName"];
                    customer.Email = (string)reader["email"];
                    customer.PhoneNumber = (string)reader["phoneNumber"];
                    customers.Add(customer);
                }
                return customers;
            }
        }
        #endregion


        #region ---->Add Customer

        public int AddCustomer(Customer customer)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "INSERT INTO Customers VALUES(@FirstName ,@LastName , @Email , @PhoneNumber)";
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addCustomerStatus = cmd.ExecuteNonQuery();
                if (addCustomerStatus > 0)
                {
                    Console.WriteLine($"{addCustomerStatus} Customer Added Successfully !!!!!!!!!!!!!!!\n");
                }
                else
                {
                    Console.WriteLine("There Was Error while Adding Customer !!!!!!!!!!!!!!\n");
                }

                return addCustomerStatus;

            }
        }
        #endregion


        #region ---->Remove Customer

        public int RemoveCustomer(int customerID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Delete from Customers Where customerId = @CustomerID";
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int deleteCustomerStatus = cmd.ExecuteNonQuery();
                if (deleteCustomerStatus > 0)
                {
                    Console.WriteLine($"{deleteCustomerStatus} Customer Deleted SuccessFully !!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    throw new CustomerNotFoundException("Invalid CustomerID Entered !!!!!!!!!!!!!!!!!\n");
                }
                cmd.Parameters.Clear();
                return deleteCustomerStatus;
            }
        }
        #endregion


        #region ---->Find Customer By Id

        public Customer FindCustomerById(int customerID)
        {
            //List<Customer> customers = new List<Customer>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Customers WHERE customerID = @custId";
                cmd.Parameters.AddWithValue("@custId", customerID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                if (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerId = (int)reader["customerID"];
                    customer.FirstName = (string)reader["firstName"];
                    customer.LastName = (string)reader["lastName"];
                    customer.Email = (string)reader["email"];
                    customer.PhoneNumber = (string)reader["phoneNumber"];
                    //customers.Add(customer);

                    return customer;

                }
                //cmd.Parameters.Clear ();
                //if(customers.Count() > 0)
                //{
                //    return customer;
                //}
                else
                {
                    throw new CustomerNotFoundException("Sorry, Customer could not be Found , Invalid Id Entered...Exit and Please Enter Valid Id !!\n");
                }
                
                
            }
        }
        #endregion



        //LEASE MANAGEMENT



        #region --->createLease() method 

        public int CreateLease(int CustomerId, int VehicleId, DateTime StartDate, DateTime EndDate, string Type)
        {
         
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Insert into Lease(VehicleID,CustomerID,StartDate,EndDate,Type) values (@v_Id,@C_Id,@startdate,@enddate,@type)";
                cmd.Parameters.AddWithValue("@v_Id", VehicleId);
                cmd.Parameters.AddWithValue("@C_Id", CustomerId);
                cmd.Parameters.AddWithValue("@startdate",StartDate);
                cmd.Parameters.AddWithValue("@enddate",EndDate);
                cmd.Parameters.AddWithValue("@type", Type);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int addLeaseStatus = cmd.ExecuteNonQuery();

                if (addLeaseStatus > 0)
                {
                    Console.WriteLine($"{addLeaseStatus} Lease Added Successfully!");
                }
                else
                {
                    Console.WriteLine("Error while Adding Lease!!");
                }

                return addLeaseStatus;


            }
        }

        #endregion


        #region   ----->FindLeaseById method 

        public List<Lease> FindLeaseById(int leaseId)
        {
            List<Lease> leases = new List<Lease>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Lease WHERE LeaseID = @L_ID";
                cmd.Parameters.AddWithValue("@L_Id", leaseId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lease lease = new Lease();
                    lease.LeaseId = (int)reader["LeaseId"];
                    lease.VehicleId = (int)reader["VehicleId"];
                    lease.CustomerId = (int)reader["CustomerId"];
                    lease.StartDate = (DateTime)reader["StartDate"];
                    lease.EndDate = (DateTime)reader["EndDate"];
                    lease.Type = (string)reader["Type"];
                    leases.Add(lease);
                }
                cmd.Parameters.Clear();
                if (leases.Count() > 0)
                {
                    return leases;
                }
                else
                {
                    throw new LeaseNotFoundException("Sorry, Car with LeaseId entered not Found , Invalid Id Entered...Exit and Please Enter Valid Id !!\n");

                }
            }
        }
        #endregion


        #region---->listActiveLeases method

        public List<Lease> ListActiveLeases()
        {
            List<Lease> leases = new List<Lease>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Lease where GETDATE() between StartDate and EndDate";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lease lease = new Lease();
                    lease.LeaseId = (int)reader["LeaseId"];
                    lease.VehicleId = (int)reader["VehicleId"];
                    lease.CustomerId = (int)reader["CustomerId"];
                    lease.StartDate = (DateTime)reader["StartDate"];
                    lease.EndDate = (DateTime)reader["EndDate"];
                    lease.Type = (string)reader["Type"];
                    leases.Add(lease);
                }
                int availableLeasesStatus = leases.Count();

                if (availableLeasesStatus > 0)
                {
                    return leases;
                }
                else
                {
                    Console.WriteLine("No Active Leases Present !!!");
                    return leases;
                    
                }
                
            }
        }
        #endregion

        #region ----->listLeaseHistory method

        public List<Lease> ListLeaseHistory()
        {
            List<Lease> leases = new List<Lease>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Lease order by StartDate desc ";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lease lease = new Lease();
                    lease.LeaseId = (int)reader["LeaseId"];
                    lease.VehicleId = (int)reader["VehicleId"];
                    lease.CustomerId = (int)reader["CustomerId"];
                    lease.StartDate = (DateTime)reader["StartDate"];
                    lease.EndDate = (DateTime)reader["EndDate"];
                    lease.Type = (string)reader["Type"];
                    leases.Add(lease);
                }
                return leases;
            }
        }

        #endregion


        //PAYMENT HANDLING 

        # region ---->recordPayment method 

        public void RecordPaymnet(int leaseId , double amount)
        {
            List<Lease> existingLeases = FindLeaseById(leaseId);
            if(existingLeases.Any())
            {
                using(SqlConnection sqlConnection =new SqlConnection(connectionString))
                {
                    cmd.CommandText = "Insert into Payments (LeaseID , PaymentDate , Amount) values (@L_Id ,@PaymentDate, @Amount)";
                    cmd.Parameters.AddWithValue("@L_Id", leaseId);
                    cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int addPaymentStatus = cmd.ExecuteNonQuery();
                    if(addPaymentStatus > 0)
                    {
                        Console.WriteLine($"{addPaymentStatus} Payment added Successfully :)");
                    }
                    else
                    {
                        Console.WriteLine("Addition of Payment Failed :(");
                    }
                }
            }
            else
            {
                throw new LeaseNotFoundException($"Lease with Id {leaseId} not found , please check the leaseid entered ");
            }
            cmd.Parameters.Clear();
        }

        #endregion

    }
}

    
       

