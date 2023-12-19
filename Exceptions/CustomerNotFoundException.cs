﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_CaseStudy_Final.Exceptions
{
    public class CustomerNotFoundException:ApplicationException
    {
        public CustomerNotFoundException() { }
        public CustomerNotFoundException(string message) :base (message) { }
    }
}
