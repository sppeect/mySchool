using MySchool.Domain.Entities.School;
using MySchool.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.Teacher
{
    public class Teachers
    {
        public Teachers(int id)
        {
            Id = id;
        }

        public Teachers(string firstName, string lastName, string document, string email)
        {
            Name = new Name(firstName, lastName);
            Document = document;
            Email = email;
        }

        public int Id { get; set; }
        public Name Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        

    }
}
