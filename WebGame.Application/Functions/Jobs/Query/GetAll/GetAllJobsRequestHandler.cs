using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Jobs.Query.GetAll
{
    public class GetAllJobsRequestHandler : IRequestHandler<GetAllJobsRequest, List<GetAllJobsViewModel>>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public GetAllJobsRequestHandler(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllJobsViewModel>> Handle(GetAllJobsRequest request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAllAsync();
            var jobsViewModel = _mapper.Map<List<GetAllJobsViewModel>>(jobs);
            return jobsViewModel;
        }
    }
}
