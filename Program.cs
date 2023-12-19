using CarRentalSystem.Service;
using CarRentalSystem_CaseStudy_Final.Model;
using CarRentalSystem_CaseStudy_Final.Repository;
using CarRentalSystem_CaseStudy_Final.Services;

ICarLeaseRepository iCarLeaseRepository = new CarLeaseRepositoryImpl();


ICarLeaseService carLeaseServiceImpl = new CarLeaseServiceImpl();

while (true)
{
    Console.WriteLine("-------------------VEHICLES------------------\n");
    Console.WriteLine("1. GetAllVehicles");
    Console.WriteLine("2. AddCar");
    Console.WriteLine("3. RemoveCar");
    Console.WriteLine("4. ListAvailableCars");
    Console.WriteLine("5. ListRentedCars");
    Console.WriteLine("6. FindCarById");
    Console.WriteLine("\n------------------CUSTOMER-----------------\n");
    Console.WriteLine("7. GetAllCustomers");
    Console.WriteLine("8. AddCustomers");
    Console.WriteLine("9. RemoveCustomer");
    Console.WriteLine("10. FindCustomerById");
    Console.WriteLine("-------------------LEASE----------------------\n");
    Console.WriteLine("11.CreateLease");
    Console.WriteLine("12.FindLeaseById");
    Console.WriteLine("13.ListActiveLeases");
    Console.WriteLine("14.ListLeaseHistory");
    Console.WriteLine("15.RecordPayment");

    Console.WriteLine("-----------------------------------------------\n");
    Console.WriteLine("16.Exit");
    Console.WriteLine("\nEnter Your Choice:: \n");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            carLeaseServiceImpl.GetAllVehicles();
            break;
        case 2:
            carLeaseServiceImpl.AddCar();
            break;
        case 3:
            carLeaseServiceImpl.RemoveCar();
            break;
        case 4:
            carLeaseServiceImpl.ListAvailableCars();
            break;
        case 5:
            carLeaseServiceImpl.ListRentedCars();
            break;
        case 6:
            carLeaseServiceImpl.FindCarById();
            break;
        case 7:
            carLeaseServiceImpl.GetAllCustomers();
            break;
        case 8:
            carLeaseServiceImpl.AddCustomer();
            break;
        case 9:
            carLeaseServiceImpl.RemoveCustomer();
            break;
        case 10:
            carLeaseServiceImpl.FindCustomerById();
            break;
        case 11:
            carLeaseServiceImpl.CreateLease();
            break;
        case 12: 
            carLeaseServiceImpl.FindLeaseById();
            break;
        case 13:
            carLeaseServiceImpl.ListActiveLeases();
            break;
        case 14:
            carLeaseServiceImpl.ListLeaseHistory();
            break;
        case 15:
            carLeaseServiceImpl.RecordPayment();
            break;
        case 16:
            string Result =carLeaseServiceImpl.ExitConsole();
            if (Result.ToLower() == "yes")
            {
                Console.WriteLine("Exited successfully");
                Environment.Exit(0);
                break;
            }
            else
            {
                continue;
            }
       

    }

}

