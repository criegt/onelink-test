using System.Threading.Tasks;
using NUnit.Framework;
using OneLinkTest.Application.UseCases.Employees.AddEmployee;
using OneLinkTest.Domain.Employees;
using OneLinkTest.Infrastructure.DataAccess;
using OneLinkTest.Infrastructure.DataAccess.Repositories;

namespace UnitTests.Employees.AddEmployee
{
    public class AddEmployeeTests
    {
        private IEmployeeRepository _repository;
        private IAddEmployeeUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repository = new EmployeeRepositoryFake(new OneLinkTestContextFake());
            _useCase = new AddEmployeeUseCase(_repository);
        }

        [Test]
        public async Task Should_ReturnNotNull()
        {
            var presenter = new AddEmployeePresenter();
            var input = new Input
            {
                Document = 1040049215,
                DocumentType = DocumentType.CitizenshipCard,
                FirstName = "Johny",
                LastName = "Soto",
                SubareaId = 1
            };

            _useCase.SetOutputPort(presenter);

            await _useCase.Execute(input);

            Assert.IsNotNull(presenter.Employee);
        }
    }
}
