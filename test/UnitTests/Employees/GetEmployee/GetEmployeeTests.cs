using System.Threading.Tasks;
using NUnit.Framework;
using OneLinkTest.Application.UseCases.Employees.GetEmployee;
using OneLinkTest.Domain.Employees;
using OneLinkTest.Infrastructure.DataAccess;
using OneLinkTest.Infrastructure.DataAccess.Repositories;

namespace UnitTests.Employees.GetEmployee
{
    public class GetEmployeeTests
    {
        private IEmployeeRepository _repository;
        private IGetEmployeeUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repository = new EmployeeRepositoryFake(new OneLinkTestContextFake());
            _useCase = new GetEmployeeUseCase(_repository);
        }

        [Test]
        public async Task Should_ReturnNotNull()
        {
            var presenter = new GetEmployeePresenter();
            var employeeId = 1;

            _useCase.SetOutputPort(presenter);

            await _useCase.Execute(employeeId);

            Assert.IsNotNull(presenter.Employee);
        }
    }
}
