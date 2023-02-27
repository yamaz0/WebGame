using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Jobs.Query.GetOne;

namespace WebGame.Application.Functions.Enemies.Query.GetArmor
{
    public class GetArmorRequest : IRequest<GetArmorViewModel>
    {
        public int ArmorId { get; set; }
    }
}