using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Jobs.Query.GetJob
{
    public class GetJobRequestHandler : IRequestHandler<GetJobRequest, GetJobViewModel>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public GetJobRequestHandler(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<GetJobViewModel> Handle(GetJobRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.JobId);
            var mappedJob = _mapper.Map<GetJobViewModel>(job);
            return mappedJob;
        }
    }
}
