using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Enemies.Command.Delete;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Enemies.Command.Delete
{
    public class DeleteEnemyCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEnemyRepository> _mockEnemyRepository;

        public DeleteEnemyCommandHandlerTest()
        {
            _mockEnemyRepository = EnemyRepositoryMocks.GetEnemyRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void DeleteEnemyTest()
        {
            var handler = new DeleteEnemyCommandHandler(_mockEnemyRepository.Object);
            int enemiesCountBefore = (await _mockEnemyRepository.Object.GetAllAsync()).Count;
            var request = new DeleteEnemyCommand()
            {
                EnemyId = 1
            };

            var response = await handler.Handle(request, CancellationToken.None);

            int enemiesCountAfter = (await _mockEnemyRepository.Object.GetAllAsync()).Count;

            enemiesCountAfter.ShouldBe(enemiesCountBefore - 1);
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
