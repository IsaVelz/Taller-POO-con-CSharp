using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carne",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Credito",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Credito = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Clientes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Carne = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Vendedores_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.AddColumn<int>(
                name: "Carne",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Credito",
                table: "Personas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }
    }
}
