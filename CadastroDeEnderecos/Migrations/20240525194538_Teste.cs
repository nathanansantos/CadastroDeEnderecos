using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeEnderecos.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_UsuarioModel_UsuarioId",
                table: "Enderecos");

            migrationBuilder.DropTable(
                name: "UsuarioModel");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Enderecos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsuarioModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_UsuarioModel_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId",
                principalTable: "UsuarioModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
