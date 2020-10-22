using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.UpdateEmployee
{
    public class Input
    {
        public long EmployeeId { get; set; }

        public long Document { get; set; }

        public DocumentType DocumentType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SubareaId { get; set; }
    }
}
