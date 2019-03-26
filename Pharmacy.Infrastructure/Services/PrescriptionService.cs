using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private IPrescriptionRepository _prescriptionRepository;
        private IMapper _mapper;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
        }

        public async Task<PrescriptionDto> AddAsync(PrescriptionDto prescription)
        {
            var result = await _prescriptionRepository.AddAsync(_mapper.Map<PrescriptionDto, Prescription>(prescription));

            return _mapper.Map<Prescription, PrescriptionDto>(result);
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllAsync()
        {
            var result = await _prescriptionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Prescription>, IEnumerable<PrescriptionDto>>(result);
        }

        public async Task<PrescriptionDto> GetAsync(Guid id)
        {
            var result = await _prescriptionRepository.GetAsync(id);

            return _mapper.Map<Prescription, PrescriptionDto>(result);
        }
    }
}