using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyNameForContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("0a6da93a-4ad3-4a21-b5fa-be75910fdd79"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("0b2bec22-74cb-42a3-991d-21e8c4785438"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("13d1f239-1ac0-4c02-ba80-457e0e099e00"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("156a7d8e-a52d-423e-a2f1-dd43fbb4c112"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("293972ee-f104-4125-abde-cd86bfcd0677"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2d4ba94e-25e2-4f5a-a214-534e972c1921"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3995d304-6f14-4bc8-aa27-deb220097998"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3b9e2589-7827-4fd8-91e5-bdc6bf1fbb1b"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("42162484-7a8a-4ac2-924f-d95b22d0ca59"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("4a4266ff-6561-4509-9659-41248ebd4684"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("4f7f74e5-02f9-422c-9e72-ec7ae9e9171e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("561b12ef-8ae8-4d0e-8c66-027d69f08847"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("747ef39d-d8b4-4dcf-a0a7-21c63fcf8bec"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7e9c2323-8aa0-4dcd-8891-6fb9216ce511"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("81483128-ca3a-4f51-9da7-c5f52ec2eea1"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("9744c8c0-9384-4224-8b4b-29d2761d5cd7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a413d87d-a84b-4537-b4ef-a945ad77e902"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("aea7d2e0-0c0e-4a2a-866b-35873ba9e736"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("bf365485-13f9-4f3a-a138-83c19ca3ccc5"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c65382f6-410d-4a3b-a77f-614a214d6872"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("cfb3f009-47c3-4a41-9241-01e6e48e8e62"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("dd739034-9f45-4b85-9982-3fc761d051c7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("e4808bd2-e0ce-4972-8848-e69fa7618d25"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("ea40de84-d1e3-4a7c-8a37-a4868a40352f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("f88c7b4e-9f7d-4091-9732-6f73cf5ef43c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "Contracts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "PropertyId", "State", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("0fed6861-1b64-4457-992d-75cef2713d70"), "Arish", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5334), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "North Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("128251fa-f98e-47a1-9329-9897bc59afc8"), "Kharga", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5349), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "New Valley", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20220888-5e71-4cac-9436-09742469530c"), "Ismailia", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5033), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2881e140-71bd-4180-8ffb-3c9cea97ec2a"), "Giza", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(4966), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("320d919e-634b-4720-99f1-1ac9dd3a8be7"), "Fayoum", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5082), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34566498-553c-4c62-8bda-0615336397a3"), "Alexandria", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(4957), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Alexandria", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("396fc14c-b57f-46b9-83f1-17073c123338"), "Luxor", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5279), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40e01d66-39ba-494b-b8ae-7dea10de748d"), "Asyut", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Asyut", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c5706c3-9554-42d1-8687-3eda61575c8e"), "Port Said", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5026), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d48b654-2738-4f01-b57c-c24deb4ae54f"), "Shibin El Kom", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5068), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("642aeedd-5b28-4150-ac81-c62d482fcca5"), "Suez", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5353), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Suez", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("65ddf8c0-77f3-4fd9-b5be-d86b12c1d45e"), "Damietta", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5012), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Damietta", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7254dbf0-0847-4ed0-9d1f-639d64fd02ed"), "Kafr El Sheikh", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5045), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kafr El Sheikh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75877e99-849b-4879-842e-6b9f9b309bfb"), "Hurghada", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5300), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b59bc6f-1f00-4213-95eb-24d8d3d94367"), "Tanta", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5056), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Gharbia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c8cd42c-24c1-46b6-98de-f598e1a2b487"), "Aswan", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5284), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc206c92-32ed-4b6a-a767-ece6e8a6e0be"), "Cairo", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(4788), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c311b5f9-3a92-495f-a508-2429c2d207af"), "Sohag", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5252), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sohag", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c395f07f-588d-40f3-a151-f7feace4584f"), "Qena", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5274), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qena", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca608311-e458-4a3b-a009-972555893dfc"), "Beni Suef", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5075), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd3b8a44-9e08-4404-8cdf-22ec3d0077d7"), "Zagazig", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5040), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sharqia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0c1536c-c491-4628-acf3-089fe272e194"), "Benha", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(4987), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dccac3c1-25b7-46b3-a7e4-240fd056c4b1"), "Sharm El Sheikh", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5330), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "South Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6ff7a54-f329-4311-ad5e-687600237436"), "Marsa Matruh", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(5344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Matrouh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fd041810-0cbd-4fbc-b6b7-1fe934be9f2d"), "Mansoura", new Guid("9b83a162-99a8-4c3f-ba19-b793c4b2a3bd"), new DateTime(2024, 10, 20, 16, 53, 28, 436, DateTimeKind.Local).AddTicks(4995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("0fed6861-1b64-4457-992d-75cef2713d70"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("128251fa-f98e-47a1-9329-9897bc59afc8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("20220888-5e71-4cac-9436-09742469530c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2881e140-71bd-4180-8ffb-3c9cea97ec2a"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("320d919e-634b-4720-99f1-1ac9dd3a8be7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("34566498-553c-4c62-8bda-0615336397a3"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("396fc14c-b57f-46b9-83f1-17073c123338"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("40e01d66-39ba-494b-b8ae-7dea10de748d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5c5706c3-9554-42d1-8687-3eda61575c8e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5d48b654-2738-4f01-b57c-c24deb4ae54f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("642aeedd-5b28-4150-ac81-c62d482fcca5"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("65ddf8c0-77f3-4fd9-b5be-d86b12c1d45e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7254dbf0-0847-4ed0-9d1f-639d64fd02ed"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("75877e99-849b-4879-842e-6b9f9b309bfb"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7b59bc6f-1f00-4213-95eb-24d8d3d94367"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("9c8cd42c-24c1-46b6-98de-f598e1a2b487"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("bc206c92-32ed-4b6a-a767-ece6e8a6e0be"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c311b5f9-3a92-495f-a508-2429c2d207af"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c395f07f-588d-40f3-a151-f7feace4584f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("ca608311-e458-4a3b-a009-972555893dfc"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("cd3b8a44-9e08-4404-8cdf-22ec3d0077d7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d0c1536c-c491-4628-acf3-089fe272e194"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("dccac3c1-25b7-46b3-a7e4-240fd056c4b1"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("e6ff7a54-f329-4311-ad5e-687600237436"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("fd041810-0cbd-4fbc-b6b7-1fe934be9f2d"));

            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "Contracts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "PropertyId", "State", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("0a6da93a-4ad3-4a21-b5fa-be75910fdd79"), "Sharm El Sheikh", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "South Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b2bec22-74cb-42a3-991d-21e8c4785438"), "Kharga", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "New Valley", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13d1f239-1ac0-4c02-ba80-457e0e099e00"), "Asyut", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Asyut", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("156a7d8e-a52d-423e-a2f1-dd43fbb4c112"), "Kafr El Sheikh", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kafr El Sheikh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("293972ee-f104-4125-abde-cd86bfcd0677"), "Marsa Matruh", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Matrouh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d4ba94e-25e2-4f5a-a214-534e972c1921"), "Tanta", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Gharbia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3995d304-6f14-4bc8-aa27-deb220097998"), "Damietta", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Damietta", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b9e2589-7827-4fd8-91e5-bdc6bf1fbb1b"), "Sohag", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sohag", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42162484-7a8a-4ac2-924f-d95b22d0ca59"), "Suez", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Suez", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a4266ff-6561-4509-9659-41248ebd4684"), "Alexandria", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Alexandria", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f7f74e5-02f9-422c-9e72-ec7ae9e9171e"), "Qena", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qena", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("561b12ef-8ae8-4d0e-8c66-027d69f08847"), "Arish", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "North Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("747ef39d-d8b4-4dcf-a0a7-21c63fcf8bec"), "Zagazig", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sharqia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e9c2323-8aa0-4dcd-8891-6fb9216ce511"), "Cairo", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("81483128-ca3a-4f51-9da7-c5f52ec2eea1"), "Aswan", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9744c8c0-9384-4224-8b4b-29d2761d5cd7"), "Benha", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a413d87d-a84b-4537-b4ef-a945ad77e902"), "Giza", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aea7d2e0-0c0e-4a2a-866b-35873ba9e736"), "Mansoura", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf365485-13f9-4f3a-a138-83c19ca3ccc5"), "Luxor", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c65382f6-410d-4a3b-a77f-614a214d6872"), "Ismailia", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cfb3f009-47c3-4a41-9241-01e6e48e8e62"), "Fayoum", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd739034-9f45-4b85-9982-3fc761d051c7"), "Shibin El Kom", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4808bd2-e0ce-4972-8848-e69fa7618d25"), "Port Said", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea40de84-d1e3-4a7c-8a37-a4868a40352f"), "Hurghada", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f88c7b4e-9f7d-4091-9732-6f73cf5ef43c"), "Beni Suef", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
