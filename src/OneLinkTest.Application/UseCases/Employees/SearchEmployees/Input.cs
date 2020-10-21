namespace OneLinkTest.Application.UseCases.Employees.SearchEmployees
{
    public class Input
    {
        public Input(string searchTerms)
        {
            SearchTerms = searchTerms;
        }

        public string SearchTerms { get; }
    }
}
