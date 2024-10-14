using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addressupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("007cfc89-4b25-44ef-a6b9-8a24df4d696d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("15e5ae48-becd-4b8a-b339-5abe35ef8e71"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("17fafdcc-a9dd-40d2-b3e2-88c5568fb5a2"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("24517bac-31df-4b98-b394-b16228758354"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("25705a2e-cff9-4606-bf74-5043ef3f1477"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("34e19ae3-b499-4c63-a28a-ea92481240d6"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("410966ec-eea7-4e4a-a378-9f040ef29209"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("4961fbcd-8d28-4d4f-ad3f-cf548741b2cf"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("55a021b5-719b-4bba-9893-05555c98b4ec"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6d3ebf8a-ea2e-436e-b286-f99d80fb676f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("71ca308d-bed8-4243-96c6-c8ce81a15ec4"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7a947dac-6b09-430a-95ab-96fb726a29bb"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7dbf68b9-7557-478b-9b64-cb24dfe3af95"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8f08e0d3-bbfd-4f49-a38a-5cad081d5038"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("92fe85b8-c36b-43ff-a0a9-89b41e1e15cc"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("9d7b2d5a-ce32-40fd-a786-b01546503638"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a02ee3bf-eac0-4537-8967-acb93e781655"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a71a35f0-92f4-437f-8b0e-f968d3335006"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b3d06528-3bc3-4024-8d10-c012284fbeae"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b8bd5e1f-ba15-4e24-bb3e-c52a041c389c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("bbf9cde4-744b-4cf6-8044-ac8587d040e2"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d35acd60-ced7-46e6-a9eb-a4f47b011f94"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d8ee5993-dcdb-4b9e-944b-1d2223e68ef5"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("f6f596f6-92df-4374-9c63-b7a466ac4112"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("fa94d78c-fdff-46de-ad36-ede9a6e506a3"));

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "PropertyId", "State", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("0016c8f8-0805-42b1-be9a-746a51b6bb69"), "Sharm El Sheikh", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "South Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e267fca-f373-46ff-abe8-36507666e544"), "Zagazig", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sharqia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("178eaf79-8003-41dd-8f05-60dbed5e2137"), "Alexandria", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Alexandria", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("18e3b025-bc43-405d-be24-4403d8bc1074"), "Cairo", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ac77b8d-722d-45f7-9a48-128203e1c74f"), "Kharga", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "New Valley", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("216da716-0ee9-40d3-a369-d7a1b6634ba5"), "Port Said", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("506c3277-1c01-4507-a322-a17bc4a72aa2"), "Giza", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("517ede93-18bf-48bd-9ffa-20cd4f45d327"), "Suez", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Suez", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60eeb3cb-b723-473c-886b-6689202e32b2"), "Luxor", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6133a034-5b25-4a01-97ad-b5f104b00a1b"), "Kafr El Sheikh", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kafr El Sheikh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64b179a5-c3e4-4140-8b43-8e8d5e331aec"), "Marsa Matruh", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Matrouh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64e15532-bac3-416e-8248-a491a6f1c019"), "Sohag", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sohag", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ebec159-eecb-427f-8bf1-18056fcf6f16"), "Asyut", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Asyut", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76769b5a-3b27-4407-a37f-ee956090cd04"), "Tanta", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Gharbia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c584014-9450-452b-a9cc-6936cf8947b0"), "Beni Suef", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89185273-a1d8-4ae3-a727-c12e24251a55"), "Shibin El Kom", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a1d11f0-48ff-4d2c-ac26-08b52c1e561b"), "Qena", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qena", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b7e1638-2854-45ee-befb-907148d01781"), "Damietta", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Damietta", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ee5fc86-39a1-4345-a5d7-3276389bea0a"), "Aswan", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa0d0083-0062-457a-b186-2566342444f5"), "Hurghada", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b585faf9-fc7a-46c2-bc3f-a49d58da3fbb"), "Arish", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "North Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb31e02a-9154-4408-be0e-01f0998aea8a"), "Mansoura", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d35ac829-a9f8-4393-8f39-5f0ddcf4ba84"), "Fayoum", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3a84b31-4092-4038-8cfb-3c81f243df54"), "Ismailia", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f65fc50d-6708-40e9-a862-603157ef7d99"), "Benha", new Guid("bdb908a0-8f1b-4245-ab86-9d3e4c6ef891"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PropertyId",
                table: "Addresses",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Properties_PropertyId",
                table: "Addresses",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Properties_PropertyId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PropertyId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("0016c8f8-0805-42b1-be9a-746a51b6bb69"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("0e267fca-f373-46ff-abe8-36507666e544"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("178eaf79-8003-41dd-8f05-60dbed5e2137"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("18e3b025-bc43-405d-be24-4403d8bc1074"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("1ac77b8d-722d-45f7-9a48-128203e1c74f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("216da716-0ee9-40d3-a369-d7a1b6634ba5"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("506c3277-1c01-4507-a322-a17bc4a72aa2"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("517ede93-18bf-48bd-9ffa-20cd4f45d327"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("60eeb3cb-b723-473c-886b-6689202e32b2"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6133a034-5b25-4a01-97ad-b5f104b00a1b"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("64b179a5-c3e4-4140-8b43-8e8d5e331aec"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("64e15532-bac3-416e-8248-a491a6f1c019"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6ebec159-eecb-427f-8bf1-18056fcf6f16"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("76769b5a-3b27-4407-a37f-ee956090cd04"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7c584014-9450-452b-a9cc-6936cf8947b0"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("89185273-a1d8-4ae3-a727-c12e24251a55"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8a1d11f0-48ff-4d2c-ac26-08b52c1e561b"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8b7e1638-2854-45ee-befb-907148d01781"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("9ee5fc86-39a1-4345-a5d7-3276389bea0a"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("aa0d0083-0062-457a-b186-2566342444f5"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b585faf9-fc7a-46c2-bc3f-a49d58da3fbb"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("cb31e02a-9154-4408-be0e-01f0998aea8a"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d35ac829-a9f8-4393-8f39-5f0ddcf4ba84"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("e3a84b31-4092-4038-8cfb-3c81f243df54"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("f65fc50d-6708-40e9-a862-603157ef7d99"));

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "State", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("007cfc89-4b25-44ef-a6b9-8a24df4d696d"), "Tanta", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Gharbia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15e5ae48-becd-4b8a-b339-5abe35ef8e71"), "Marsa Matruh", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Matrouh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("17fafdcc-a9dd-40d2-b3e2-88c5568fb5a2"), "Alexandria", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Alexandria", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("24517bac-31df-4b98-b394-b16228758354"), "Shibin El Kom", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("25705a2e-cff9-4606-bf74-5043ef3f1477"), "Kharga", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "New Valley", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34e19ae3-b499-4c63-a28a-ea92481240d6"), "Giza", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("410966ec-eea7-4e4a-a378-9f040ef29209"), "Luxor", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4961fbcd-8d28-4d4f-ad3f-cf548741b2cf"), "Damietta", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Damietta", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55a021b5-719b-4bba-9893-05555c98b4ec"), "Aswan", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d3ebf8a-ea2e-436e-b286-f99d80fb676f"), "Sohag", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sohag", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("71ca308d-bed8-4243-96c6-c8ce81a15ec4"), "Hurghada", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a947dac-6b09-430a-95ab-96fb726a29bb"), "Beni Suef", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7dbf68b9-7557-478b-9b64-cb24dfe3af95"), "Port Said", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f08e0d3-bbfd-4f49-a38a-5cad081d5038"), "Arish", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "North Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("92fe85b8-c36b-43ff-a0a9-89b41e1e15cc"), "Cairo", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d7b2d5a-ce32-40fd-a786-b01546503638"), "Sharm El Sheikh", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "South Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a02ee3bf-eac0-4537-8967-acb93e781655"), "Qena", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Qena", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a71a35f0-92f4-437f-8b0e-f968d3335006"), "Kafr El Sheikh", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kafr El Sheikh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3d06528-3bc3-4024-8d10-c012284fbeae"), "Benha", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8bd5e1f-ba15-4e24-bb3e-c52a041c389c"), "Ismailia", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbf9cde4-744b-4cf6-8044-ac8587d040e2"), "Zagazig", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sharqia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d35acd60-ced7-46e6-a9eb-a4f47b011f94"), "Mansoura", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8ee5993-dcdb-4b9e-944b-1d2223e68ef5"), "Asyut", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Asyut", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6f596f6-92df-4374-9c63-b7a466ac4112"), "Fayoum", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa94d78c-fdff-46de-ad36-ede9a6e506a3"), "Suez", new Guid("2dcd198b-9a36-4a6c-bfb7-ad5e8e22c62c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Suez", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
