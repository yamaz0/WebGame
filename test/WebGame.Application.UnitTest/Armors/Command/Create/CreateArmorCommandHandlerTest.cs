using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Armors.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Armors.Command.Create
{
    public class CreateArmorCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IArmorRepository> _mockArmorRepository;

        public CreateArmorCommandHandlerTest()
        {
            _mockArmorRepository = ArmorRepositoryMocks.GetArmorRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void CreateArmorTest()
        {
            var handler = new CreateArmorCommandHandler(_mockArmorRepository.Object);

            int armorsCountBefore = (await _mockArmorRepository.Object.GetAllAsync()).Count;
            CreateArmorCommand request = new CreateArmorCommand()
            {
                Name = "A",
                Description = "B",
                Defense = 1,
                Value = 1,
                ItemType = 0
            };

            var response = await handler.Handle(request, CancellationToken.None);

            int armorsCountAfter = (await _mockArmorRepository.Object.GetAllAsync()).Count;

            armorsCountAfter.ShouldBe(armorsCountBefore + 1);
            response.ShouldBeOfType(typeof(CreateArmorCommandResponse));
            response.Success.ShouldBe(true);
            response.Errors.Count.ShouldBe(0);
            response.ArmorId.ShouldNotBeNull();
        }
    }
}
