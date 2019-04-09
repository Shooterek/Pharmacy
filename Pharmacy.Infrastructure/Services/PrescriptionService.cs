using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Repositories;

namespace Pharmacy.Infrastructure.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper, IMedicamentRepository medicamentRepository, UnitOfWork unitOfWork)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
            _medicamentRepository = medicamentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PrescriptionDto> AddAsync(PrescriptionDto prescription)
        {
            var result = _prescriptionRepository.Add(_mapper.Map<PrescriptionDto, Prescription>(prescription));

            foreach (var prescriptionElement in result.Elements)
            {
                var medicine = await _medicamentRepository.GetAsync(prescriptionElement.MedicamentId);
                medicine.Quantity -= prescriptionElement.Quantity;
            }

            await _unitOfWork.Commit();

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