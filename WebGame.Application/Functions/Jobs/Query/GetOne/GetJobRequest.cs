using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Jobs.Query.GetOne
{
    public class GetJobRequest : IRequest<GetJobViewModel>
    {
        public int JobId { get; set; }
    }
}
