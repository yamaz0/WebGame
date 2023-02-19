using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Jobs.Command.Delete
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand>
    {
        private readonly IJobRepository _jobRepository;

        public DeleteJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var jobToDelete = await _jobRepository.GetByIdAsync(request.JobId);
            await _jobRepository.RemoveAsync(jobToDelete);
            return Unit.Value;
        }
    }
}
