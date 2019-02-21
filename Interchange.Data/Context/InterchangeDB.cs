using Interchange.Entity;
using System.Data.Entity;

namespace Interchange.Data
{
    public class InterchangeDB : DbContext
    {
        public InterchangeDB() : base("DefaultConnectionString")
        { }

        public DbSet<InterchangeHeader> InterchangeHeader { get; set; }
        public DbSet<InterchangeDetail> InterchangeDetail { get; set; }
        public DbSet<InterchangeName> InterchangeName { get; set; }
        public DbSet<InterchangeAddress> InterchangeAddress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InterchangeHeader>()
                .Property(p => p.FeeAmt)
                .HasPrecision(15, 2);
            modelBuilder.Entity<InterchangeHeader>()
                .Property(p => p.AmtPaid)
                .HasPrecision(15, 2);
            modelBuilder.Entity<InterchangeHeader>()
                .Property(p => p.Balance)
                .HasPrecision(15, 2);

            modelBuilder.Entity<InterchangeDetail>()
                .Property(p => p.FeeSort)
                .HasPrecision(5, 2);
            modelBuilder.Entity<InterchangeDetail>()
                .Property(p => p.FeeAmt)
                .HasPrecision(15, 2);
            modelBuilder.Entity<InterchangeDetail>()
                .Property(p => p.AmtPaid)
                .HasPrecision(15, 2);
            modelBuilder.Entity<InterchangeDetail>()
                .Property(p => p.Balance)
                .HasPrecision(15, 2);
        }
    }
}
