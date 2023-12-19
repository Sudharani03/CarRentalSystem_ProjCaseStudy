using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_CaseStudy_Final.Model
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int DailyRate { get; set; }
        public string Status { get; set; }
        public int PassengerCapacity { get; set; }
        public int EngineCapacity { get; set; }

        //Parameterized constructor 

        public Vehicle(int vehicleId, string make, string model, int year, int dailyRate, string status, int passengerCapacity, int engineCapacity)
        {
            VehicleId = vehicleId;
            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            Status = status;
            PassengerCapacity = passengerCapacity;
            EngineCapacity = engineCapacity;

        }
        //default constructor 
        public Vehicle()
        {
        }

        public override string ToString()
        {
            return $"ID : {VehicleId}\t Vehicle Name : {Make + " " + Model}\t Year : {Year}\t DailyRate : {DailyRate}\t Status : {Status}\t PassengerCapacity: {PassengerCapacity}\t EngineCapacity: {EngineCapacity}";
        }
    }
}
