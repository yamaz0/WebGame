using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Weapons.Query.GetWeapon
{
    public class GetWeaponRequestHandler : IRequestHandler<GetWeaponRequest, GetWeaponViewModel>
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IMapper _mapper;

        public GetWeaponRequestHandler(IWeaponRepository weaponRepository, IMapper mapper)
        {
            _weaponRepository = weaponRepository;
            _mapper = mapper;
        }

        public async Task<GetWeaponViewModel> Handle(GetWeaponRequest request, CancellationToken cancellationToken)
        {
            var weapon = await _weaponRepository.GetByIdAsync(request.WeaponId);
            var mappedWeapon = _mapper.Map<GetWeaponViewModel>(weapon);

            return mappedWeapon;
        }
    }
}
