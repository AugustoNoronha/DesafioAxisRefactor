using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cooperadorfav4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CooperativasId = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cooperado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cooperado_cooperativas_CooperativasId",
                        column: x => x.CooperativasId,
                        principalSchema: "dbo",
                        principalTable: "cooperativas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cooperado_CooperativasId",
                schema: "dbo",
                table: "cooperado",
                column: "CooperativasId");
        }
    }
}
