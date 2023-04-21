namespace WebGame.Application.Response
{
    public enum TimeActionStateResponse { NoAction, OtherAction, InProgress, Finished };

    public class TimeActionResponse : BasicResponse
    {
        public TimeActionStateResponse TimeActionStateResponse { get; set; }
        public DateTime EndTime { get; set; }

        public TimeActionResponse(TimeActionStateResponse timeActionStateResponse, DateTime endTime) : base(true)
        {
            TimeActionStateResponse = timeActionStateResponse;
            EndTime = endTime;
        }
    }
}
