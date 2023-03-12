using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Weapons;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Services.Weapons
{
    public class WeaponServices : IWeaponServices
    {
        private readonly IMapper _mapper;
        private IClient _client;

        public WeaponServices(IMapper mapper, IClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<List<WeaponsListBlazorVM>> GetAllWeapons()
        {
            var allWeapons = await _client.WeaponsAsync();
            var mappedWeapons = _mapper.Map<ICollection<WeaponsListBlazorVM>>(allWeapons);
            return mappedWeapons.ToList();
        }
    }
}
