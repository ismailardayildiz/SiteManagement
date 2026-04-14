using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagement.Data.Migrations
{
    public partial class AddProfileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("066247ba-ca2c-4554-9311-bd96d8658923"),
                column: "ConcurrencyStamp",
                value: "53832ef9-4101-4a79-b2e9-9984c580284b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("44a9b0b3-9df5-4b85-83ac-608abfe46207"),
                column: "ConcurrencyStamp",
                value: "5627255a-fc14-4382-98ab-e0f852764e83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("45f843cb-d1e5-4a6b-afa3-3ab105d3b159"),
                column: "ConcurrencyStamp",
                value: "8c4f6efb-6ad6-4989-8668-42550edbd00b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("813c1780-e84a-4992-9676-2da6e6bb38df"),
                column: "ConcurrencyStamp",
                value: "9b15548d-5e21-4ff7-bb88-93d6f8ad1e83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8407beb3-e2b8-483d-b7c5-f159327aa74b"),
                column: "ConcurrencyStamp",
                value: "cea61106-7215-4494-a04f-80e7d3433416");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44010978-e210-4db8-81e9-6f191695953b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ad580ff-55f2-41f0-8c3b-3b0fa0c63988", "AQAAAAEAACcQAAAAEDXehQIJG6jNT9WrTkEo3VFO0sLhvCtY12AuYgg/6qF3Ye/pOG7G6Qr3PqhPr8xD0w==", "4ae6d66e-eefd-4d7a-b3c4-28094f043732" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("589da78a-0fd1-4fdf-bdde-4bf626b0b2df"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "011bead0-9e3f-4760-a340-eaab90fc990a", "AQAAAAEAACcQAAAAEPLiA6dIru48qXAmKwxtaksX2+ECjDTg+kqW4sy2FmOx8xdztiCCggfKSFeyQmTzXw==", "7bfbddba-91ec-483e-a4a7-e86a09e68c40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6b6ce5a-93ac-44d1-936b-ed80b6f9b04f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8775e85a-aac7-4293-a5a6-d403d56b0842", "AQAAAAEAACcQAAAAEErrB27q0jWB5cW4f8upVnA3hBItdKWPe2RjyMCPAXn5dVwsKNgdPJH+0HTnbY4l/A==", "4cfc4332-b4ab-405a-af90-075e611fa94f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7d6b220-df25-4981-842f-e9aa283c9988", "AQAAAAEAACcQAAAAELzk49hxmrpdcBvxSOfAS5ReC8sSAUKeF/dx198+1XejZPvhGfvU7GhQfLaxz2iWKQ==", "84f65303-68ce-4d5c-8c26-97622b780631" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e00938b6-2d1a-4a8a-9956-c02e2238157c", "AQAAAAEAACcQAAAAEJ+MZqG/BdpQRELzziCxfs/10CgtMmgMyyv2voWeC9UR3ZAnh191a9EPbm6uRR8BPQ==", "0d5646e9-a9ab-474b-bdb3-6e6aa017dd21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d27b379-1ef0-4d0d-b302-8f0519369fbb", "AQAAAAEAACcQAAAAEIE9Fp+eTR+TiqD/MS0JEexcKYDOd6uP4rimqXSNvu8KxqxRk8L2y/MgD8pmTJ2wpw==", "491334be-489b-44dd-b44d-41228e8b7862" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("066247ba-ca2c-4554-9311-bd96d8658923"),
                column: "ConcurrencyStamp",
                value: "da45abd6-f019-4b8e-9efe-c6360447b981");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("44a9b0b3-9df5-4b85-83ac-608abfe46207"),
                column: "ConcurrencyStamp",
                value: "4d738c2c-b227-4681-8c77-37cb6ffb772f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("45f843cb-d1e5-4a6b-afa3-3ab105d3b159"),
                column: "ConcurrencyStamp",
                value: "6dd9419e-2fcf-4503-8eaf-ff17ec107906");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("813c1780-e84a-4992-9676-2da6e6bb38df"),
                column: "ConcurrencyStamp",
                value: "e247d7d6-c166-4bef-9ff6-f4ac82ffe275");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8407beb3-e2b8-483d-b7c5-f159327aa74b"),
                column: "ConcurrencyStamp",
                value: "a30bb6b1-5a37-42f0-8bf5-731514504352");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44010978-e210-4db8-81e9-6f191695953b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22adbdde-8f90-4fe7-aa80-d8a2f731936a", "AQAAAAEAACcQAAAAEHutHVQtRjRQf+ivN4bL9Y7Uzt/qX5WRaXhKBMURMf8AWeHh15ZjEU0fQ08DEf0Sdg==", "f4dbb079-6248-4d7a-8518-6c9bf04a5ec1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("589da78a-0fd1-4fdf-bdde-4bf626b0b2df"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b011fa0e-8aad-47c6-a253-868af88a11ba", "AQAAAAEAACcQAAAAEHEicO2PBJsogJWLJRyQ0gW1Oor0HScnQJumnMA15b7QTa42EK/HhKC+OcR8L3rr4A==", "9d0c6685-1fc3-44c1-87e0-445382bc196b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6b6ce5a-93ac-44d1-936b-ed80b6f9b04f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c598451-1b3e-4fef-ae98-5e5cedc1fb19", "AQAAAAEAACcQAAAAEJk8qS/lbvHdl7LLFJhRT2qhr+yUG9I/ixLuF1UgVrkdVGXTKDZirPpNWVhdLQipmg==", "fc97d115-a5d6-45ad-a8c7-741726348d6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1227ac2-82c4-48c2-97ac-3d2f30d344a2", "AQAAAAEAACcQAAAAEEtwUQO6QxFzwPUIApjhyep2ERXEZwEH/OCS1a89ArbFKJFFEXLrtC33DvPkhs9TZg==", "57145f03-2dc7-4ce2-992f-ed8ff1226c45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53707e20-2eba-48cc-a252-82692c18e207", "AQAAAAEAACcQAAAAEIUNvi3S4EoJT1cfy+yIbqmv3znEkn5KhNGpp/UuLLYekBoneoIQ4z4iMSOMUhHv5Q==", "45db9a5e-1198-4cab-a6da-9f2655085592" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "786470ba-d779-41d5-a8bd-722f0b734de5", "AQAAAAEAACcQAAAAEA2zDjpGbnJBhJ2P/OS1qLfHwvAr1tMyPbvNLFIwpSUYwXzrKy7m8u15G+BJeMEoGA==", "f4742ec2-19eb-43c2-814e-63364f357811" });
        }
    }
}
