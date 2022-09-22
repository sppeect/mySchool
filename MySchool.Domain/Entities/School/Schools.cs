using MySchool.Common.Entities;
using MySchool.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.School
{
    public class Schools : Entity
    {
        public Schools(int id)
        {
            Id = id;
        }

        public Schools(string name, Address address, string email, string phone, string document)
        {
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            Document = document;

            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
    }
}
