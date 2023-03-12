using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.ViewModels.Armors;
namespace WebGame.UI.Blazor.Services.Armors
{
    public class ArmorServices : IArmorServices
    {
        private readonly IMapper _mapper;
        private IClient _client;

        public ArmorServices(IMapper mapper, IClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<List<ArmorsListBlazorVM>> GetAllArmors()
        {
            var allArmors = await _client.ArmorsAsync();
            var mappedArmors = _mapper.Map<ICollection<ArmorsListBlazorVM>>(allArmors);
            return mappedArmors.ToList();
        }
    }
}
