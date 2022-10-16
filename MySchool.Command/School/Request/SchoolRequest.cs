using MySchool.Common.Enums;

namespace MySchool.Command.School.Request
{
    public class SchoolRequest
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
        public EDocumentType DocumentType { get; set; }
    }
}
