using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.Db
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    }
}
