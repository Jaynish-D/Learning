using System.ComponentModel.DataAnnotations;

namespace Learning.Data.UserEntity
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
