using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.School
{
    public class ClassTypes
    {
        public ClassTypes() { }
        public ClassTypes(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
