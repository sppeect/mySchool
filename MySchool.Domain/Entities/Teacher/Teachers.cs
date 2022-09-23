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

        public Teachers(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
        }

        public int Id { get; set; }
        public Name Name { get; set; }
        public Document Document { get; set; }
        public Email Email { get; set; }
        

    }
}
