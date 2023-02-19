using AutoMapper;
using MediatR;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Weapons.Query
{
    public class GetAllWeaponsRequestHandler : IRequestHandler<GetAllWeaponsRequest, List<GetAllWeaponsViewModel>>
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IMapper _mapper;

        public GetAllWeaponsRequestHandler(IWeaponRepository weaponRepository, IMapper mapper)
        {
            _weaponRepository = weaponRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllWeaponsViewModel>> Handle(GetAllWeaponsRequest request, CancellationToken cancellationToken)
        {
            var weapons = await _weaponRepository.GetAllAsync();
            var weaponsViewModel = _mapper.Map<List<GetAllWeaponsViewModel>>(weapons);
            return weaponsViewModel;
        }
    }
}