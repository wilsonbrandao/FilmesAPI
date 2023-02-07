using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "324c5cc3-65cc-4d6a-acfd-5c8dca72f004");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "ebc99f3d-db1a-4ca9-a1bd-caa583b4a3c5", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f10f9760-9dfe-4b25-b1dd-235707d6c687", "AQAAAAEAACcQAAAAEPyLXtP6/xKst+f2WY6o6BQUOO06nKzBmrYcVv5LGiMSBMFc4hCyDnpAvGautjiLqg==", "64c34528-3dc4-4b5b-b4b2-50b3052d070e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a6c9a736-bac4-4431-bcab-e5b5403a2604");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8354adcf-e91d-49e9-82c5-16659f932416", "AQAAAAEAACcQAAAAEJX4l3Xx6bIdHSbgSqJpFRiix0Ihd78vEPnNpQBQfJuek9PHnfP8q1oHtmll/r9vow==", "ad4a5854-6ea0-41ee-8297-d5b9360a3c68" });
        }
    }
}
