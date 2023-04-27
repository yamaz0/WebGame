using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Enemies.Query.GetArmor
{
    public class GetArmorRequest : IRequest<GetArmorViewModel>
    {
        public GetArmorRequest(int id)
        {
            ArmorId = id;
        }

        public int ArmorId { get; set; }
    }
}