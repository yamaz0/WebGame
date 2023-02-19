using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Jobs.Command.Delete
{
    public class DeleteJobCommand : IRequest
    {
        public int JobId { get; set; }
    }
}
