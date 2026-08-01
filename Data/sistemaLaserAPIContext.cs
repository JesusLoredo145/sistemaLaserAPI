using sistemaLaserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace sistemaLaserAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }
        public DbSet<Incident> Incidents => Set<Incident>();
    }
}
