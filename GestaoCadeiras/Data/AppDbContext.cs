using GestaoCadeiras.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GestaoCadeiras.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Cadeira> Cadeiras { get; set; } = null!;
        public DbSet<Agenda> Agendas { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
