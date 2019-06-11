using System.Threading.Tasks;
using Pharmacy.Infrastructure.EF;

namespace Pharmacy.Infrastructure.Repositories
{
    public class UnitOfWork
    {
        private readonly PharmacyContext _pharmacyContext;

        public UnitOfWork(PharmacyContext pharmacyContext)
        {
            _pharmacyContext = pharmacyContext;
        }

        public async Task Commit()
        {
            await _pharmacyContext.SaveChangesAsync();
        }
    }
}