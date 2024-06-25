using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fornecedores.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });
            // Popula o banco de dados com registros iniciais
            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Nome", "Email" },
                values: new object[,]
                {
                    { "Fornecedor 1", "fornecedor1@example.com" },
                    { "Fornecedor 2", "fornecedor2@example.com" },
                    { "Fornecedor 3", "fornecedor3@example.com" },
                    { "Fornecedor 4", "fornecedor4@example.com" },
                    { "Fornecedor 5", "fornecedor5@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
