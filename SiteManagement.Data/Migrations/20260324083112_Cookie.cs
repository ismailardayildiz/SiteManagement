using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagement.Data.Migrations
{
    public partial class Cookie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("066247ba-ca2c-4554-9311-bd96d8658923"),
                column: "ConcurrencyStamp",
                value: "11988a2a-1908-4a35-8ea0-7f973e3ccfd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("44a9b0b3-9df5-4b85-83ac-608abfe46207"),
                column: "ConcurrencyStamp",
                value: "1466cd6f-bbf0-4398-b35c-e5b1cc9dd215");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("45f843cb-d1e5-4a6b-afa3-3ab105d3b159"),
                column: "ConcurrencyStamp",
                value: "cb82aa17-0fd4-469e-94ce-c2a51036dc96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("813c1780-e84a-4992-9676-2da6e6bb38df"),
                column: "ConcurrencyStamp",
                value: "bf235a98-2cca-4f55-a07e-20a6a5f8dd2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8407beb3-e2b8-483d-b7c5-f159327aa74b"),
                column: "ConcurrencyStamp",
                value: "fcff8cd1-7d46-4c75-8f56-48115fb2c0a9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44010978-e210-4db8-81e9-6f191695953b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1115759e-e25e-4d1c-aa5a-cf1278c224b4", "AQAAAAEAACcQAAAAEOYVTU9ancQKAX0aZxXqzwi5OGIZ3XEwiaYjXDW/ZcvhRvEMOJsFlKLJzR6wDvrrPA==", "a479fdbe-4388-4ad8-90b5-5b5b9f23dccb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("589da78a-0fd1-4fdf-bdde-4bf626b0b2df"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfb5d3b9-b6a3-4a44-8164-0df6049b89bb", "AQAAAAEAACcQAAAAECrlvYoWSjtzyx4XdjPUzed25zy7YDK1TxUP7Q5MxIyzCp/ADo0A1GNNA0Gfcp7BPQ==", "d76d6bcd-954d-4d11-80eb-3d9ee9d65d06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6b6ce5a-93ac-44d1-936b-ed80b6f9b04f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9c12ade-6ae0-4c6e-805f-ca6219cb14aa", "AQAAAAEAACcQAAAAEOMOC85vP3wwCToVpHLBNbgxClAuIOlM2vbG9qe5MVpL4t4W1qIwPwIpoGVdmYvm+w==", "e2d8195a-a4d0-4b53-8eaf-78e39b56bdbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700c399b-c34f-43f1-a6a1-0248dbe6c11d", "AQAAAAEAACcQAAAAEMUsqZeNdr7v8z9F+SuSi3z6ksXb0yHziktneiW0Mw5hE7yyKN+rx8PCu28MqPxd9Q==", "463c7b08-4288-4629-809a-2a109cb39726" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5e6d88e-7ef1-42ff-9810-20fde393bfce", "AQAAAAEAACcQAAAAEBrq/Y3IkPGLOxO8962rIzuBhCSRS2D8jaNacKqSxmJaV3EmClRbTl4yHl0mOMNKnw==", "7bbeca26-be39-45e2-baa0-765986486231" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09afc03b-6c71-4eeb-9608-f3d2af6d0bd2", "AQAAAAEAACcQAAAAEJvQpiuE6Jwp9OvVRo3zoYevVsqlHPrnF50eK7kPWKbiVjy0XrGd72WELBs9Yiit+A==", "0eff50de-5620-43af-8fd3-36d7f9271f74" });
        }
    }
}
