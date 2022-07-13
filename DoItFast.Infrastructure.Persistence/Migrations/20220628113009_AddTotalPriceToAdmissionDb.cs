using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoItFast.Infrastructure.Persistence.Migrations
{
    public partial class AddTotalPriceToAdmissionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "DoItFast",
                table: "Admission",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "DoItFast",
                table: "Admission");
        }
    }
}
