using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSiteReportingSystem.Infrastructure.Migrations
{
    public partial class ImageUrlColumnToProjectSiteNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProjectsSitesNames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Investment project/Construction site image URL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProjectsSitesNames");
        }
    }
}
