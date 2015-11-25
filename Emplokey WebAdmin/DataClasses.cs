namespace Emplokey_WebAdmin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataClasses : DbContext
    {
        public DataClasses()
            : base("name=DataClasses")
        {
        }

        public virtual DbSet<Auths> Auths { get; set; }
        public virtual DbSet<Computers> Computers { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auths>()
                .Property(e => e.Auth_key)
                .IsUnicode(false);

            modelBuilder.Entity<Auths>()
                .Property(e => e.Device)
                .IsUnicode(false);

            modelBuilder.Entity<Computers>()
                .Property(e => e.PC_name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<Emplokey_WebAdmin.Models.LogsViewModel> LogsViewModels { get; set; }

        public System.Data.Entity.DbSet<Emplokey_WebAdmin.Models.StatisticsModel> StatisticsModels { get; set; }
    }
}
