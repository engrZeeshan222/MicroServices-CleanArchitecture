using Clean.Domain.CommonEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.Domain.Entities
{
    public class User:BaseEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        [ForeignKey("RoleId")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int OTP { get; set; } = 1;
        public DateTime OTPExpireTime { get; set; }
    }
}
