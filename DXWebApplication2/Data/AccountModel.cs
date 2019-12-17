namespace DXWebApplication2.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccountModel : DbContext
    {
        public AccountModel()
            : base("name=AccountConnection")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Acc_Number)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.ACC_Parent)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(20, 9);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Accounts1)
                .WithOptional(e => e.Account1)
                .HasForeignKey(e => e.ACC_Parent);
        }
    }
}
