﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBudget.Data;

#nullable disable

namespace MyBudget.Migrations
{
    [DbContext(typeof(MyBudgetContext))]
    partial class MyBudgetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("MyBudget.Models.Deposit", b =>
                {
                    b.Property<int>("DepositID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DepositName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("DepositID");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("MyBudget.Models.DepositHistory", b =>
                {
                    b.Property<int>("DepositHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepositID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DepositHistoryID");

                    b.HasIndex("DepositID");

                    b.ToTable("DepositHistory");
                });

            modelBuilder.Entity("MyBudget.Models.ExpenseHistory", b =>
                {
                    b.Property<int>("ExpenseHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepositID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ExpenseHistoryID");

                    b.HasIndex("DepositID");

                    b.ToTable("ExpenseHistory");
                });

            modelBuilder.Entity("MyBudget.Models.IncomeCategory", b =>
                {
                    b.Property<int>("IncomeCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IncomeCategoryID");

                    b.ToTable("IncomeCategories");
                });

            modelBuilder.Entity("MyBudget.Models.IncomeHistory", b =>
                {
                    b.Property<int>("IncomeHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepositID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IncomeCategoryID")
                        .HasColumnType("INTEGER");

                    b.HasKey("IncomeHistoryID");

                    b.HasIndex("DepositID");

                    b.HasIndex("IncomeCategoryID");

                    b.ToTable("IncomeHistory");
                });

            modelBuilder.Entity("MyBudget.Models.Rate", b =>
                {
                    b.Property<int>("RateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RateValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("SavingsTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RateID");

                    b.HasIndex("SavingsTypeID");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("MyBudget.Models.SavingsHistory", b =>
                {
                    b.Property<int>("SavingsHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepositID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SavingsTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("SavingsHistoryID");

                    b.HasIndex("DepositID");

                    b.HasIndex("SavingsTypeID");

                    b.ToTable("SavingsHistories");
                });

            modelBuilder.Entity("MyBudget.Models.SavingsType", b =>
                {
                    b.Property<int>("SavingsTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SavingsTypeID");

                    b.ToTable("SavingsTypes");
                });

            modelBuilder.Entity("MyBudget.Models.DepositHistory", b =>
                {
                    b.HasOne("MyBudget.Models.Deposit", "Deposit")
                        .WithMany("DepositHistory")
                        .HasForeignKey("DepositID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("MyBudget.Models.ExpenseHistory", b =>
                {
                    b.HasOne("MyBudget.Models.Deposit", "Deposit")
                        .WithMany("ExpenseHistories")
                        .HasForeignKey("DepositID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("MyBudget.Models.IncomeHistory", b =>
                {
                    b.HasOne("MyBudget.Models.Deposit", "Deposit")
                        .WithMany("IncomeHistories")
                        .HasForeignKey("DepositID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBudget.Models.IncomeCategory", "IncomeCategory")
                        .WithMany()
                        .HasForeignKey("IncomeCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deposit");

                    b.Navigation("IncomeCategory");
                });

            modelBuilder.Entity("MyBudget.Models.Rate", b =>
                {
                    b.HasOne("MyBudget.Models.SavingsType", "SavingsType")
                        .WithMany()
                        .HasForeignKey("SavingsTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SavingsType");
                });

            modelBuilder.Entity("MyBudget.Models.SavingsHistory", b =>
                {
                    b.HasOne("MyBudget.Models.Deposit", "Deposit")
                        .WithMany("SavingsHistories")
                        .HasForeignKey("DepositID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBudget.Models.SavingsType", "SavingsType")
                        .WithMany()
                        .HasForeignKey("SavingsTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deposit");

                    b.Navigation("SavingsType");
                });

            modelBuilder.Entity("MyBudget.Models.Deposit", b =>
                {
                    b.Navigation("DepositHistory");

                    b.Navigation("ExpenseHistories");

                    b.Navigation("IncomeHistories");

                    b.Navigation("SavingsHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
