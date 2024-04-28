using System;
using System.ComponentModel.DataAnnotations;

namespace Learning.Data.UserRoles
{
    public class Roles
    {
        [Key]
        public Guid RoleId { get; set; }
        public required string RoleName { get; set; }
        public string? RoleDescription { get; set; }
    }
}
