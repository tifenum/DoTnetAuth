using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class StudentDB : DbContext
    {
        public StudentDB(DbContextOptions<StudentDB> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
