using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Interfaces.Weapons;
using WebGame.UI.Blazor.Services.Authentication;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Services.Weapons
{
    public class WeaponServices : IWeaponServices
    {
        private readonly IMapper _mapper;
        private IClient _client;
        private IAddBearerTokenService _addBearerTokenService;

        public WeaponServices(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _mapper = mapper;
            _client = client;
            this._addBearerTokenService = addBearerTokenService;
        }

        public async Task<List<WeaponsListBlazorVM>> GetAllWeapons()
        {
            await _addBearerTokenService.AddBearerToken(_client);

            var allWeapons = await _client.WeaponsAsync();
            var mappedWeapons = _mapper.Map<ICollection<WeaponsListBlazorVM>>(allWeapons);
            return mappedWeapons.ToList();
        }
    }
}
