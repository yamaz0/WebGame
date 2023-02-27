using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Enemies.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Enemys.Command.Create
{
    public class CreateEnemyCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEnemyRepository> _mockEnemyRepository;

        public CreateEnemyCommandHandlerTest()
        {
            _mockEnemyRepository = EnemyRepositoryMocks.GetEnemyRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void CreateEnemyTest()
        {
            var handler = new CreateEnemyCommandHandler(_mockEnemyRepository.Object);
            var result = await handler.Handle(new CreateEnemyCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(CreateEnemyCommandResponse));
        }
    }
}
