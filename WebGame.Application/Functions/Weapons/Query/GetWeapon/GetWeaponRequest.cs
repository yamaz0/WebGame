using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Weapons.Query.GetWeapon
{
    public class GetWeaponRequest : IRequest<GetWeaponViewModel>
    {
        public GetWeaponRequest(int id)
        {
            WeaponId = id;
        }

        public int WeaponId { get; set; }
    }
}
