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

        public DbSet<AccountBalance> AccountBalances { get; set; }
        public DbSet<BalanceHistory> BalanceHistories { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<IncomeHistory> IncomeHistories { get; set; }
        public DbSet<ExpenseHistory> ExpenseHistories { get; set; }
        public DbSet<SavingsType> SavingsTypes { get; set; }
        public DbSet<SavingsHistory> SavingsHistories { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurations
            modelBuilder.Entity<BalanceHistory>()
                .HasOne(bh => bh.AccountBalance)
                .WithMany(ab => ab.BalanceHistories)
                .HasForeignKey(bh => bh.AccountBalanceID);

            modelBuilder.Entity<IncomeHistory>()
                .HasOne(ih => ih.AccountBalance)
                .WithMany(ab => ab.IncomeHistories)
                .HasForeignKey(ih => ih.AccountBalanceID);

            modelBuilder.Entity<IncomeHistory>()
                .HasOne(ih => ih.IncomeCategory)
                .WithMany()
                .HasForeignKey(ih => ih.IncomeCategoryID);

            modelBuilder.Entity<ExpenseHistory>()
                .HasOne(eh => eh.AccountBalance)
                .WithMany(ab => ab.ExpenseHistories)
                .HasForeignKey(eh => eh.AccountBalanceID);

            modelBuilder.Entity<SavingsHistory>()
                .HasOne(sh => sh.AccountBalance)
                .WithMany(ab => ab.SavingsHistories)
                .HasForeignKey(sh => sh.AccountBalanceID);

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
