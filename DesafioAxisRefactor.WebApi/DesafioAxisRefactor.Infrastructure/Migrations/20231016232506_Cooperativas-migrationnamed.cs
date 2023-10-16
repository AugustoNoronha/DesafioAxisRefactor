using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cooperativasmigrationnamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cooperativas",
                table: "Cooperativas");

            migrationBuilder.RenameTable(
                name: "Cooperativas",
                newName: "cooperativas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cooperativas",
                table: "cooperativas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cooperativas",
                table: "cooperativas");

            migrationBuilder.RenameTable(
                name: "cooperativas",
                newName: "Cooperativas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cooperativas",
                table: "Cooperativas",
                column: "Id");
        }
    }
}
