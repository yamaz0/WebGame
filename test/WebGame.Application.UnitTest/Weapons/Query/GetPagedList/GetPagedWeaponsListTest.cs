using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Weapons.Query.GetListWeapons;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Weapons.Query.GetPagedList
{
    public class GetPagedWeaponsListTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWeaponRepository> _mockWeaponRepository;

        public GetPagedWeaponsListTest()
        {
            _mockWeaponRepository = WeaponRepositoryMocks.GetWeaponRepository();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = new Mapper(config);
        }

        [Fact]
        public async void GetPagedWeaponsList()
        {
            var handler = new GetListWeaponsRequestHandler(_mockWeaponRepository.Object, _mapper);
            var result = await handler.Handle(new GetListWeaponsRequest(), CancellationToken.None);
            result.ShouldBeOfType(typeof(List<GetListWeaponsViewModel>));
        }
    }
}
