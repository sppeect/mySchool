using Flunt.Validations;
using MySchool.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.School
{
    public class ClassRoom : Entity
    {
        public ClassRoom(int id)
        {
            Id = id;
        }

        public ClassRoom(string name, ClassTypes types, DateTime starDate, DateTime endDate, Schools schools)
        {
            Name = name;
            Types = types;
            StarDate = starDate;
            EndDate = endDate;
            Schools = schools;

            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TypesId { get; set; }
        public ClassTypes Types { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SchoolId { get; set; }
        public Schools Schools { get; set; }


        public void Update(string name, ClassTypes types, DateTime? starDate, DateTime? endDate)
        {
            Name = name;
            Types = types;
            StarDate = starDate.Value;
            EndDate = endDate.Value;

            UpdatedOn = DateTime.Now;
        }
    }
}
