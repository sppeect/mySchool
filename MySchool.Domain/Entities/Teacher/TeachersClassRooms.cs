using MySchool.Domain.Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.Teacher
{
    public class TeachersClassRooms
    {
        public TeachersClassRooms(int teacherId, int classRoomId)
        {
            Teachers = new Teachers(teacherId);
            ClassRoom = new ClassRoom(classRoomId);
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teachers Teachers { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
