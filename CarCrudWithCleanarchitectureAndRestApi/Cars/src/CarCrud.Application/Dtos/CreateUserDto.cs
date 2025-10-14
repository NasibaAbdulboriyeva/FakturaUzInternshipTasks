using CarCrud.Domain.Entities;

namespace CarCrud.Application.Dtos
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
        public string Password { get; set; }

    }
}
