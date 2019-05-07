namespace Pharmacy.Infrastructure.DTO
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Education { get; set; }
    }
}