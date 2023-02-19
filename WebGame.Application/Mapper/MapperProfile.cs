using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Enemies.Query.GetAllEnemies;
using WebGame.Application.Functions.Jobs.Query.GetAll;
using WebGame.Application.Functions.Missions.Query.GetAll;
using WebGame.Application.Functions.Players.Query.GetAllPlayers;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;
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
            CreateMap<Weapon, GetAllWeaponsViewModel>();
            CreateMap<Job, GetAllJobsViewModel>();
            CreateMap<Mission, GetAllMissionsViewModel>();
            CreateMap<Enemy, GetAllEnemiesViewModel>();
            CreateMap<Player, GetAllPlayersViewModel>();

        }

    }
}