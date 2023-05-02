using Base.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Base.Infrastructure.Data.Contexts
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAssemblyConfiguration();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInclusao") != null))
            //{

            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataInclusao").CurrentValue = DateTime.Now;

            //        foreach (var prop in entry.Entity.GetType().GetProperties())
            //        {

            //            if (prop.Name == "Ativo")
            //            {
            //                entry.Property("Ativo").CurrentValue = Convert.ToByte(1);
            //            }
            //            else if (prop.Name == "DataAlteracao")
            //            {
            //                entry.Property("DataAlteracao").CurrentValue = null;
            //            }
            //            else if (prop.Name == "IdUsuarioAlteracao")
            //            {
            //                entry.Property("IdUsuarioAlteracao").CurrentValue = null;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
            //        entry.Property("DataInclusao").IsModified = false;
            //        entry.Property("IdUsuarioInclusao").IsModified = false;
            //    }
            //}

            return base.SaveChanges();
        }

       public DbSet<Fluxo> Sample { get; set; }
    }
}
