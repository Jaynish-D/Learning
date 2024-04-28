using Learning.Data.UserEntity;
using Learning.Data.UserRoles;
using Microsoft.EntityFrameworkCore;

namespace Learning.Data
{
    public class ApplicationDBContext(
        DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
