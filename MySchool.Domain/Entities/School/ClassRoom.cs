using MySchool.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.School
{
    public class ClassRoom: Entity 
    {
        public ClassRoom(int id) 
        { 
            Id = id;
        }
        public ClassRoom(string name, ClassTypes types, DateTime startDate, DateTime endDate, int schoolId, Schools school)
        {
            Name = name;
            Types = types;
            StartDate = startDate;
            EndDate = endDate;
            SchoolId = schoolId;
            School = school;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ClassTypes Types { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SchoolId { get; set; }
        public Schools School { get; set; }
    }
}
