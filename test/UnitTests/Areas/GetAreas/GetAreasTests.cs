using System.Threading.Tasks;
using NUnit.Framework;
using OneLinkTest.Application.UseCases.Areas.GetAreas;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Infrastructure.DataAccess;
using OneLinkTest.Infrastructure.DataAccess.Repositories;

namespace UnitTests.Areas.GetAreas
{
    public class GetAreasTests
    {
        private IAreaRepository _repository;
        private IGetAreasUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repository = new AreaRepositoryFake(new OneLinkTestContextFake());
            _useCase = new GetAreasUseCase(_repository);
        }

        [Test]
        public async Task Should_ReturnNotNull()
        {
            var presenter = new GetAreasPresenter();

            _useCase.SetOutputPort(presenter);

            await _useCase.Execute();

            Assert.IsNotNull(presenter.Areas);
        }
    }
}
