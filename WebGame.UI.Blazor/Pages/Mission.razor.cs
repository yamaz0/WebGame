using Microsoft.AspNetCore.Components;
using System.Timers;
using WebGame.UI.Blazor.Interfaces.Missions;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Missions;

namespace WebGame.UI.Blazor.Pages
{
    public partial class Mission
    {
        private System.Timers.Timer _timer = null!;
        private int _secondsToRun = 0;
        private GetPlayerAllInfoViewModel player;

        protected string Time { get; set; } = "00:00";
        protected bool ShowAll { get; set; }
        public ICollection<MissionBlazorVM> Missions { get; set; }
        public bool IsMissionFinished { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IPlayerServices _playerServices { get; set; }
        [Inject]
        public IMissionServices _missionServices { get; set; }

        public void Start(int secondsToRun)
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;

            _secondsToRun = secondsToRun;

            if (_secondsToRun > 0)
            {
                Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
                StateHasChanged();
                _timer.Start();
            }
        }

        public void Stop()
        {
            _timer.Stop();
        }

        protected async override Task OnInitializedAsync()
        {
            player = await _playerServices.GetPlayer();
            if (player.MissionId != 0)
            {
                var missionFinishDate = player.EndMissionTime;
                IsMissionFinished = missionFinishDate < DateTime.UtcNow;

                if (!IsMissionFinished)
                {
                    Start((int)(missionFinishDate - DateTime.UtcNow).TotalSeconds);
                }
            }
            else
            {
                await FetchMissions();
            }
        }

        public async void StartMission(int id, int duration)
        {
            DateTime endTime = DateTime.UtcNow.AddMinutes(duration);
            player = await _missionServices.SetMissionToPlayer(id, endTime);
            ShowAll = false;
            IsMissionFinished = false;
            Start(duration * 60);
            StateHasChanged();
        }

        protected async Task FetchMissions()
        {
            Missions = await _missionServices.GetMissions();
            ShowAll = true;
            StateHasChanged();
        }

        private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            _secondsToRun--;

            await InvokeAsync(() =>
            {
                Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
                StateHasChanged();
            });

            if (_secondsToRun <= 0)
            {
                IsMissionFinished = true;
                StateHasChanged();
                _timer.Stop();
            }
        }

        private async Task Reward()
        {
            await _missionServices.RewardPlayer(player);
            await FetchMissions();
            StateHasChanged();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
