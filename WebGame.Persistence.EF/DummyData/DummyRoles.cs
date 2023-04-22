using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Constants;

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
                    Name=ConstantsAuthorization.Roles.PLAYER,
                    ConcurrencyStamp=ConstantsAuthorization.Roles.PLAYER,
                    NormalizedName=ConstantsAuthorization.Roles.PLAYER.ToUpper()

                },
                new IdentityRole()
                {
                    Id="adminRoleId",
                    Name=ConstantsAuthorization.Roles.ADMINISTRATOR,
                    ConcurrencyStamp=ConstantsAuthorization.Roles.ADMINISTRATOR,
                    NormalizedName=ConstantsAuthorization.Roles.ADMINISTRATOR.ToUpper()
                }
            };
        }
    }
}
