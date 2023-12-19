using CarRentalSystem_CaseStudy_Final.Model;
using CarRentalSystem_CaseStudy_Final.Repository;
using CarRentalSystem_CaseStudy_Final.Exceptions;
using CarRentalSystem_CaseStudy_Final.Utility;
using CarRentalSystem_CaseStudy_Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CarRentalSystem.Service
{
    public class CarLeaseServiceImpl : ICarLeaseService
    {
        ICarLeaseRepository carLeaseRepository;

        public CarLeaseServiceImpl()
        {
            carLeaseRepository = new CarLeaseRepositoryImpl();
        }

        public void GetAllVehicles()
        {
            var vehicles = carLeaseRepository.GetAllVehicles();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        public void AddCar()
        {
            Console.WriteLine("Enter the Make of the Car:: ");
            string make = Console.ReadLine();
            Console.WriteLine("Enter the Model of the Car:: ");
            string model = Console.ReadLine();
            Console.WriteLine("Enter the Manufactured Year of Car");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the status of the Car:: ");
            string status = Console.ReadLine();
            Console.WriteLine("Enter the dailyRate of the Car:: ");
            int dailyRate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the passengercapacity of the Car:: ");
            int passengerCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the enginecapacity of the Car:: ");
            int engineCapacity = int.Parse(Console.ReadLine());
            carLeaseRepository.AddCar(new Vehicle() { Make = make, Model = model, Year = year, DailyRate = dailyRate, Status = status, PassengerCapacity = passengerCapacity, EngineCapacity = engineCapacity });
        }

        public void RemoveCar()
        {
            try
            {
                Console.WriteLine("\nEnter the Id of the Car to be Deleted:: ");
                int carID = int.Parse(Console.ReadLine());
                carLeaseRepository.RemoveCar(carID);
            }
            catch (CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListAvailableCars()
        {
            var vehicles = carLeaseRepository.ListAvailableCars();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        public void ListRentedCars()
        {
            var vehicles = carLeaseRepository.ListRentedCars();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        public void FindCarById()
        {
            try
            {
                Console.WriteLine("Enter the Car ID:: ");
                int carID = int.Parse(Console.ReadLine());
                var vehicles = carLeaseRepository.FindCarById(carID);
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle);
                }
            }catch(CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void GetAllCustomers()
        {
            var customers = carLeaseRepository.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public void AddCustomer()
        {
            Console.WriteLine("Enter the First Name of the Customer:: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name of the Customer:: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the Email of the Customer:: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the PhoneNumber of the Customer:: ");
            string phoneNumber = Console.ReadLine();

            carLeaseRepository.AddCustomer(new Customer() { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber });
        }

        public void RemoveCustomer()
        {
            try
            {
                Console.WriteLine("\nEnter the Id of the Customer to be Deleted:: ");
                int customerID = int.Parse(Console.ReadLine());
                carLeaseRepository.RemoveCustomer(customerID);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        


        public void FindCustomerById()
        {
            Console.WriteLine("Enter the Customer Id :: ");
            int customerID = int.Parse(Console.ReadLine());
            try
            {
                Customer customerfound = carLeaseRepository.FindCustomerById(customerID);
                Console.WriteLine($"CarID :{customerfound.CustomerId}\t Name :{customerfound.FirstName+" "+customerfound.LastName}\t Email :{customerfound.Email}\t PhoneNumber :{customerfound.PhoneNumber}");
            }
            catch(CustomerNotFoundException ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void CreateLease()
        {
            Console.WriteLine("Enter the Customer Id whose lease is to be recorded : ");
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Vehicle id whose lease to be recorded : ");
            int vehicleId = int.Parse(Console.ReadLine());
            Console.WriteLine("Provide the start date of Lease in (yyyy-MM-dd) format:: ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Provide end date of lease in (yyyy-MM-dd) format:: ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Provide the type of lease (DailyLease/MonthlyLease) :: ");
            string type = Console.ReadLine();

            /*Lease newLease = */carLeaseRepository.CreateLease(customerId, vehicleId, startDate, endDate, type);

            Console.WriteLine("Lease Created !!!!");
        }


        public void FindLeaseById()
        {
            try
            {
                Console.WriteLine("Enter Lease Id to return the car and its lease details");
                int leaseID = int.Parse(Console.ReadLine());
                var leases = carLeaseRepository.FindLeaseById(leaseID);
                foreach (var lease in leases)
                {
                    Console.WriteLine(lease);

                }

            }
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListActiveLeases()
        {
            var leases = carLeaseRepository.ListActiveLeases();
            foreach (var lease in leases)
            {
                Console.WriteLine(lease);
            }
        }

        public void ListLeaseHistory()
        {
            var leases = carLeaseRepository.ListLeaseHistory();
            foreach (var lease in leases)
            {
                Console.WriteLine(lease);
            }
        }

        public void RecordPayment()
        {
            Console.WriteLine("Enter the LeaseId :: ");
            int leaseId = int.Parse(Console.ReadLine());
            try
            {
                List<Lease> existingLeases = carLeaseRepository.FindLeaseById(leaseId);
                if (existingLeases.Any())
                {
                    Console.WriteLine("Enter the amount to be added :: ");
                    double Amount = double.Parse(Console.ReadLine());
                    carLeaseRepository.RecordPaymnet(leaseId, Amount);
                }
                else
                {
                    Console.WriteLine($"Lease With Id {leaseId} not Found");
                }
            }
            catch(LeaseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string ExitConsole()
        {
            Console.WriteLine("Do you really want to exit : Yes/No ");
            string res = Console.ReadLine();
            return res;
        }





    }
}