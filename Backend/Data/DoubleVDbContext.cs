using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSamuelGarcia.Models;

namespace PruebaTecnicaSamuelGarcia.Data
{
    public class DoubleVDbContext : DbContext
    {

        public DoubleVDbContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Ticket>Tickets {  get; set; }

    }
}
