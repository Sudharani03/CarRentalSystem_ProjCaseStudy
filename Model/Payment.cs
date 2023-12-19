using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_CaseStudy_Final.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int LeaseId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }

        //default constructor

        public Payment() { }

        //Parameterized constructor 

        public Payment(int paymentId, int leaseId, DateTime paymentDate, double amount)
        {
            PaymentId = paymentId;
            LeaseId = leaseId;
            PaymentDate = paymentDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"PaymentId : {PaymentId}\t  LeaseId : {LeaseId}\t  PaymentDate : {PaymentDate}\t  Amount : {Amount}";
        }
    }
}
