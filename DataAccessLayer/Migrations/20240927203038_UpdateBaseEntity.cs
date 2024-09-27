using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Properties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Contracts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Addresses",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Properties",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contracts",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Addresses",
                newName: "ID");
        }
    }
}
