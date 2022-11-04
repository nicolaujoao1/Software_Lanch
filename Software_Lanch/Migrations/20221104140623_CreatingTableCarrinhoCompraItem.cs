using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Lanch.Migrations
{
    public partial class CreatingTableCarrinhoCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCarrinhoCompraItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanchId = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoCompraId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCarrinhoCompraItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbCarrinhoCompraItem_tbLanche_LanchId",
                        column: x => x.LanchId,
                        principalTable: "tbLanche",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCarrinhoCompraItem_LanchId",
                table: "tbCarrinhoCompraItem",
                column: "LanchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCarrinhoCompraItem");
        }
    }
}
