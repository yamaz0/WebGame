using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Weapons.Command.Create
{

    public class CreateWeaponCommandResponse : BasicResponse
    {
        public int? WeaponId { get; set; }

        public CreateWeaponCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreateWeaponCommandResponse(int? weaponId)
        {
            WeaponId = weaponId;
        }
    }
}
