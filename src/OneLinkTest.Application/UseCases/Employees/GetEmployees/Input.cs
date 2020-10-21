namespace OneLinkTest.Application.UseCases.Employees.GetEmployees
{
    public class Input
    {
        public Input(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; }
        public int PageSize { get; }
    }
}
