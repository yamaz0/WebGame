using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Armors.Command.Update;
using WebGame.Application.Functions.Armors.Command.Update;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Armors.Command.Update
{
    public class UpdateArmorCommandHandlerTest
    {
        private const int ID = 1;
        private readonly IMapper _mapper;
        private readonly Mock<IArmorRepository> _mockArmorRepository;

        public UpdateArmorCommandHandlerTest()
        {
            _mockArmorRepository = ArmorRepositoryMocks.GetArmorRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void UpdateArmorTest()
        {
            var handler = new UpdateArmorCommandHandler(_mockArmorRepository.Object, _mapper);
            var armor = await _mockArmorRepository.Object.GetByIdAsync(ID);
            armor.Name = "before";
            var response = await handler.Handle(new UpdateArmorCommand()
            {
                Id = ID,
                Name = "after",
                Description = armor.Description,
                Defense = armor.Defense,
                ItemType = armor.ItemType,
                Value = armor.Value
            }, CancellationToken.None);

            var updatedArmor = await _mockArmorRepository.Object.GetByIdAsync(ID);
            updatedArmor.Name.ShouldBe("after");
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
