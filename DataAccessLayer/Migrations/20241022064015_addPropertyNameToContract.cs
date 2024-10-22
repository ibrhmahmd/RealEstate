using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyNameToContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "PropertyId", "State", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("01157cc6-9c28-4b9b-948d-c1744e3c6aaf"), "Hurghada", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("103a8d13-6a36-4d28-88cd-8c90dbe3cf35"), "Asyut", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Asyut", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16478982-c0d6-4ba0-a691-255e87cf093e"), "Qena", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qena", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("24369022-b10e-4022-a8f5-2c1e9b942b68"), "Kafr El Sheikh", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kafr El Sheikh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("35320928-074a-419d-bb9b-2a9ac9a42fd7"), "Cairo", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39419233-bdf3-4210-94bf-88890bba2bac"), "Arish", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "North Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44ccf349-6538-4317-9701-643999cfeb87"), "Benha", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5eaa9d85-742b-4527-9615-6304070310c6"), "Kharga", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "New Valley", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f452efc-5d7f-4ed6-9b32-4b66cc0c9b49"), "Sohag", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sohag", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d3c6e5f-01cf-4c21-83b5-6746dbc2741d"), "Mansoura", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("743a2cfc-b08f-45c8-8848-99539a402073"), "Alexandria", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Alexandria", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b753b07-305a-4741-aedf-8e75dde68983"), "Beni Suef", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8128afb7-5b38-4b3a-8e97-ca766e6d19b8"), "Fayoum", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d8269e1-15e9-4bea-bec9-5cbb60cb2909"), "Damietta", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Damietta", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("913e2811-d431-4860-8cc1-99d881644ca7"), "Aswan", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("940229e8-b1aa-4245-a94d-2c96ffbe7789"), "Marsa Matruh", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Matrouh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("96f53347-c770-4fca-b694-9278360f2b4c"), "Port Said", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9a3b698-a557-44d7-974b-656324690a43"), "Zagazig", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sharqia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa095f35-bd2c-4558-9814-e409b3a02e0e"), "Sharm El Sheikh", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "South Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb660f6d-be20-4cbf-8418-61344c6362f8"), "Suez", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Suez", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d518b45e-d4f4-4a7d-a132-89f767e36d96"), "Shibin El Kom", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d726fcea-4b68-4e47-9aae-1bbae604096d"), "Ismailia", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ed2a96a9-6174-48bd-97cd-47c538d613c3"), "Tanta", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Gharbia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("efe3b99f-325d-4412-9200-800c9e9a7b07"), "Giza", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2dfc321-8771-4d0f-b4a9-7a3c7c8dac92"), "Luxor", new Guid("e1962c44-c9ec-4411-8f40-8fde599b891d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("01157cc6-9c28-4b9b-948d-c1744e3c6aaf"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("103a8d13-6a36-4d28-88cd-8c90dbe3cf35"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("16478982-c0d6-4ba0-a691-255e87cf093e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("24369022-b10e-4022-a8f5-2c1e9b942b68"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("35320928-074a-419d-bb9b-2a9ac9a42fd7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("39419233-bdf3-4210-94bf-88890bba2bac"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("44ccf349-6538-4317-9701-643999cfeb87"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5eaa9d85-742b-4527-9615-6304070310c6"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5f452efc-5d7f-4ed6-9b32-4b66cc0c9b49"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6d3c6e5f-01cf-4c21-83b5-6746dbc2741d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("743a2cfc-b08f-45c8-8848-99539a402073"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7b753b07-305a-4741-aedf-8e75dde68983"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8128afb7-5b38-4b3a-8e97-ca766e6d19b8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8d8269e1-15e9-4bea-bec9-5cbb60cb2909"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("913e2811-d431-4860-8cc1-99d881644ca7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("940229e8-b1aa-4245-a94d-2c96ffbe7789"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("96f53347-c770-4fca-b694-9278360f2b4c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a9a3b698-a557-44d7-974b-656324690a43"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("aa095f35-bd2c-4558-9814-e409b3a02e0e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("cb660f6d-be20-4cbf-8418-61344c6362f8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d518b45e-d4f4-4a7d-a132-89f767e36d96"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d726fcea-4b68-4e47-9aae-1bbae604096d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("ed2a96a9-6174-48bd-97cd-47c538d613c3"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("efe3b99f-325d-4412-9200-800c9e9a7b07"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("f2dfc321-8771-4d0f-b4a9-7a3c7c8dac92"));

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Contracts");

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
    }
}
