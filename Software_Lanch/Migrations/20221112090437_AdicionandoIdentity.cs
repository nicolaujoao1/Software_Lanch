using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Lanch.Migrations
{
    public partial class AdicionandoIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCarrinhoCompraItem_tbLanche_LanchId",
                table: "tbCarrinhoCompraItem");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLanche_tbCategoria_CategoriaId",
                table: "tbLanche");

            migrationBuilder.DropForeignKey(
                name: "FK_tbPedidoDetalhe_tbLanche_LancheId",
                table: "tbPedidoDetalhe");

            migrationBuilder.DropForeignKey(
                name: "FK_tbPedidoDetalhe_tbPedido_PedidoId",
                table: "tbPedidoDetalhe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbPedidoDetalhe",
                table: "tbPedidoDetalhe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbPedido",
                table: "tbPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbLanche",
                table: "tbLanche");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbCategoria",
                table: "tbCategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbCarrinhoCompraItem",
                table: "tbCarrinhoCompraItem");

            migrationBuilder.RenameTable(
                name: "tbPedidoDetalhe",
                newName: "PedidoDetalhes");

            migrationBuilder.RenameTable(
                name: "tbPedido",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "tbLanche",
                newName: "Lanchs");

            migrationBuilder.RenameTable(
                name: "tbCategoria",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "tbCarrinhoCompraItem",
                newName: "CarrinhoCompraItens");

            migrationBuilder.RenameIndex(
                name: "IX_tbPedidoDetalhe_PedidoId",
                table: "PedidoDetalhes",
                newName: "IX_PedidoDetalhes_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbPedidoDetalhe_LancheId",
                table: "PedidoDetalhes",
                newName: "IX_PedidoDetalhes_LancheId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLanche_CategoriaId",
                table: "Lanchs",
                newName: "IX_Lanchs_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_tbCarrinhoCompraItem_LanchId",
                table: "CarrinhoCompraItens",
                newName: "IX_CarrinhoCompraItens_LanchId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Lanchs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Lanchs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Lanchs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoCurta",
                table: "Lanchs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNome",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoDetalhes",
                table: "PedidoDetalhes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lanchs",
                table: "Lanchs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCompraItens",
                table: "CarrinhoCompraItens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Lanchs_LanchId",
                table: "CarrinhoCompraItens",
                column: "LanchId",
                principalTable: "Lanchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lanchs_Categorias_CategoriaId",
                table: "Lanchs",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhes_Lanchs_LancheId",
                table: "PedidoDetalhes",
                column: "LancheId",
                principalTable: "Lanchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhes_Pedidos_PedidoId",
                table: "PedidoDetalhes",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Lanchs_LanchId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Lanchs_Categorias_CategoriaId",
                table: "Lanchs");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhes_Lanchs_LancheId",
                table: "PedidoDetalhes");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhes_Pedidos_PedidoId",
                table: "PedidoDetalhes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoDetalhes",
                table: "PedidoDetalhes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lanchs",
                table: "Lanchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCompraItens",
                table: "CarrinhoCompraItens");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "tbPedido");

            migrationBuilder.RenameTable(
                name: "PedidoDetalhes",
                newName: "tbPedidoDetalhe");

            migrationBuilder.RenameTable(
                name: "Lanchs",
                newName: "tbLanche");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "tbCategoria");

            migrationBuilder.RenameTable(
                name: "CarrinhoCompraItens",
                newName: "tbCarrinhoCompraItem");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalhes_PedidoId",
                table: "tbPedidoDetalhe",
                newName: "IX_tbPedidoDetalhe_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalhes_LancheId",
                table: "tbPedidoDetalhe",
                newName: "IX_tbPedidoDetalhe_LancheId");

            migrationBuilder.RenameIndex(
                name: "IX_Lanchs_CategoriaId",
                table: "tbLanche",
                newName: "IX_tbLanche_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCompraItens_LanchId",
                table: "tbCarrinhoCompraItem",
                newName: "IX_tbCarrinhoCompraItem_LanchId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "tbLanche",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tbLanche",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "tbLanche",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoCurta",
                table: "tbLanche",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "tbCategoria",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNome",
                table: "tbCategoria",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbPedido",
                table: "tbPedido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbPedidoDetalhe",
                table: "tbPedidoDetalhe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbLanche",
                table: "tbLanche",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbCategoria",
                table: "tbCategoria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbCarrinhoCompraItem",
                table: "tbCarrinhoCompraItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCarrinhoCompraItem_tbLanche_LanchId",
                table: "tbCarrinhoCompraItem",
                column: "LanchId",
                principalTable: "tbLanche",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLanche_tbCategoria_CategoriaId",
                table: "tbLanche",
                column: "CategoriaId",
                principalTable: "tbCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbPedidoDetalhe_tbLanche_LancheId",
                table: "tbPedidoDetalhe",
                column: "LancheId",
                principalTable: "tbLanche",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbPedidoDetalhe_tbPedido_PedidoId",
                table: "tbPedidoDetalhe",
                column: "PedidoId",
                principalTable: "tbPedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
