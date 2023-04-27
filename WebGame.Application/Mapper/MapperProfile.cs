using AutoMapper;
using WebGame.Application.Functions.Armors.Command.Update;
using WebGame.Application.Functions.Armors.Query.GetAllArmors;
using WebGame.Application.Functions.Enemies.Command.Update;
using WebGame.Application.Functions.Enemies.Query.GetAllEnemies;
using WebGame.Application.Functions.Enemies.Query.GetArmor;
using WebGame.Application.Functions.Enemies.Query.GetEnemy;
using WebGame.Application.Functions.Missions.Command.Update;
using WebGame.Application.Functions.Missions.Query.GetAllMissions;
using WebGame.Application.Functions.Missions.Query.GetMission;
using WebGame.Application.Functions.Players.Command.Update;
using WebGame.Application.Functions.Players.Query.GetAllPlayers;
using WebGame.Application.Functions.Players.Query.GetPlayer;
using WebGame.Application.Functions.Weapons.Command.Update;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;
using WebGame.Application.Functions.Weapons.Query.GetListWeapons;
using WebGame.Application.Functions.Weapons.Query.GetWeapon;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Enemies;
using WebGame.Entities.Items;
using WebGame.Entities.Missions;

namespace WebGame.Application.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Player, GetAllPlayersViewModel>();
            CreateMap<Player, GetPlayerViewModel>();
            CreateMap<Player, GetPlayerAllInfoViewModel>();
            CreateMap<Player, UpdatePlayerCommand>().ReverseMap();

            CreateMap<Enemy, GetAllEnemiesViewModel>();
            CreateMap<Enemy, GetEnemyViewModel>();
            CreateMap<Enemy, UpdateEnemyCommand>().ReverseMap();

            CreateMap<Mission, GetAllMissionsViewModel>();
            CreateMap<Mission, GetMissionViewModel>();
            CreateMap<Mission, UpdateMissionCommand>().ReverseMap();

            CreateMap<Armor, GetAllArmorsViewModel>();
            CreateMap<Armor, GetArmorViewModel>();
            CreateMap<Armor, UpdateArmorCommand>().ReverseMap();

            CreateMap<Weapon, GetAllWeaponsViewModel>();
            CreateMap<Weapon, GetWeaponViewModel>();
            CreateMap<Weapon, GetListWeaponsViewModel>();
            CreateMap<Weapon, UpdateWeaponCommand>().ReverseMap();
        }
    }
}