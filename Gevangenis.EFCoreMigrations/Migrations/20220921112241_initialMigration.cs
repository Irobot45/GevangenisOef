using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gevangenis.EFCoreMigrations.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prisons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    AmountPrisoners = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsIsolationCell = table.Column<bool>(type: "bit", nullable: false),
                    PrisonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cells_Prisons_PrisonId",
                        column: x => x.PrisonId,
                        principalTable: "Prisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prisoners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterPrisonDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTimeSentence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavePrisonDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrisonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CellId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrisonerType = table.Column<int>(type: "prisonerType", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisoners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prisoners_Cells_CellId",
                        column: x => x.CellId,
                        principalTable: "Cells",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prisoners_Prisons_PrisonId",
                        column: x => x.PrisonId,
                        principalTable: "Prisons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cells_PrisonId",
                table: "Cells",
                column: "PrisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisoners_CellId",
                table: "Prisoners",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisoners_PrisonId",
                table: "Prisoners",
                column: "PrisonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prisoners");

            migrationBuilder.DropTable(
                name: "Cells");

            migrationBuilder.DropTable(
                name: "Prisons");
        }
    }
}
