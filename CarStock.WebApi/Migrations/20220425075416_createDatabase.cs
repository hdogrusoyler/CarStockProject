using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStock.WebApi.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plaka = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MotorNo",
                table: "Cars",
                column: "MotorNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Plaka",
                table: "Cars",
                column: "Plaka",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
