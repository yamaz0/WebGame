using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Enemies.Query;
using WebGame.Application.Functions.Enemies.Query.GetEnemy;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Enemys.Query.GetOne
{
    public class GetEnemyQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEnemyRepository> _mockEnemyRepository;

        public GetEnemyQueryHandlerTest()
        {
            _mockEnemyRepository = EnemyRepositoryMocks.GetEnemyRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = new Mapper(cfg);
        }

        [Fact]
        public async void GetEnemyTest()
        {
            var handler = new GetEnemyRequestHandler(_mockEnemyRepository.Object, _mapper);
            var result = await handler.Handle(new GetEnemyRequest() { EnemyId = 1 }, CancellationToken.None);
            result.ShouldBeOfType(typeof(GetEnemyViewModel));
        }
    }
}
