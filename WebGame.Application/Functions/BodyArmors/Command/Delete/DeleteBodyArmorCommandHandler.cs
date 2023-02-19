using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.BodyArmors.Command.Delete
{
    public class DeleteBodyArmorCommandHandler : IRequestHandler<DeleteBodyArmorCommand>
    {
        private readonly IBodyArmorRepository _bodyArmorRepository;

        public DeleteBodyArmorCommandHandler(IBodyArmorRepository bodyArmorRepository)
        {
            _bodyArmorRepository = bodyArmorRepository;
        }

        public async Task<Unit> Handle(DeleteBodyArmorCommand request, CancellationToken cancellationToken)
        {
            var bodyArmorToDelete = await _bodyArmorRepository.GetByIdAsync(request.bodyArmorId);
            await _bodyArmorRepository.RemoveAsync(bodyArmorToDelete);
            return Unit.Value;
        }
    }
}
