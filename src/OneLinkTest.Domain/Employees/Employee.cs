using OneLinkTest.Domain.Areas.Subareas;

namespace OneLinkTest.Domain.Employees
{
    public class Employee
    {
        public long EmployeeId { get; set; }

        public long Document { get; set; }

        public DocumentType DocumentType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SubareaId { get; set; }

        public Subarea Subarea { get; set; }
    }
}
