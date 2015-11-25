namespace Emplokey_ActivityUpdater
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmplokeyContext : DbContext
    {
        public EmplokeyContext()
            : base("name=EmplokeyContext")
        {
        }

        public virtual DbSet<Auths> Auths { get; set; }
        public virtual DbSet<Computers> Computers { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
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
    }
}
