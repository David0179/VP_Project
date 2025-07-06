using BlazorCRUD.library;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
base(options)
        { }
        public DbSet<Product> tbl_Products { get; set; } // Tablemapping
    }
}











