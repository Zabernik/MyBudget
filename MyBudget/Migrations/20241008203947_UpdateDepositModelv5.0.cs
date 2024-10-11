using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDepositModelv50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ActualDeposit",
                table: "DepositHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualDeposit",
                table: "DepositHistory");
        }
    }
}
