using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Services.Mission.Interface;

namespace WebGame.Controllers
{
    [Authorize]
    public class MissionController : Controller
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }
        public IActionResult Index()
        {
            var missions = _missionService.GetAllMissions();
            return View(missions);
        }
    }
}
