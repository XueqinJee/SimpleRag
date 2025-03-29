using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
        }


        public DbSet<Knowledge> Knowledge { get; set; }
    }
}
