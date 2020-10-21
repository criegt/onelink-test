using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.UpdateEmployee
{
    public class Input
    {
        public Input(long document, DocumentType documentType, string firstName, string lastName, int subareaId)
        {
            Document = document;
            DocumentType = documentType;
            FirstName = firstName;
            LastName = lastName;
            SubareaId = subareaId;
        }

        public long Document { get; set; }

        public DocumentType DocumentType { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public int SubareaId { get; }
    }
}
