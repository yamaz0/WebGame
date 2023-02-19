using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Jobs;

namespace WebGame.Application.Functions.Jobs.Command.Update
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public UpdateJobCommandHandler(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var mappedJob = _mapper.Map<Job>(request);

            await _jobRepository.UpdateAsync(mappedJob);

            return Unit.Value;
        }
    }
}
