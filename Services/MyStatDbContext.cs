using Microsoft.EntityFrameworkCore;
using MyStat.Models;

namespace MyStat.Services
{
    public class MyStatDbContext :DbContext
    {
        public MyStatDbContext(DbContextOptions<MyStatDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<HomeworkItem> Homeworks { get; set; }
    }
}
