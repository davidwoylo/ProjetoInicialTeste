//using Data.Mapping;
using Data.Mapping;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produto { get; set; }

    }
}