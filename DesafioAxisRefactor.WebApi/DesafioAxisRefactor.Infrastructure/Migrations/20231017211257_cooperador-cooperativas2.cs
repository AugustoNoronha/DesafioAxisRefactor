using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cooperadorcooperativas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CooperativaId",
                table: "Cooperado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CooperativaId",
                table: "Cooperado",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
