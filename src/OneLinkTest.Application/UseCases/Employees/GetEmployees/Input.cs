namespace OneLinkTest.Application.UseCases.Employees.GetEmployees
{
    public class Input
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchTerms { get; set; } = string.Empty;
    }
}
