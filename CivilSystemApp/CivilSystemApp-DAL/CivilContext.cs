using CivilSystemApp_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CivilSystemApp_DAL
{
    public partial class CivilContext : DbContext
    {
        private readonly string _connectionString = "Data Source=USER\\SQL22;Database=CivilSystem;Integrated Security=True;TrustServerCertificate=True";
        public CivilContext()
        {
        }

        public CivilContext(string civilSystemConnectionString)
        {
            _connectionString = civilSystemConnectionString;
        }

        public CivilContext(DbContextOptions<CivilContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Citizen> Citizens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_connectionString != null && _connectionString.Trim() != "")
                    optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable("Citizens");

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
