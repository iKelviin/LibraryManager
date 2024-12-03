using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoanEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BookReturned",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookReturned",
                table: "Loans");
        }
    }
}
