using CQRS.Data.Entities;
using Microsoft.EntityFrameworkCore; 

namespace CQRS.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
