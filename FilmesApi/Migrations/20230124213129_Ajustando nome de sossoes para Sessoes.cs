using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesApi.Migrations
{
    public partial class AjustandonomedesossoesparaSessoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sossoes_Cinemas_CinemaId",
                table: "Sossoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sossoes_Filmes_FilmeId",
                table: "Sossoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sossoes",
                table: "Sossoes");

            migrationBuilder.RenameTable(
                name: "Sossoes",
                newName: "Sessoes");

            migrationBuilder.RenameIndex(
                name: "IX_Sossoes_FilmeId",
                table: "Sessoes",
                newName: "IX_Sessoes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sossoes_CinemaId",
                table: "Sessoes",
                newName: "IX_Sessoes_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.RenameTable(
                name: "Sessoes",
                newName: "Sossoes");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_FilmeId",
                table: "Sossoes",
                newName: "IX_Sossoes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_CinemaId",
                table: "Sossoes",
                newName: "IX_Sossoes_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sossoes",
                table: "Sossoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sossoes_Cinemas_CinemaId",
                table: "Sossoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sossoes_Filmes_FilmeId",
                table: "Sossoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
