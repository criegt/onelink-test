﻿using System.Threading.Tasks;
using NUnit.Framework;
using OneLinkTest.Application.UseCases.Employees.GetEmployees;
using OneLinkTest.Domain.Employees;
using OneLinkTest.Infrastructure.DataAccess;
using OneLinkTest.Infrastructure.DataAccess.Repositories;

namespace UnitTests.Employees.GetEmployees
{
    public class GetEmployeesTests
    {
        private IEmployeeRepository _repository;
        private IGetEmployeesUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repository = new EmployeeRepositoryFake(new OneLinkTestContextFake());
            _useCase = new GetEmployeesUseCase(_repository);
        }

        [Test]
        public async Task Should_ReturnNotNull()
        {
            var presenter = new GetEmployeesPresenter();
            var input = new Input
            {
                PageIndex = 0,
                PageSize = 10,
                SearchTerms = string.Empty
            };

            _useCase.SetOutputPort(presenter);

            await _useCase.Execute(input);

            Assert.IsNotNull(presenter.Employees);
        }
    }
}
