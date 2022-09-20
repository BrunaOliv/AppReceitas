using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReceitas.Infra.Data.Migrations
{
    public partial class addLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Recipes",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fácil" },
                    { 2, "Médio" },
                    { 3, "Deficíl" },
                    { 4, "Mestre cuca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_LevelId",
                table: "Recipes",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Level_LevelId",
                table: "Recipes",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Level_LevelId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_LevelId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Recipes");
        }
    }
}
