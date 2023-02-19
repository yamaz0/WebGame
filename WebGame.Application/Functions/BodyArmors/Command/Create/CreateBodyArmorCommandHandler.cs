using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.BodyArmors.Command.Create
{
    public class CreateBodyArmorCommandHandler : IRequestHandler<CreateBodyArmorCommand, CreateBodyArmorCommandResponse>
    {
        private readonly IBodyArmorRepository _bodyArmorRepository;

        public CreateBodyArmorCommandHandler(IBodyArmorRepository bodyArmorRepository)
        {
            _bodyArmorRepository = bodyArmorRepository;
        }

        public async Task<CreateBodyArmorCommandResponse> Handle(CreateBodyArmorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBodyArmorCommandValidate();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid)
            {
                return new CreateBodyArmorCommandResponse(validatorResult);
            }

            BodyArmor bodyArmor = new BodyArmor()
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                Defense = request.Defense,
                ItemType = request.ItemType
            };

            bodyArmor = await _bodyArmorRepository.AddAsync(bodyArmor);
            return new CreateBodyArmorCommandResponse(bodyArmor.Id);
        }
    }
}