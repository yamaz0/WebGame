using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Weapons.Query;
using WebGame.Application.Functions.Weapons.Query.GetWeapon;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Weapons.Query.GetOne
{
    public class GetWeaponQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWeaponRepository> _mockWeaponRepository;

        public GetWeaponQueryHandlerTest()
        {
            _mockWeaponRepository = WeaponRepositoryMocks.GetWeaponRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = new Mapper(cfg);
        }

        [Fact]
        public async void GetWeaponTest()
        {
            var handler = new GetWeaponRequestHandler(_mockWeaponRepository.Object, _mapper);
            var result = await handler.Handle(new GetWeaponRequest() { Id = 1 }, CancellationToken.None);
            result.ShouldBeOfType(typeof(GetWeaponViewModel));
        }
    }
}
