using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.BodyArmors.Query.GetAllBodyArmors;
using WebGame.Application.Functions.Enemies.Query.GetAllEnemies;
using WebGame.Application.Functions.Enemies.Query.GetBodyArmor;
using WebGame.Application.Functions.Enemies.Query.GetEnemy;
using WebGame.Application.Functions.Jobs.Query.GetAll;
using WebGame.Application.Functions.Jobs.Query.GetOne;
using WebGame.Application.Functions.Missions.Query.GetAll;
using WebGame.Application.Functions.Missions.Query.GetOne;
using WebGame.Application.Functions.Players.Query.GetAllPlayers;
using WebGame.Application.Functions.Players.Query.GetPlayer;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;
using WebGame.Application.Functions.Weapons.Query.GetListWeapons;
using WebGame.Application.Functions.Weapons.Query.GetWeapon;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Enemies;
using WebGame.Entities.Items;
using WebGame.Entities.Jobs;
using WebGame.Entities.Missions;

namespace WebGame.Application.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Player, GetAllPlayersViewModel>();
            CreateMap<Player, GetPlayerViewModel>();

            CreateMap<Enemy, GetAllEnemiesViewModel>();
            CreateMap<Enemy, GetEnemyViewModel>();

            CreateMap<Job, GetAllJobsViewModel>();
            CreateMap<Job, GetJobViewModel>();

            CreateMap<Mission, GetAllMissionsViewModel>();
            CreateMap<Mission, GetMissionViewModel>();

            CreateMap<Armor, GetAllArmorsViewModel>();
            CreateMap<Armor, GetArmorViewModel>();

            CreateMap<Weapon, GetAllWeaponsViewModel>();
            CreateMap<Weapon, GetWeaponViewModel>();
            CreateMap<Weapon, GetListWeaponsViewModel>();

        }

    }
}