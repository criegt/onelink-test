using System.Threading.Tasks;
using NUnit.Framework;
using OneLinkTest.Application.UseCases.Employees.UpdateEmployee;
using OneLinkTest.Domain.Employees;
using OneLinkTest.Infrastructure.DataAccess;
using OneLinkTest.Infrastructure.DataAccess.Repositories;

namespace UnitTests.Employees.UpdateEmployee
{
    public class UpdateEmployeeTests
    {
        private IEmployeeRepository _repository;
        private IUpdateEmployeeUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repository = new EmployeeRepositoryFake(new OneLinkTestContextFake());
            _useCase = new UpdateEmployeeUseCase(_repository);
        }

        [Test]
        public async Task Should_ReturnNotNull()
        {
            var presenter = new UpdateEmployeePresenter();
            var input = new Input
            {
                EmployeeId = 1,
                Document = 1040049214,
                DocumentType = DocumentType.CitizenshipCard,
                FirstName = "Cristian",
                LastName = "García Ocampo",
                SubareaId = 2
            };

            _useCase.SetOutputPort(presenter);

            await _useCase.Execute(input);

            Assert.IsNotNull(presenter.Employee);
        }
    }
}
