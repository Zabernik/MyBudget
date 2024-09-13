using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_AccountBalances_AccountBalanceID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_AccountBalances_AccountBalanceID",
                table: "IncomeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsHistories_AccountBalances_AccountBalanceID",
                table: "SavingsHistories");

            migrationBuilder.DropTable(
                name: "BalanceHistories");

            migrationBuilder.DropTable(
                name: "AccountBalances");

            migrationBuilder.RenameColumn(
                name: "AccountBalanceID",
                table: "SavingsHistories",
                newName: "DepositID");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsHistories_AccountBalanceID",
                table: "SavingsHistories",
                newName: "IX_SavingsHistories_DepositID");

            migrationBuilder.RenameColumn(
                name: "AccountBalanceID",
                table: "IncomeHistory",
                newName: "DepositID");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeHistory_AccountBalanceID",
                table: "IncomeHistory",
                newName: "IX_IncomeHistory_DepositID");

            migrationBuilder.RenameColumn(
                name: "AccountBalanceID",
                table: "ExpenseHistory",
                newName: "DepositID");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseHistory_AccountBalanceID",
                table: "ExpenseHistory",
                newName: "IX_ExpenseHistory_DepositID");

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    DepositID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepositName = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.DepositID);
                });

            migrationBuilder.CreateTable(
                name: "DepositHistory",
                columns: table => new
                {
                    DepositHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepositID = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositHistory", x => x.DepositHistoryID);
                    table.ForeignKey(
                        name: "FK_DepositHistory_Deposit_DepositID",
                        column: x => x.DepositID,
                        principalTable: "Deposit",
                        principalColumn: "DepositID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositHistory_DepositID",
                table: "DepositHistory",
                column: "DepositID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistory_Deposit_DepositID",
                table: "ExpenseHistory",
                column: "DepositID",
                principalTable: "Deposit",
                principalColumn: "DepositID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistory_Deposit_DepositID",
                table: "IncomeHistory",
                column: "DepositID",
                principalTable: "Deposit",
                principalColumn: "DepositID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsHistories_Deposit_DepositID",
                table: "SavingsHistories",
                column: "DepositID",
                principalTable: "Deposit",
                principalColumn: "DepositID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_Deposit_DepositID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_Deposit_DepositID",
                table: "IncomeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsHistories_Deposit_DepositID",
                table: "SavingsHistories");

            migrationBuilder.DropTable(
                name: "DepositHistory");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.RenameColumn(
                name: "DepositID",
                table: "SavingsHistories",
                newName: "AccountBalanceID");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsHistories_DepositID",
                table: "SavingsHistories",
                newName: "IX_SavingsHistories_AccountBalanceID");

            migrationBuilder.RenameColumn(
                name: "DepositID",
                table: "IncomeHistory",
                newName: "AccountBalanceID");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeHistory_DepositID",
                table: "IncomeHistory",
                newName: "IX_IncomeHistory_AccountBalanceID");

            migrationBuilder.RenameColumn(
                name: "DepositID",
                table: "ExpenseHistory",
                newName: "AccountBalanceID");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseHistory_DepositID",
                table: "ExpenseHistory",
                newName: "IX_ExpenseHistory_AccountBalanceID");

            migrationBuilder.CreateTable(
                name: "AccountBalances",
                columns: table => new
                {
                    AccountBalanceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountName = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalances", x => x.AccountBalanceID);
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

            migrationBuilder.CreateIndex(
                name: "IX_BalanceHistories_AccountBalanceID",
                table: "BalanceHistories",
                column: "AccountBalanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistory_AccountBalances_AccountBalanceID",
                table: "ExpenseHistory",
                column: "AccountBalanceID",
                principalTable: "AccountBalances",
                principalColumn: "AccountBalanceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistory_AccountBalances_AccountBalanceID",
                table: "IncomeHistory",
                column: "AccountBalanceID",
                principalTable: "AccountBalances",
                principalColumn: "AccountBalanceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsHistories_AccountBalances_AccountBalanceID",
                table: "SavingsHistories",
                column: "AccountBalanceID",
                principalTable: "AccountBalances",
                principalColumn: "AccountBalanceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
