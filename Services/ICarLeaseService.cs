using CarRentalSystem_CaseStudy_Final.Model;
using CarRentalSystem_CaseStudy_Final.Repository;
using CarRentalSystem_CaseStudy_Final.Services;
using CarRentalSystem_CaseStudy_Final.Utility;
using CarRentalSystem_CaseStudy_Final.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_CaseStudy_Final.Services
{
    public interface ICarLeaseService
    {
        void GetAllVehicles();
        void AddCar();
        void RemoveCar();
        void ListAvailableCars();
        void ListRentedCars();
        void FindCarById();
        void GetAllCustomers();
        void AddCustomer();
        void RemoveCustomer();
        void FindCustomerById();
        void CreateLease();
        void FindLeaseById();
        void ListActiveLeases();
        void ListLeaseHistory();
        void RecordPayment();

        string ExitConsole();
        
    }
}
