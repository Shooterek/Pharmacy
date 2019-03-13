using System;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}