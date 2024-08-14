using System.ComponentModel.DataAnnotations;

namespace Clean.Application.Dtos.Users
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
    }
}
