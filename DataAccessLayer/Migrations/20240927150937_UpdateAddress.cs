using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_AddressID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Properties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressID",
                table: "Properties",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressID",
                table: "Properties",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");
        }
    }
}
