using AutoMapper;
using Moq;
using Shouldly;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Weapons.Query;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Weapons.Query.GetAll
{
    public class GetAllWeaponsQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWeaponRepository> _mockWeaponRepository;

        public GetAllWeaponsQueryHandlerTest()
        {
            _mockWeaponRepository = WeaponRepositoryMocks.GetWeaponRepository();
            var configureProvider = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async void GetAllWeaponsTest()
        {
            var handler = new GetAllWeaponsRequestHandler(_mockWeaponRepository.Object, _mapper);
            var result = await handler.Handle(new GetAllWeaponsRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<GetAllWeaponsViewModel>>();
        }
    }
}