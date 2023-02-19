using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Weapons.Command.Delete
{
    public class DeleteWeaponCommandHandler : IRequestHandler<DeleteWeaponCommand>
    {
        private readonly IWeaponRepository _weaponRepository;

        public DeleteWeaponCommandHandler(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public async Task<Unit> Handle(DeleteWeaponCommand request, CancellationToken cancellationToken)
        {
            var weaponToDelete = await _weaponRepository.GetByIdAsync(request.WeaponId);
            await _weaponRepository.RemoveAsync(weaponToDelete);
            return Unit.Value;
        }
    }
}
