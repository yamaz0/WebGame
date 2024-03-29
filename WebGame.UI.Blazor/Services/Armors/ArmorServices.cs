﻿using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.ViewModels.Armors;
namespace WebGame.UI.Blazor.Services.Armors
{
    public class ArmorServices : IArmorServices
    {
        private readonly IMapper _mapper;
        private IClient _client;
        private IAddBearerTokenService _addBearerTokenService;

        public ArmorServices(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _mapper = mapper;
            _client = client;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task BuyArmor(int id)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            var response = await _client.ArmorsPOSTAsync(id);


        }

        public async Task<List<ArmorsListBlazorVM>> GetAllArmors()
        {
            var allArmors = await _client.ArmorsAllAsync();
            var mappedArmors = _mapper.Map<ICollection<ArmorsListBlazorVM>>(allArmors);
            return mappedArmors.ToList();
        }
    }
}
