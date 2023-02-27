using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Jobs.Query.GetJob
{
    public class GetJobViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Reward { get; set; }
    }
}
