using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Weapons.Query.GetListWeapons
{
    public class GetListWeaponsRequestHandler : IRequestHandler<GetListWeaponsRequest, List<GetListWeaponsViewModel>>
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IMapper _mapper;

        public GetListWeaponsRequestHandler(IWeaponRepository weaponRepository, IMapper mapper)
        {
            _weaponRepository = weaponRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListWeaponsViewModel>> Handle(GetListWeaponsRequest request, CancellationToken cancellationToken)
        {
            var weapons = await _weaponRepository.GetPagedWeaponsAsync(request.Page, request.PageSize);
            var weaponsViewModel = _mapper.Map<List<GetListWeaponsViewModel>>(weapons);
            weaponsViewModel.Sort((x, y) => x.Value.CompareTo(y.Value));
            return weaponsViewModel;
        }
    }
}
