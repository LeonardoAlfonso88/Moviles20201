using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiNet.Migrations
{
    public partial class OctavaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estadosPedidos",
                columns: table => new
                {
                    IdEstadoPedido = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadosPedidos", x => x.IdEstadoPedido);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorTotal = table.Column<double>(nullable: false),
                    AhorroTotal = table.Column<double>(nullable: false),
                    IdEstadoPedido = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_pedidos_estadosPedidos_IdEstadoPedido",
                        column: x => x.IdEstadoPedido,
                        principalTable: "estadosPedidos",
                        principalColumn: "IdEstadoPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_IdEstadoPedido",
                table: "pedidos",
                column: "IdEstadoPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "estadosPedidos");
        }
    }
}
