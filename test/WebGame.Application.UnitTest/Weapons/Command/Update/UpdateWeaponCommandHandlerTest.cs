using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Weapons.Command.Update;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Weapons.Command.Update
{
    public class UpdateWeaponCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWeaponRepository> _mockWeaponRepository;

        public UpdateWeaponCommandHandlerTest()
        {
            _mockWeaponRepository = WeaponRepositoryMocks.GetWeaponRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void UpdateWeaponTest()
        {
            var handler = new UpdateWeaponCommandHandler(_mockWeaponRepository.Object, _mapper);
            var result = await handler.Handle(new UpdateWeaponCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
