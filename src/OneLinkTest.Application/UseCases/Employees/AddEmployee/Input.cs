using System;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.AddEmployee
{
    public class Input
    {
        public long Document { get; set; }

        public DocumentType DocumentType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SubareaId { get; set; }
    }
}
