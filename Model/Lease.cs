using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_CaseStudy_Final.Model
{
    public class Lease
    {
        public int LeaseId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        //default constructor 

        public Lease() { }

        //Parameterized constructor 

        public Lease(int leaseId, int vehicleId, int customerId, DateTime startDate, DateTime endDate, string type)
        {
            LeaseId = leaseId;
            VehicleId = vehicleId;
            CustomerId = customerId;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
        }

        public override string ToString()
        {
            return $"LeaseId : {LeaseId}\t  VehicleId : {VehicleId}\t  CustomerId : {CustomerId}\t  StartDate : {StartDate}  EndDate : {EndDate}\t  Type : {Type}";
        }
    }
}
