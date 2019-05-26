using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Repositories;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Infrastructure.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public SaleService(IMedicamentRepository medicamentRepository, IMapper mapper, UnitOfWork unitOfWork, ISaleRepository saleRepository, IPrescriptionRepository prescriptionRepository)
        {
            _medicamentRepository = medicamentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _saleRepository = saleRepository;
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<SaleDto> AddAsync(SaleDto sale)
        {
            var result = _saleRepository.Add(_mapper.Map<SaleDto, Sale>(sale));

            Dictionary<Guid, int> elements = new Dictionary<Guid, int>();

            foreach (var resultPrescription in result.Prescriptions)
            {
                foreach (var prescriptionElement in resultPrescription.Elements)
                {
                    if (elements.ContainsKey(prescriptionElement.MedicamentId))
                    {
                        elements[prescriptionElement.MedicamentId] += prescriptionElement.Quantity;
                    }
                    else
                    {
                        elements.Add(prescriptionElement.MedicamentId, prescriptionElement.Quantity);
                    }
                }
            }

            foreach (var saleElement in sale.MedicamentsSoldWithoutPrescription)
            {
                if (elements.ContainsKey(saleElement.MedicamentId))
                {
                    elements[saleElement.MedicamentId] += saleElement.Quantity;
                }
                else
                {
                    elements.Add(saleElement.MedicamentId, saleElement.Quantity);
                }
            }

            foreach (var element in elements)
            {
                var medicament = await _medicamentRepository.GetAsync(element.Key);
                medicament.Quantity -= element.Value;
            }

            foreach (var prescription in result.Prescriptions)
            {
                var pres = _prescriptionRepository.Add(prescription);
            }

            await _unitOfWork.Commit();

            return _mapper.Map<Sale, SaleDto>(result);
        }

        public async Task<IEnumerable<SaleDto>> GetAllAsync()
        {
            var sales = await _saleRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDto>>(sales);
        }

        public Task<SaleDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}