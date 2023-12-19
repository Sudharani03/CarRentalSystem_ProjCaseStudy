using CarRentalSystem_CaseStudy_Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_CaseStudy_Final.Repository
{
    public interface ICarLeaseRepository
    {

        //CAR MANAGEMENT
        List<Vehicle> GetAllVehicles();
        int AddCar(Vehicle car);
        int RemoveCar(int carID);
        List<Vehicle> ListAvailableCars();
        List<Vehicle> ListRentedCars();
        List<Vehicle> FindCarById(int carID);

        //CUSTOMER MANAGEMENT
        List<Customer> GetAllCustomers();
        int AddCustomer(Customer customer);
        int RemoveCustomer(int customerId);
        Customer FindCustomerById(int carID);

        //LEASE MANAGEMENT
        int CreateLease(int CustomerId, int VehicleId, DateTime StartDate, DateTime EndDate, string Type);
        List<Lease> FindLeaseById(int leaseId);
        List<Lease> ListActiveLeases();
        List<Lease> ListLeaseHistory();

        //PAYMENT HANDLING
        void RecordPaymnet(int leaseId, double amount);

    }
}
