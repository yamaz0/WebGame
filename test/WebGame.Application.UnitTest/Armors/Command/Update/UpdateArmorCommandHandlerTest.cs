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
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Armors.Command.Update
{
    public class UpdateArmorCommandHandlerTest
    {
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
            var result = await handler.Handle(new UpdateArmorCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
