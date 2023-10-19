using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favoritos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "cooperado",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "cooperativas",
                schema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "cooperativas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripition = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cooperativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cooperado",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account_number = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    CooperativaId = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cooperado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cooperado_cooperativas_CooperativaId",
                        column: x => x.CooperativaId,
                        principalSchema: "dbo",
                        principalTable: "cooperativas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "favoritos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                name: "IX_cooperado_CooperativaId",
                schema: "dbo",
                table: "cooperado",
                column: "CooperativaId");

            migrationBuilder.CreateIndex(
                name: "IX_favoritos_CooperadoId",
                schema: "dbo",
                table: "favoritos",
                column: "CooperadoId");
        }
    }
}
