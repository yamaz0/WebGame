using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Jobs.Query.GetJob
{
    public class GetJobRequest : IRequest<GetJobViewModel>
    {
        public GetJobRequest(int id)
        {
            JobId = id;
        }

        public int JobId { get; set; }
    }
}
