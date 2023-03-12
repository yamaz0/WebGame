using AutoMapper;
using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Armors;
using WebGame.UI.Blazor.ViewModels.Players;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<GetAllArmorsViewModel, ArmorsListBlazorVM>().ReverseMap();
            CreateMap<GetAllWeaponsViewModel, WeaponsListBlazorVM>().ReverseMap();

            CreateMap<GetPlayerViewModel, PlayerBlazorVM>().ReverseMap();
        }
    }
}
