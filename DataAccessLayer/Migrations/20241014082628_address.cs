using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
