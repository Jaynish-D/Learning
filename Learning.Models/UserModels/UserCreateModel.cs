using System;

namespace Learning.Models.UserModels
{
    public class UserCreateModel
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid? RoleId { get; set; }
    }
}
