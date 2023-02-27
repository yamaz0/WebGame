using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Enemies.Command.Update;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Enemys.Command.Update
{
    public class UpdateEnemyCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEnemyRepository> _mockEnemyRepository;

        public UpdateEnemyCommandHandlerTest()
        {
            _mockEnemyRepository = EnemyRepositoryMocks.GetEnemyRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void UpdateEnemyTest()
        {
            var handler = new UpdateEnemyCommandHandler(_mockEnemyRepository.Object, _mapper);
            var result = await handler.Handle(new UpdateEnemyCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
