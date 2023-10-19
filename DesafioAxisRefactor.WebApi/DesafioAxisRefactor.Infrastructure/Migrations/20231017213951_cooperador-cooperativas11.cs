using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cooperadorcooperativas11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cooperativa_id",
                schema: "dbo",
                table: "cooperado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cooperativa_id",
                schema: "dbo",
                table: "cooperado",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
