using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;

namespace WebGame.Application.Functions.Weapons.Query.GetListWeapons
{
    public class GetListWeaponsRequest : IRequest<List<GetListWeaponsViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
