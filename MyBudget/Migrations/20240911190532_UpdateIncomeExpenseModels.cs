using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIncomeExpenseModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistories_AccountBalances_AccountBalanceID",
                table: "ExpenseHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistories_AccountBalances_AccountBalanceID",
                table: "IncomeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistories_IncomeCategories_IncomeCategoryID",
                table: "IncomeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeHistories",
                table: "IncomeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseHistories",
                table: "ExpenseHistories");

            migrationBuilder.RenameTable(
                name: "IncomeHistories",
                newName: "IncomeHistory");

            migrationBuilder.RenameTable(
                name: "ExpenseHistories",
                newName: "ExpenseHistory");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeHistories_IncomeCategoryID",
                table: "IncomeHistory",
                newName: "IX_IncomeHistory_IncomeCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeHistories_AccountBalanceID",
                table: "IncomeHistory",
                newName: "IX_IncomeHistory_AccountBalanceID");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseHistories_AccountBalanceID",
                table: "ExpenseHistory",
                newName: "IX_ExpenseHistory_AccountBalanceID");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "IncomeHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeHistory",
                table: "IncomeHistory",
                column: "IncomeHistoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseHistory",
                table: "ExpenseHistory",
                column: "ExpenseHistoryID");

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
                name: "FK_IncomeHistory_IncomeCategories_IncomeCategoryID",
                table: "IncomeHistory",
                column: "IncomeCategoryID",
                principalTable: "IncomeCategories",
                principalColumn: "IncomeCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_AccountBalances_AccountBalanceID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_AccountBalances_AccountBalanceID",
                table: "IncomeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_IncomeCategories_IncomeCategoryID",
                table: "IncomeHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeHistory",
                table: "IncomeHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseHistory",
                table: "ExpenseHistory");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "IncomeHistory");

            migrationBuilder.RenameTable(
                name: "IncomeHistory",
                newName: "IncomeHistories");

            migrationBuilder.RenameTable(
                name: "ExpenseHistory",
                newName: "ExpenseHistories");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeHistory_IncomeCategoryID",
                table: "IncomeHistories",
                newName: "IX_IncomeHistories_IncomeCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeHistory_AccountBalanceID",
                table: "IncomeHistories",
                newName: "IX_IncomeHistories_AccountBalanceID");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseHistory_AccountBalanceID",
                table: "ExpenseHistories",
                newName: "IX_ExpenseHistories_AccountBalanceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeHistories",
                table: "IncomeHistories",
                column: "IncomeHistoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseHistories",
                table: "ExpenseHistories",
                column: "ExpenseHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistories_AccountBalances_AccountBalanceID",
                table: "ExpenseHistories",
                column: "AccountBalanceID",
                principalTable: "AccountBalances",
                principalColumn: "AccountBalanceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistories_AccountBalances_AccountBalanceID",
                table: "IncomeHistories",
                column: "AccountBalanceID",
                principalTable: "AccountBalances",
                principalColumn: "AccountBalanceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistories_IncomeCategories_IncomeCategoryID",
                table: "IncomeHistories",
                column: "IncomeCategoryID",
                principalTable: "IncomeCategories",
                principalColumn: "IncomeCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
