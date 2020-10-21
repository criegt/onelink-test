using OneLinkTest.Domain.Areas.Subareas;

namespace OneLinkTest.Domain.Employees
{
    public class Employee
    {
        public Employee(EmployeeId employeeId, long document, DocumentType documentType, string firstName, string lastName, int subareaId)
        {
            EmployeeId = employeeId;
            Document = document;
            DocumentType = documentType;
            FirstName = firstName;
            LastName = lastName;
            SubareaId = subareaId;
        }

        public EmployeeId EmployeeId { get; }

        public long Document { get; }

        public DocumentType DocumentType { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public int SubareaId { get; }

        public Subarea? Subarea { get; set; }
    }
}
