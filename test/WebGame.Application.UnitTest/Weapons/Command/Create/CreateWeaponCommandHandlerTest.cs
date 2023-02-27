using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Weapons.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Weapons.Command.Create
{
    public class CreateWeaponCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWeaponRepository> _mockWeaponRepository;

        public CreateWeaponCommandHandlerTest()
        {
            _mockWeaponRepository = WeaponRepositoryMocks.GetWeaponRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void CreateWeaponTest()
        {
            var handler = new CreateWeaponCommandHandler(_mockWeaponRepository.Object);
            var result = await handler.Handle(new CreateWeaponCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(CreateWeaponCommandResponse));
        }
    }
}
