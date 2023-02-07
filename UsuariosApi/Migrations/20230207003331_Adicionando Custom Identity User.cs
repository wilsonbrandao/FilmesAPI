using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "825d35c1-d266-4288-a696-17566d3ace43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "112eb579-6a34-4676-9b10-3556c535171e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38bbfca9-c5db-471c-aa29-38ecc1b3c996", "AQAAAAEAACcQAAAAEFVjaxP7txv9RK13xbzEOoC1YemX4agJp+475mj1IjMmkszITvwcTF8A+D8Q0m8mMw==", "8941e67b-7d4d-4fb8-8552-ddf027d8d6db" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "ebc99f3d-db1a-4ca9-a1bd-caa583b4a3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "324c5cc3-65cc-4d6a-acfd-5c8dca72f004");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f10f9760-9dfe-4b25-b1dd-235707d6c687", "AQAAAAEAACcQAAAAEPyLXtP6/xKst+f2WY6o6BQUOO06nKzBmrYcVv5LGiMSBMFc4hCyDnpAvGautjiLqg==", "64c34528-3dc4-4b5b-b4b2-50b3052d070e" });
        }
    }
}
