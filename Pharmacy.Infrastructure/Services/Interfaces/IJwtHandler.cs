using System;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services.Interfaces
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}