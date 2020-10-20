using OneLinkTest.Domain.Areas.Subareas;

namespace OneLinkTest.Domain.Employees
{
    public class Employee
    {
        public Employee(EmployeeId employeeId, int document, DocumentType documentType, string firstName, string lastName, Subarea subarea)
        {
            EmployeeId = employeeId;
            Document = document;
            DocumentType = documentType;
            FirstName = firstName;
            LastName = lastName;
            Subarea = subarea;
        }

        public EmployeeId EmployeeId { get; }

        public int Document { get; }

        public DocumentType DocumentType { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public Subarea Subarea { get; }
    }
}
