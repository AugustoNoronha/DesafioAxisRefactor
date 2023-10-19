using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioAxisRefactor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cooperadorcooperativas8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooperado_cooperativas_CooperativasId",
                table: "Cooperado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cooperado",
                table: "Cooperado");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "cooperativas",
                newName: "cooperativas",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Cooperado",
                newName: "cooperado",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "dbo",
                table: "cooperativas",
                newName: "descripition");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "cooperado",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ContaCorrente",
                schema: "dbo",
                table: "cooperado",
                newName: "account_number");

            migrationBuilder.RenameIndex(
                name: "IX_Cooperado_CooperativasId",
                schema: "dbo",
                table: "cooperado",
                newName: "IX_cooperado_CooperativasId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "cooperativas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "descripition",
                schema: "dbo",
                table: "cooperativas",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "dbo",
                table: "cooperado",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CooperativasId",
                schema: "dbo",
                table: "cooperado",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "cooperado",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "account_number",
                schema: "dbo",
                table: "cooperado",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "cooperativa_id",
                schema: "dbo",
                table: "cooperado",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_cooperado",
                schema: "dbo",
                table: "cooperado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cooperado_cooperativas_CooperativasId",
                schema: "dbo",
                table: "cooperado",
                column: "CooperativasId",
                principalSchema: "dbo",
                principalTable: "cooperativas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cooperado_cooperativas_CooperativasId",
                schema: "dbo",
                table: "cooperado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cooperado",
                schema: "dbo",
                table: "cooperado");

            migrationBuilder.DropColumn(
                name: "cooperativa_id",
                schema: "dbo",
                table: "cooperado");

            migrationBuilder.RenameTable(
                name: "cooperativas",
                schema: "dbo",
                newName: "cooperativas");

            migrationBuilder.RenameTable(
                name: "cooperado",
                schema: "dbo",
                newName: "Cooperado");

            migrationBuilder.RenameColumn(
                name: "descripition",
                table: "cooperativas",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Cooperado",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "account_number",
                table: "Cooperado",
                newName: "ContaCorrente");

            migrationBuilder.RenameIndex(
                name: "IX_cooperado_CooperativasId",
                table: "Cooperado",
                newName: "IX_Cooperado_CooperativasId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "cooperativas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "cooperativas",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cooperado",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<long>(
                name: "CooperativasId",
                table: "Cooperado",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Cooperado",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "ContaCorrente",
                table: "Cooperado",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(12)",
                oldMaxLength: 12);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cooperado",
                table: "Cooperado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperado_cooperativas_CooperativasId",
                table: "Cooperado",
                column: "CooperativasId",
                principalTable: "cooperativas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
