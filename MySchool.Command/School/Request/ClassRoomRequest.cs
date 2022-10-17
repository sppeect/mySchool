using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Command.School.Request
{
    public class ClassRoomRequest
    {
        public string Name { get; set; }
        public int TypesId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SchoolId { get; set; }
    }
}
