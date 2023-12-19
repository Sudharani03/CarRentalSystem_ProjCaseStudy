using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_CaseStudy_Final.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //default constructor 

        public Customer() { }

        //parameterized constructor 

        public Customer(int customerId, string firstName, string lastName, string email, string phoneNumber)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"ID : {CustomerId}\t Name : {FirstName+" "+LastName}\t MailId : {Email}\t Phone Number : {PhoneNumber}";
        }
    }
}
