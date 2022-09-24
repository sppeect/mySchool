using Flunt.Validations;
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
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract<Address>()
                .Requires()
                .IsLowerOrEqualsThan(Street, 3, "Address.Street", "A rua deve conter pelo o menos 3 caracteres")
                .IsLowerOrEqualsThan(Number, 1, "Address.Number", "O numero deve conter pelo o menos 1 caracteres")
                .IsLowerOrEqualsThan(Neighborhood, 3, "Address.Neighborhood", "O Bairro deve conter pelo o menos 3 caracteres")
                );
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
