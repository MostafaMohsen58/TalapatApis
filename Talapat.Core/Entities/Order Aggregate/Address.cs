﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapat.Core.Entities.Order_Aggregate
{
    public class Address
    {
        public Address()
        {
                
        }
        public Address(string firstName, string lastName, string city, string country, string street)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
            Street = street;
        }

        // will not be represented in database
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }


    }
}