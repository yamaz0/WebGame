using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Jobs.Command.Create
{
    public class CreateJobCommandResponse : BasicResponse
    {
        public int? JobId { get; set; }

        public CreateJobCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreateJobCommandResponse(int? jobId)
        {
            JobId = jobId;
        }
    }
}
