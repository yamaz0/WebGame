using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Armors.Command.Delete
{
    public class DeleteArmorCommandHandler : IRequestHandler<DeleteArmorCommand>
    {
        private readonly IArmorRepository _armorRepository;

        public DeleteArmorCommandHandler(IArmorRepository armorRepository)
        {
            _armorRepository = armorRepository;
        }

        public async Task<Unit> Handle(DeleteArmorCommand request, CancellationToken cancellationToken)
        {
            var armorToDelete = await _armorRepository.GetByIdAsync(request.ArmorId);
            await _armorRepository.RemoveAsync(armorToDelete);
            return Unit.Value;
        }
    }
}
