using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulCustomerService.Model
{
    public class Customer
    {

        //ID, unique identifier
        //FirstName, 
        //LastName, 
        //Year, year of registration


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string firstName, string lastName, int year)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
        }

    }
}