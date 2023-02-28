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

namespace WebGame.Application.UnitTest.Enemies.Command.Update
{
    public class UpdateEnemyCommandHandlerTest
    {
        private const int ID = 1;
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
            var enemy = await _mockEnemyRepository.Object.GetByIdAsync(ID);
            enemy.Name = "before";
            var response = await handler.Handle(new UpdateEnemyCommand()
            {
                Id = ID,
                Name = "after",
                Attack = enemy.Attack,
                CashReward = enemy.CashReward,
                ExpReward = enemy.ExpReward,
                HealthPoint = enemy.HealthPoint
            }, CancellationToken.None);

            var updatedEnemy = await _mockEnemyRepository.Object.GetByIdAsync(ID);
            updatedEnemy.Name.ShouldBe("after");
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
