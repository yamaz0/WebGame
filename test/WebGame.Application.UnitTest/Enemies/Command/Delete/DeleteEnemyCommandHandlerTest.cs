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

namespace WebGame.Application.UnitTest.Enemys.Command.Delete
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
            var result = await handler.Handle(new DeleteEnemyCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
