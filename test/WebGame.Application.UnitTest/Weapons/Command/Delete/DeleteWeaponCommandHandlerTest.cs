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
using WebGame.Application.Functions.Weapons.Command.Delete;
using WebGame.Application.Functions.Weapons.Command.Delete;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Weapons.Command.Delete
{
    public class DeleteWeaponCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWeaponRepository> _mockWeaponRepository;

        public DeleteWeaponCommandHandlerTest()
        {
            _mockWeaponRepository = WeaponRepositoryMocks.GetWeaponRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void DeleteWeaponTest()
        {
            var handler = new DeleteWeaponCommandHandler(_mockWeaponRepository.Object);
            int weaponsCountBefore = (await _mockWeaponRepository.Object.GetAllAsync()).Count;
            var request = new DeleteWeaponCommand()
            {
                WeaponId = 1
            };

            var response = await handler.Handle(request, CancellationToken.None);

            int weaponsCountAfter = (await _mockWeaponRepository.Object.GetAllAsync()).Count;

            weaponsCountAfter.ShouldBe(weaponsCountBefore - 1);
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
