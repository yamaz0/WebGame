using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Weapons.Command.Create
{
    public class CreateWeaponCommandHandler : IRequestHandler<CreateWeaponCommand, CreateWeaponCommandResponse>
    {
        private readonly IWeaponRepository _weaponRepository;

        public CreateWeaponCommandHandler(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public async Task<CreateWeaponCommandResponse> Handle(CreateWeaponCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWeaponCommandValidate();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new CreateWeaponCommandResponse(validatorResult);
            }

            Weapon weapon = new Weapon()
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                Attack = request.Attack,
                AttackSpeed = request.AttackSpeed,
            };

            weapon = await _weaponRepository.AddAsync(weapon);
            return new CreateWeaponCommandResponse(weapon.Id);
        }
    }
}
