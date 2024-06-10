using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeDevEvents.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(180)", maxLength: 180, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Data_Inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Data_Final = table.Column<DateTime>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevEventPalestrantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloPalestra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoPalestra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevEventPalestrantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevEventPalestrantes_DevEvents_DevEventId",
                        column: x => x.DevEventId,
                        principalTable: "DevEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevEventPalestrantes_DevEventId",
                table: "DevEventPalestrantes",
                column: "DevEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevEventPalestrantes");

            migrationBuilder.DropTable(
                name: "DevEvents");
        }
    }
}
