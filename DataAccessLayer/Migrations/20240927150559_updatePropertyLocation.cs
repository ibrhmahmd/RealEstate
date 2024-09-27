using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatePropertyLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Properties_PropertyID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Users_UserID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Contract_ContractId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressID",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_UserID",
                table: "Contracts",
                newName: "IX_Contracts_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_PropertyID",
                table: "Contracts",
                newName: "IX_Contracts_PropertyID");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressID",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Properties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Properties_PropertyID",
                table: "Contracts",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Users_UserID",
                table: "Contracts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Contracts_ContractId",
                table: "Payments",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressID",
                table: "Properties",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Properties_PropertyID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Users_UserID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Contracts_ContractId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressID",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_UserID",
                table: "Contract",
                newName: "IX_Contract_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_PropertyID",
                table: "Contract",
                newName: "IX_Contract_PropertyID");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressID",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Properties_PropertyID",
                table: "Contract",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Users_UserID",
                table: "Contract",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Contract_ContractId",
                table: "Payments",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressID",
                table: "Properties",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
