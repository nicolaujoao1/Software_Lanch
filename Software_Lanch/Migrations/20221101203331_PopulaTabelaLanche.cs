using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Lanch.Migrations
{
    public partial class PopulaTabelaLanche : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbLanche VALUES('Cheese Salada','Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito;', 12.50,'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 0 ,1,1)");
            migrationBuilder.Sql("INSERT INTO tbLanche VALUES('Misto Quente','Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto ', 8.00,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0,1,1)");
            migrationBuilder.Sql("INSERT INTO tbLanche VALUES('Cheese Burger','Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação ', 11.00,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0,0,1)");
            migrationBuilder.Sql("INSERT INTO tbLanche VALUES('Lanche Natural Peito Peru', 'queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco.',15.00,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',1,1,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM tbLanche");
        }
    }
}
