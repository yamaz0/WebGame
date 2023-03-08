using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Persistence.EF.DummyData
{
    public class DummyRoles
    {
        public static List<IdentityRole> Get()
        {
            return new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id="playerRoleId",
                    Name="Player",
                    ConcurrencyStamp="Player",
                    NormalizedName="Player"

                },
                new IdentityRole()
                {
                    Id="adminRoleId",
                    Name="Administrator",
                    ConcurrencyStamp="Administrator",
                    NormalizedName="Administrator"
                }
            };
        }
    }
}
