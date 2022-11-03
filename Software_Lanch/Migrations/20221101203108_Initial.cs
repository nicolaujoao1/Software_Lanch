using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Lanch.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbLanche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DescricaoDetalhada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ImagemThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLanchPreferido = table.Column<bool>(type: "bit", nullable: false),
                    EmEstoque = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLanche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbLanche_tbCategoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbLanche_CategoriaId",
                table: "tbLanche",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbLanche");

            migrationBuilder.DropTable(
                name: "tbCategoria");
        }
    }
}
