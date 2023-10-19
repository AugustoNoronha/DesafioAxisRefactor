using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class noovo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favoritos",
                schema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "favoritos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CooperadoId = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    pix_key = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    pix_type = table.Column<int>(type: "integer", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_favoritos_cooperado_CooperadoId",
                        column: x => x.CooperadoId,
                        principalSchema: "dbo",
                        principalTable: "cooperado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_favoritos_CooperadoId",
                schema: "dbo",
                table: "favoritos",
                column: "CooperadoId");
        }
    }
}
