using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Armors.Command.Delete;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Armors.Command.Delete
{
    public class DeleteArmorCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IArmorRepository> _mockArmorRepository;

        public DeleteArmorCommandHandlerTest()
        {
            _mockArmorRepository = ArmorRepositoryMocks.GetArmorRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void DeleteArmorTest()
        {            
            var handler = new DeleteArmorCommandHandler(_mockArmorRepository.Object);
            var result = await handler.Handle(new DeleteArmorCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
