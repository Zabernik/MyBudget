using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountBalances",
                columns: table => new
                {
                    AccountBalanceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountName = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalances", x => x.AccountBalanceID);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    IncomeCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.IncomeCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SavingsTypes",
                columns: table => new
                {
                    SavingsTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsTypes", x => x.SavingsTypeID);
                });

            migrationBuilder.CreateTable(
                name: "BalanceHistories",
                columns: table => new
                {
                    BalanceHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountBalanceID = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceHistories", x => x.BalanceHistoryID);
                    table.ForeignKey(
                        name: "FK_BalanceHistories_AccountBalances_AccountBalanceID",
                        column: x => x.AccountBalanceID,
                        principalTable: "AccountBalances",
                        principalColumn: "AccountBalanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseHistories",
                columns: table => new
                {
                    ExpenseHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountBalanceID = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseHistories", x => x.ExpenseHistoryID);
                    table.ForeignKey(
                        name: "FK_ExpenseHistories_AccountBalances_AccountBalanceID",
                        column: x => x.AccountBalanceID,
                        principalTable: "AccountBalances",
                        principalColumn: "AccountBalanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeHistories",
                columns: table => new
                {
                    IncomeHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountBalanceID = table.Column<int>(type: "INTEGER", nullable: false),
                    IncomeCategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeHistories", x => x.IncomeHistoryID);
                    table.ForeignKey(
                        name: "FK_IncomeHistories_AccountBalances_AccountBalanceID",
                        column: x => x.AccountBalanceID,
                        principalTable: "AccountBalances",
                        principalColumn: "AccountBalanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeHistories_IncomeCategories_IncomeCategoryID",
                        column: x => x.IncomeCategoryID,
                        principalTable: "IncomeCategories",
                        principalColumn: "IncomeCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    RateID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SavingsTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    RateValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    Source = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.RateID);
                    table.ForeignKey(
                        name: "FK_Rates_SavingsTypes_SavingsTypeID",
                        column: x => x.SavingsTypeID,
                        principalTable: "SavingsTypes",
                        principalColumn: "SavingsTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsHistories",
                columns: table => new
                {
                    SavingsHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountBalanceID = table.Column<int>(type: "INTEGER", nullable: false),
                    SavingsTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsHistories", x => x.SavingsHistoryID);
                    table.ForeignKey(
                        name: "FK_SavingsHistories_AccountBalances_AccountBalanceID",
                        column: x => x.AccountBalanceID,
                        principalTable: "AccountBalances",
                        principalColumn: "AccountBalanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavingsHistories_SavingsTypes_SavingsTypeID",
                        column: x => x.SavingsTypeID,
                        principalTable: "SavingsTypes",
                        principalColumn: "SavingsTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BalanceHistories_AccountBalanceID",
                table: "BalanceHistories",
                column: "AccountBalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseHistories_AccountBalanceID",
                table: "ExpenseHistories",
                column: "AccountBalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeHistories_AccountBalanceID",
                table: "IncomeHistories",
                column: "AccountBalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeHistories_IncomeCategoryID",
                table: "IncomeHistories",
                column: "IncomeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_SavingsTypeID",
                table: "Rates",
                column: "SavingsTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsHistories_AccountBalanceID",
                table: "SavingsHistories",
                column: "AccountBalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsHistories_SavingsTypeID",
                table: "SavingsHistories",
                column: "SavingsTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceHistories");

            migrationBuilder.DropTable(
                name: "ExpenseHistories");

            migrationBuilder.DropTable(
                name: "IncomeHistories");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "SavingsHistories");

            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.DropTable(
                name: "AccountBalances");

            migrationBuilder.DropTable(
                name: "SavingsTypes");
        }
    }
}
