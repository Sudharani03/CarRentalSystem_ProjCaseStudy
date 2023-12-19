using CarRentalSystem_CaseStudy_Final.Exceptions;
using CarRentalSystem_CaseStudy_Final.Model;
using CarRentalSystem_CaseStudy_Final.Repository;
namespace CarRentalSystemTest
{
    public class Tests
    {
        private const string connectionString = "Server=LAPTOP-TGF4BFQ1;Database =Car_Rental_Application;Trusted_Connection=True";

        [Test]
        public void TesttoAddCar()
        {
            //Assign
            CarLeaseRepositoryImpl AddCarTest = new CarLeaseRepositoryImpl();
            AddCarTest.connectionString = connectionString;

            //Act

            int addCarStatus = AddCarTest.AddCar(new CarRentalSystem_CaseStudy_Final.Model.Vehicle
            {
                Make = "Mahindra",
                Model = "Thar",
                Year = 2023,
                DailyRate = 10,
                Status="Available",
                PassengerCapacity = 5,
                EngineCapacity = 1000
            });

            //Assert
            Assert.AreEqual(1, addCarStatus);

        }

        [Test]

        public void TestToCreateLease()
        {

            // Arrange
            CarLeaseRepositoryImpl CreateLeaseTest = new CarLeaseRepositoryImpl();
            CreateLeaseTest.connectionString = connectionString;

            // Act
            DateTime StartDate = new DateTime(2023, 12, 01);
            DateTime EndDate = new DateTime(2024, 01, 01);
            int createLeaseStatus = CreateLeaseTest.CreateLease(5, 2, StartDate, EndDate, "MonthlyLease");
            

            // Assert
            Assert.AreEqual(1, createLeaseStatus);

        }

        [Test]

        public void TestToRetrieveLease()
        {
            CarLeaseRepositoryImpl RetrieveLeaseTest = new CarLeaseRepositoryImpl();
            RetrieveLeaseTest.connectionString = connectionString;


            int existingLeaseId = 1;

            // Act
            List<Lease> foundLease = RetrieveLeaseTest.FindLeaseById(existingLeaseId);

            // Assert
            Assert.IsNotNull(foundLease);
            
        }

        [Test]

        public void TestToCustomerNotFoundException()
        {
            CarLeaseRepositoryImpl CustomerException = new CarLeaseRepositoryImpl();
            CustomerException.connectionString = connectionString;

            Assert.Throws<CustomerNotFoundException>(() => CustomerException.FindCustomerById(100));
        }

        [Test]
        
        public void TestToCarNotFoundException()
        {
            CarLeaseRepositoryImpl CarException = new CarLeaseRepositoryImpl();
            CarException.connectionString = connectionString;

            Assert.Throws<CarNotFoundException>(() => CarException.FindCarById(100));
        }
        [Test]
        public void TestToLeaseNotFoundException()
        {
            CarLeaseRepositoryImpl LeaseException = new CarLeaseRepositoryImpl();
            LeaseException.connectionString = connectionString;

            Assert.Throws<LeaseNotFoundException>(() => LeaseException.FindLeaseById(100));
        }

    }
}