using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.BodyArmors.Command.Create
{
    public class CreateArmorCommandHandler : IRequestHandler<CreateArmorCommand, CreateArmorCommandResponse>
    {
        private readonly IArmorRepository _armorRepository;

        public CreateArmorCommandHandler(IArmorRepository armorRepository)
        {
            _armorRepository = armorRepository;
        }

        public async Task<CreateArmorCommandResponse> Handle(CreateArmorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateArmorCommandValidate();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid)
            {
                return new CreateArmorCommandResponse(validatorResult);
            }

            Armor armor = new Armor()
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                Defense = request.Defense,
                ItemType = request.ItemType
            };

            armor = await _armorRepository.AddAsync(armor);
            return new CreateArmorCommandResponse(armor.Id);
        }
    }
}