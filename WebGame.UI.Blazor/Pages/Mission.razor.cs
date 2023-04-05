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

        protected string Time { get; set; } = "00:00";
        protected TimeActionStateResponse State { get; set; }
        public ICollection<MissionBlazorVM> Missions { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
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
            await Refresh();
        }

        private async Task Reward()
        {
            await _missionServices.RewardMission();
            await Refresh();
        }

        private async Task Refresh()
        {
            TimeActionResponse response = await _missionServices.CheckMission();
            State = response.TimeActionStateResponse;

            switch (State)
            {
                case TimeActionStateResponse.NoAction:
                    await FetchMissions();
                    break;
                case TimeActionStateResponse.OtherAction:
                    Time = "Player does other action.";
                    break;
                case TimeActionStateResponse.InProgress:
                    Start((int)(response.EndTime - DateTime.UtcNow).TotalSeconds);
                    break;
                case TimeActionStateResponse.Finished:
                    Time = "Mission end.";
                    break;
                default:
                    //error bad enum
                    break;
            }

            StateHasChanged();
        }

        public async void StartMission(int id)
        {
            var response = await _missionServices.SetMissionToPlayer(id);

            if (response.Success)
            {
                await Refresh();
            }
        }

        protected async Task FetchMissions()
        {
            if (Missions == null)
                Missions = await _missionServices.GetMissions();
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
                await Refresh();
                _timer.Stop();
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
