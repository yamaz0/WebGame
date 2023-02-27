using AutoMapper;
using Moq;
using Shouldly;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Armors.Query.GetAllArmors;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Armors.Query.GetAll
{
    public class GetAllArmorsQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IArmorRepository> _mockArmorRepository;

        public GetAllArmorsQueryHandlerTest()
        {
            _mockArmorRepository = ArmorRepositoryMocks.GetArmorRepository();
            var configureProvider = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async void GetAllArmorsTest()
        {
            var handler = new GetAllArmorsRequestHandler(_mockArmorRepository.Object, _mapper);
            var result = await handler.Handle(new GetAllArmorsRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<GetAllArmorsViewModel>>();
        }
    }
}