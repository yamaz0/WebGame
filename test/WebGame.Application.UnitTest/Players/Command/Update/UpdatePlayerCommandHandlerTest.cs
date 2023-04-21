using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Players.Command.Update;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Players.Command.Update
{
    public class UpdatePlayerCommandHandlerTest
    {
        private const int ID = 1;
        private readonly IMapper _mapper;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;

        public UpdatePlayerCommandHandlerTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void UpdatePlayerTest()
        {
            var handler = new UpdatePlayerCommandHandler(_mockPlayerRepository.Object, _mapper);
            var player = await _mockPlayerRepository.Object.GetByIdAsync(ID);
            player.Name = "before";
            var response = await handler.Handle(new UpdatePlayerCommand()
            {
                Id = ID,
                Name = "after",
                Cash = player.Cash,
                Dexterity = player.Dexterity,
                Endurance = player.Endurance,
                Exp = player.Exp,
                Level = player.Level,
                ActionId = player.ActionId,
                ActionState = player.ActionState,
                ActionType = player.ActionType,
                SkillPoints = player.SkillPoints,
                Stamina = player.Stamina,
                Strenght = player.Strenght
            }, CancellationToken.None);

            var updatedPlayer = await _mockPlayerRepository.Object.GetByIdAsync(ID);
            updatedPlayer.Name.ShouldBe("after");
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
