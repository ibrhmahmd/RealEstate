using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatesoncontract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Occupantname",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeclienedOn",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDecliened",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Occupantname",
                table: "Contracts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "PropertyId", "State", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("04350930-9518-48ce-996b-c6b02425cb97"), "Alexandria", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Alexandria", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("072fbf38-353c-4262-b009-f953e6c7ced8"), "Giza", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2089473d-2a48-493f-897b-9acf20672600"), "Arish", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "North Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d735f15-ae3d-4298-be88-21de857c28a7"), "Tanta", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Gharbia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3017c434-fc0e-454c-bdc8-de8870ca307e"), "Marsa Matruh", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Matrouh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("32628f7f-0273-4003-a614-9ae639f57076"), "Kafr El Sheikh", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kafr El Sheikh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("336eea9e-fea7-40ae-b6a9-9cb5c8c9d0ef"), "Zagazig", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sharqia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3387a175-79a6-4048-a103-bc839b79b8ca"), "Ismailia", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cd2f081-fea9-4a36-9adc-1eb6708a4181"), "Suez", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Suez", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("504a8a9c-ec52-4d26-b7c8-eb961ac340c2"), "Mansoura", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55703e79-e22d-4b38-a435-12e39210088c"), "Cairo", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5734eb65-6931-4455-b916-5a82c92529d5"), "Beni Suef", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5857b9e2-a207-4f7e-885e-8d3f225addbc"), "Hurghada", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e5c025c-143d-4883-9385-a893eb56e106"), "Port Said", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60368f4d-6da0-448e-81db-6bd559c5e95c"), "Asyut", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Asyut", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("621c529a-2110-42ae-8279-9548fc710f9b"), "Benha", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63a11154-cb66-4764-b58c-b88a4cca07ff"), "Kharga", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "New Valley", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6bbf104d-bb2d-40bc-9e0c-a39a2790b28f"), "Sohag", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sohag", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ccc7a5c-3b2e-48ba-a91f-9a58724b55fd"), "Damietta", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Damietta", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8cd5b541-5d01-44a9-bf79-4ef42cf58cb8"), "Fayoum", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6e1eaec-613b-459a-9a12-2f919be6545e"), "Aswan", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b82e5f1c-f8a0-4d54-ae86-d1a8e348a7af"), "Sharm El Sheikh", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "South Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b95ca32b-d791-4b3f-871c-b086106857ac"), "Luxor", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ccc03344-1757-4d70-9046-45c6ae6f14ba"), "Qena", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qena", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e68e5a0a-9b60-4a67-9b91-4a47393a9b1d"), "Shibin El Kom", new Guid("2bfcd8a7-5e28-4637-bdba-1a0adb730441"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("04350930-9518-48ce-996b-c6b02425cb97"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("072fbf38-353c-4262-b009-f953e6c7ced8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2089473d-2a48-493f-897b-9acf20672600"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2d735f15-ae3d-4298-be88-21de857c28a7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3017c434-fc0e-454c-bdc8-de8870ca307e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("32628f7f-0273-4003-a614-9ae639f57076"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("336eea9e-fea7-40ae-b6a9-9cb5c8c9d0ef"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3387a175-79a6-4048-a103-bc839b79b8ca"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3cd2f081-fea9-4a36-9adc-1eb6708a4181"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("504a8a9c-ec52-4d26-b7c8-eb961ac340c2"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("55703e79-e22d-4b38-a435-12e39210088c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5734eb65-6931-4455-b916-5a82c92529d5"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5857b9e2-a207-4f7e-885e-8d3f225addbc"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("5e5c025c-143d-4883-9385-a893eb56e106"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("60368f4d-6da0-448e-81db-6bd559c5e95c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("621c529a-2110-42ae-8279-9548fc710f9b"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("63a11154-cb66-4764-b58c-b88a4cca07ff"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6bbf104d-bb2d-40bc-9e0c-a39a2790b28f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7ccc7a5c-3b2e-48ba-a91f-9a58724b55fd"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8cd5b541-5d01-44a9-bf79-4ef42cf58cb8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a6e1eaec-613b-459a-9a12-2f919be6545e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b82e5f1c-f8a0-4d54-ae86-d1a8e348a7af"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b95ca32b-d791-4b3f-871c-b086106857ac"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("ccc03344-1757-4d70-9046-45c6ae6f14ba"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("e68e5a0a-9b60-4a67-9b91-4a47393a9b1d"));

            migrationBuilder.DropColumn(
                name: "Occupantname",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DeclienedOn",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "IsDecliened",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Occupantname",
                table: "Contracts");

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
    }
}
