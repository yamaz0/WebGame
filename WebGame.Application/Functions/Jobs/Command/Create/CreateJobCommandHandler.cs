using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Jobs;

namespace WebGame.Application.Functions.Jobs.Command.Create
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, CreateJobCommandResponse>
    {
        private readonly IJobRepository _jobRepository;

        public CreateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<CreateJobCommandResponse> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateJobCommandValidate();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid)
            {
                return new CreateJobCommandResponse(validatorResult);
            }

            Job job = new Job()
            {
                Name = request.Name,
                Description = request.Description,
                Duration = request.Duration,
                Reward = request.Reward
            };

            job = await _jobRepository.AddAsync(job);
            return new CreateJobCommandResponse(job.Id);
        }
    }
}
