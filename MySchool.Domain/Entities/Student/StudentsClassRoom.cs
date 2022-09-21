using MySchool.Common.Entities;
using MySchool.Domain.Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.Student
{
    public class StudentsClassRoom : Entity
    {
        public StudentsClassRoom(int studentId, int classRoomId)
        {
            Students = new Students(studentId);
            ClassRoom = new ClassRoom(classRoomId);

            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public Students Students { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
       
    }
}
