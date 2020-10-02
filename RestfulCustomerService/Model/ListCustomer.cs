using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulCustomerService.Model
{
    public class ListCustomer
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(1, "Johnny", "Rotten", 1988),
            new Customer(2, "Crosby", "Paul", 1995),
            new Customer(3, "Sanders", "Colonel", 1953)
        };
    }
}