using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cooperadorcooperativas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "cooperativas",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 80);

            migrationBuilder.CreateTable(
                name: "Cooperado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContaCorrente = table.Column<string>(type: "text", nullable: false),
                    CooperativaId = table.Column<int>(type: "integer", nullable: false),
                    CooperativasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooperado_cooperativas_CooperativasId",
                        column: x => x.CooperativasId,
                        principalTable: "cooperativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooperado_CooperativasId",
                table: "Cooperado",
                column: "CooperativasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cooperado");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "cooperativas",
                type: "VARCHAR",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
