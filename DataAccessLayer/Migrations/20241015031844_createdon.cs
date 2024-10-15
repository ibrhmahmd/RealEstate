using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class createdon : Migration
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
                keyValue: new Guid("d741d14b-c19a-4ba6-9f8e-bd15c3aeb595"));

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "PropertyId", "State", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("174ef951-f910-4b58-8cb8-660c94f33046"), "Sohag", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sohag", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f74824b-f4f2-4537-948f-bbe5fab0f6d7"), "Shibin El Kom", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39f58690-61bc-4c23-8d77-5cb7d828373c"), "Beni Suef", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3dd48729-a759-405b-9059-68200231212e"), "Zagazig", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sharqia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d9908cc-9bbc-48dc-867b-6d6c464b92c4"), "Alexandria", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Alexandria", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59577066-a8bc-4e87-a91c-cd5ae066f8ad"), "Benha", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e742b01-89e2-454c-ba8e-d366beea8633"), "Mansoura", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e8cea12-c9f3-4ff3-9764-3dae6dac5bfe"), "Port Said", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70c98906-4e55-4a13-9bd3-9f94205adf14"), "Ismailia", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("82bad673-1ee7-4c09-b92a-9131fb6c1afb"), "Damietta", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Damietta", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("837f376c-87a1-4111-8187-0ddeb3e8c8b0"), "Aswan", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85126d15-1a06-4d1a-b07c-86d949783109"), "Suez", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Suez", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("851badff-2056-4a02-8eac-6170e8784eac"), "Tanta", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Gharbia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c83d7d3-fd68-41e0-bfeb-9fb62b5b3566"), "Sharm El Sheikh", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "South Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8eb9bb96-9a22-483a-8546-6a959d9fb691"), "Cairo", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2b767d3-f355-4ce3-91e8-c5f629320252"), "Qena", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qena", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("acb168b5-3499-459e-8ec3-2670670836bd"), "Arish", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "North Sinai", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0441299-cb13-4c9b-821a-f38ad2f09acf"), "Kafr El Sheikh", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kafr El Sheikh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bcd5f923-4e68-416d-9d81-9659cd736b5d"), "Fayoum", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c57afc56-662f-4967-b1d6-b4870636ea5f"), "Luxor", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d40dc909-dd1e-45de-ac76-696351ac3410"), "Hurghada", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0f4b646-b576-42e8-89c2-ad212d9bf581"), "Giza", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8b1d0de-79e4-480d-bfee-a31a1166be7b"), "Asyut", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Asyut", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa770cba-fff3-4b14-962e-d13d7410f917"), "Kharga", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "New Valley", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fae758f8-751b-4fb6-aaa7-965284b105b3"), "Marsa Matruh", new Guid("b399aba6-26a1-43f7-b5ae-f7b903c380f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Matrouh", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("174ef951-f910-4b58-8cb8-660c94f33046"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("1f74824b-f4f2-4537-948f-bbe5fab0f6d7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("39f58690-61bc-4c23-8d77-5cb7d828373c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3dd48729-a759-405b-9059-68200231212e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("4d9908cc-9bbc-48dc-867b-6d6c464b92c4"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("59577066-a8bc-4e87-a91c-cd5ae066f8ad"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6e742b01-89e2-454c-ba8e-d366beea8633"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6e8cea12-c9f3-4ff3-9764-3dae6dac5bfe"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("70c98906-4e55-4a13-9bd3-9f94205adf14"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("82bad673-1ee7-4c09-b92a-9131fb6c1afb"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("837f376c-87a1-4111-8187-0ddeb3e8c8b0"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("85126d15-1a06-4d1a-b07c-86d949783109"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("851badff-2056-4a02-8eac-6170e8784eac"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c83d7d3-fd68-41e0-bfeb-9fb62b5b3566"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8eb9bb96-9a22-483a-8546-6a959d9fb691"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a2b767d3-f355-4ce3-91e8-c5f629320252"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("acb168b5-3499-459e-8ec3-2670670836bd"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b0441299-cb13-4c9b-821a-f38ad2f09acf"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("bcd5f923-4e68-416d-9d81-9659cd736b5d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c57afc56-662f-4967-b1d6-b4870636ea5f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d40dc909-dd1e-45de-ac76-696351ac3410"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("e0f4b646-b576-42e8-89c2-ad212d9bf581"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("e8b1d0de-79e4-480d-bfee-a31a1166be7b"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("fa770cba-fff3-4b14-962e-d13d7410f917"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("fae758f8-751b-4fb6-aaa7-965284b105b3"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

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
                    { new Guid("81483128-ca3a-4f51-9da7-c5f52ec2eea1"), "Aswan", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Aswan", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9744c8c0-9384-4224-8b4b-29d2761d5cd7"), "Benha", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Qalyubia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a413d87d-a84b-4537-b4ef-a945ad77e902"), "Giza", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Giza", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aea7d2e0-0c0e-4a2a-866b-35873ba9e736"), "Mansoura", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Dakahlia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf365485-13f9-4f3a-a138-83c19ca3ccc5"), "Luxor", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Luxor", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c65382f6-410d-4a3b-a77f-614a214d6872"), "Ismailia", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ismailia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cfb3f009-47c3-4a41-9241-01e6e48e8e62"), "Fayoum", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Fayoum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d741d14b-c19a-4ba6-9f8e-bd15c3aeb595"), "Cairo", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd739034-9f45-4b85-9982-3fc761d051c7"), "Shibin El Kom", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Monufia", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4808bd2-e0ce-4972-8848-e69fa7618d25"), "Port Said", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Port Said", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea40de84-d1e3-4a7c-8a37-a4868a40352f"), "Hurghada", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Red Sea", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f88c7b4e-9f7d-4091-9732-6f73cf5ef43c"), "Beni Suef", new Guid("cdd94ce7-5654-4914-9168-f34d2e3342b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Beni Suef", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
