using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Jobs.Query.GetOne;

namespace WebGame.Application.Functions.Enemies.Query.GetBodyArmor
{
    public class GetBodyArmorRequest : IRequest<GetBodyArmorViewModel>
    {
        public int BodyArmorId { get; set; }
    }
}