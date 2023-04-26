using Microsoft.AspNetCore.Components;
using System.Timers;
using WebGame.UI.Blazor.Interfaces.Jobs;
using WebGame.UI.Blazor.Services;

namespace WebGame.UI.Blazor.Pages.JobPages
{
    public partial class Job
    {
        private System.Timers.Timer _timer = null!;
        private int _secondsToRun = 0;
        private int sliderValue = 0;

        protected string Time { get; set; } = "00:00";
        protected string CalcTime { get; set; } = "00:10";
        protected TimeActionStateResponse State { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJobServices _jobServices { get; set; }

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
            await _jobServices.RewardJob();
            await Refresh();
        }

        private void CalcTimeHandler()
        {
            CalcTime = TimeSpan.FromMinutes(sliderValue).ToString(@"hh\:mm");
        }

        private async Task Refresh()
        {
            TimeActionResponse response = await _jobServices.CheckJob();
            State = response.TimeActionStateResponse;

            switch (State)
            {
                case TimeActionStateResponse.NoAction:
                    SliderInit();
                    break;
                case TimeActionStateResponse.OtherAction:
                    Time = "Player does other action.";
                    break;
                case TimeActionStateResponse.InProgress:
                    Start((int)(response.EndTime - DateTime.UtcNow).TotalSeconds);
                    break;
                case TimeActionStateResponse.Finished:
                    Time = "Job end.";
                    break;
                default:
                    //error bad enum
                    break;
            }

            StateHasChanged();
        }

        private void SliderInit()
        {
            sliderValue = 10;
        }

        public async void StartJob()
        {
            var response = await _jobServices.SetJobToPlayer(sliderValue);

            if (response.Success)
            {
                await Refresh();
            }
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