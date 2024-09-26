using Microsoft.EntityFrameworkCore;
using MyBudget.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyBudget.Data
{
    public class MyBudgetContext : DbContext
    {
        public MyBudgetContext(DbContextOptions<MyBudgetContext> options)
        : base(options)
        {
        }

        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<DepositHistory> DepositHistory { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<IncomeHistory> IncomeHistory { get; set; }
        public DbSet<ExpenseHistory> ExpenseHistory { get; set; }
        public DbSet<SavingsType> SavingsTypes { get; set; }
        public DbSet<SavingsHistory> SavingsHistories { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DepositHistory>()
                .HasOne(bh => bh.Deposit)
                .WithMany(ab => ab.DepositHistory)
                .HasForeignKey(bh => bh.DepositID);

            modelBuilder.Entity<IncomeHistory>()
                .HasOne(ih => ih.Deposit)
                .WithMany(ab => ab.IncomeHistories)
                .HasForeignKey(ih => ih.DepositID);

            modelBuilder.Entity<IncomeHistory>()
                .HasOne(ih => ih.IncomeCategory)
                .WithMany()
                .HasForeignKey(ih => ih.IncomeCategoryID);

            modelBuilder.Entity<ExpenseHistory>()
                .HasOne(eh => eh.Deposit)
                .WithMany(ab => ab.ExpenseHistories)
                .HasForeignKey(eh => eh.DepositID);

            modelBuilder.Entity<SavingsHistory>()
                .HasOne(sh => sh.Deposit)
                .WithMany(ab => ab.SavingsHistories)
                .HasForeignKey(sh => sh.DepositID);

            modelBuilder.Entity<SavingsHistory>()
                .HasOne(sh => sh.SavingsType)
                .WithMany()
                .HasForeignKey(sh => sh.SavingsTypeID);

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.SavingsType)
                .WithMany()
                .HasForeignKey(r => r.SavingsTypeID);
        }
    }
}
