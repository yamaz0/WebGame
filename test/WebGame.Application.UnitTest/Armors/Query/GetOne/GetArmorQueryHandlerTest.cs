using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Enemies.Query.GetArmor;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Armors.Query.GetOne
{
    public class GetArmorQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IArmorRepository> _mockArmorRepository;

        public GetArmorQueryHandlerTest()
        {
            _mockArmorRepository = ArmorRepositoryMocks.GetArmorRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = new Mapper(cfg);
        }

        [Fact]
        public async void GetArmorTest()
        {
            var handler = new GetArmorRequestHandler(_mockArmorRepository.Object, _mapper);
            var result = handler.Handle(new GetArmorRequest(), CancellationToken.None);
            result.ShouldBeOfType(typeof(GetArmorViewModel));
        }
    }
}
