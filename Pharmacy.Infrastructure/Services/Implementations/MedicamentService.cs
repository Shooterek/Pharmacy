using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Repositories;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Infrastructure.Services.Implementations
{
    public class MedicamentService : IMedicamentService
    {
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicamentService(IMedicamentRepository medicamentRepository, IMapper mapper, UnitOfWork unitOfWork)
        {
            _medicamentRepository = medicamentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<MedicamentDto> GetAsync(Guid id)
        {
            var medicament = await _medicamentRepository.GetAsync(id);

            return _mapper.Map<Medicament, MedicamentDto>(medicament);
        }

        public async Task<IEnumerable<MedicamentDto>> GetAllAsync()
        {
            var medicaments = await _medicamentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Medicament>, IEnumerable<MedicamentDto>>(medicaments);
        }

        public async Task<MedicamentDto> AddAsync(MedicamentDto medicament)
        {
            var result = _medicamentRepository.Add(_mapper.Map<MedicamentDto, Medicament>(medicament));
            await _unitOfWork.Commit();

            return _mapper.Map<Medicament, MedicamentDto>(result);
        }

        public async Task UpdateAsync(MedicamentDto medicament)
        {
            _medicamentRepository.Update(_mapper.Map<MedicamentDto, Medicament>(medicament));
            await _unitOfWork.Commit();
        }
    }
}