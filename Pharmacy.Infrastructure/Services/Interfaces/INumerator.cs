using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services.Interfaces
{
    public interface INumerator
    {
        void SetName(OrderDto order);
        void SetName(SaleDto sale);
        void SetName(PrescriptionDto prescription);
    }
}