using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services
{
    public class MedicamentService : IMedicamentService
    {
        private IMedicamentRepository _medicamentRepository;
        private IMapper _mapper;

        public MedicamentService(IMedicamentRepository medicamentRepository, IMapper mapper)
        {
            _medicamentRepository = medicamentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicamentDto>> GetAllAsync()
        {
            var medicaments = await _medicamentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Medicament>, IEnumerable<MedicamentDto>>(medicaments);
        }

        public async Task<MedicamentDto> AddAsync(MedicamentDto medicament)
        {
            var result = await _medicamentRepository.AddAsync(_mapper.Map<MedicamentDto, Medicament>(medicament));

            return _mapper.Map<Medicament, MedicamentDto>(result);
        }
    }
}