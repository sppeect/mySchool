using MySchool.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.ValueObjects
{
    public class Address : ValueObject 
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public string Country { get; set; }
    }
}
