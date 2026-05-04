using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagement.Data.Migrations
{
    public partial class EMP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Employees",
                newName: "HireDate");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Employees",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Employees",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Employees",
                newName: "TerminationDate");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("066247ba-ca2c-4554-9311-bd96d8658923"),
                column: "ConcurrencyStamp",
                value: "3b37779f-7a1b-48cc-82bd-98e3e83eee93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("44a9b0b3-9df5-4b85-83ac-608abfe46207"),
                column: "ConcurrencyStamp",
                value: "ecf45ff4-a1a6-415b-abbb-eddc071ebfec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("45f843cb-d1e5-4a6b-afa3-3ab105d3b159"),
                column: "ConcurrencyStamp",
                value: "b9fcb222-0499-4d2e-8b09-a94df004e04e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("813c1780-e84a-4992-9676-2da6e6bb38df"),
                column: "ConcurrencyStamp",
                value: "f3b8f7ac-8b80-4be9-9cf2-58cfd96aa903");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8407beb3-e2b8-483d-b7c5-f159327aa74b"),
                column: "ConcurrencyStamp",
                value: "c7940356-7e88-4909-b03b-eb8c83044c05");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44010978-e210-4db8-81e9-6f191695953b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3d25baf-f5b5-4a0b-a491-1aa82a82270f", "AQAAAAEAACcQAAAAELfaWBNHgmKDJtFUQYvpxWPDvaOamwxSHwk287RG71VGHUtb0bR/3cb6BN8t6UcXwA==", "6220a05e-58a3-460e-9f50-a7d5db96fa96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("589da78a-0fd1-4fdf-bdde-4bf626b0b2df"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d3933a0-6862-4883-ba9b-f985cb6bec6c", "AQAAAAEAACcQAAAAEEZXooR5j8KaARs6FIsrGoerUToM/yLRMrMYpbrxG3RR5l9OHBXc+Q1Vciyu3CimIw==", "ea562beb-43a8-4ba5-9651-9c33668801c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6b6ce5a-93ac-44d1-936b-ed80b6f9b04f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f033178f-8008-497e-8816-27b14947abd1", "AQAAAAEAACcQAAAAEN1pAQ/XzjX6F7mLuxAfeWfFC0+hyk6dkhBkc+Y0WkhsIi1tEQCg0lWqDxrc6le4jQ==", "e628007e-1057-4545-be31-c110ecc3c8a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a88f0b30-92f9-4bda-b73f-b2e0bc65c617", "AQAAAAEAACcQAAAAEG/ddGDhfbsTO3IZVLkD3zIIq2LePxZieX34kxArjP/N0IWevW50TA53++1GdtWUQA==", "a6596339-2181-4c99-a269-1bb2f8932a73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5d68775-665b-410e-b9bf-83d372b9d3da", "AQAAAAEAACcQAAAAEFgVRrUq/vwTLLrY541snYLAgMo3/2n9N1q1xeBBSMAlI3FzTPMyxfReZXRpDSv1Cw==", "c200211f-e839-46f0-9d73-46d594d8002f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "982c68cd-7222-47cf-8f90-66006cba60e3", "AQAAAAEAACcQAAAAEO+baNob1ytYHCLMRFvjKG0hrPQj9CtoPJW6wRNIkNXbuoK1FjA4v1h2XP5nqsIxMA==", "9aea9cd3-acdf-46f1-b843-9934eac8ed01" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1a153ea7-321a-4f30-ab2d-1bafd40d0b76"),
                columns: new[] { "JobTitle", "PhoneNumber" },
                values: new object[] { "Security", "05551112233" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("65470101-88dc-4ff4-ac60-6e9a02035f51"),
                columns: new[] { "JobTitle", "PhoneNumber" },
                values: new object[] { "Cleaning Staff", "05554445566" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TerminationDate",
                table: "Employees",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Employees",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Employees",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "HireDate",
                table: "Employees",
                newName: "StartDate");

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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1a153ea7-321a-4f30-ab2d-1bafd40d0b76"),
                columns: new[] { "Phone", "Position" },
                values: new object[] { "05551112233", "Security" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("65470101-88dc-4ff4-ac60-6e9a02035f51"),
                columns: new[] { "Phone", "Position" },
                values: new object[] { "05554445566", "Cleaning Staff" });
        }
    }
}
