using MySchool.Common.Entities;
using MySchool.Domain.Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.Entities.Student
{
    public class StudentsNotes : Entity
    {
        public StudentsNotes(decimal note, string season, int StudentsClassRoomId)
        {
            Note = note;
            Season = season;
            StudentsClassRoom = new StudentsClassRoom(StudentsClassRoomId);

            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public decimal Note { get; set; }
        public string Season { get; set; }
        public int StudentsClassRoomId { get; set; }
        public StudentsClassRoom StudentsClassRoom { get; set; }

    }
}
