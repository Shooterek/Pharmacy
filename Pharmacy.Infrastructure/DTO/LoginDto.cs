using System;

namespace Pharmacy.Infrastructure.DTO
{
    public class LoginDto
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}