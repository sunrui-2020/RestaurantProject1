using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<string>(nullable: false),
                    CustomerFname = table.Column<string>(nullable: false),
                    CustomerLname = table.Column<string>(nullable: false),
                    CustomerSex = table.Column<string>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: true),
                    Customerphone = table.Column<string>(nullable: false),
                    CustomerPwd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
