using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSiteReportingSystem.Infrastructure.Migrations
{
    public partial class InitialDatabaseTablesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Construction contractor identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Construction contractor name"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                },
                comment: "Construction contractor");

            migrationBuilder.CreateTable(
                name: "ProjectsSitesNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Investment project/Construction site name identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Investment project/Construction site name"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsSitesNames", x => x.Id);
                },
                comment: "Investment project/Construction site name");

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Construction stage identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Construction stage name"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                },
                comment: "Construction stage");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Task identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Task title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Task description"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Task creation date"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Task creator identifier"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "Task's current status"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User tasks");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Measurement unit identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Measurement unit type"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                },
                comment: "Measurement unit");

            migrationBuilder.CreateTable(
                name: "WorksTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work type identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Construction and assembly work type name"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksTypes", x => x.Id);
                },
                comment: "Construction and assembly work type");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Investment project identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectSiteNameId = table.Column<int>(type: "int", nullable: false, comment: "Investment project/Construction site name identifier"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectsSitesNames_ProjectSiteNameId",
                        column: x => x.ProjectSiteNameId,
                        principalTable: "ProjectsSitesNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Investment project");

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Construction site identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectSiteNameId = table.Column<int>(type: "int", nullable: false, comment: "Investment project/Construction site name identifier"),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Construction site finish date"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_ProjectsSitesNames_ProjectSiteNameId",
                        column: x => x.ProjectSiteNameId,
                        principalTable: "ProjectsSitesNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Construction site");

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work type identifier"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Construction and assembly work description"),
                    CarryOutDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Construction and assembly work carry out date and time"),
                    StageId = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work stage identifier"),
                    ContractorId = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work contractor identifier"),
                    Quantity = table.Column<double>(type: "float", nullable: false, comment: "Construction and assembly work quantity"),
                    UnitId = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work measurement unit identifier"),
                    CostPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Construction and assembly work cost per measurement unit"),
                    TotalCost = table.Column<decimal>(type: "decimal(36,2)", nullable: false, comment: "Construction and assembly work total cost"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Construction and assembly work creator identifier"),
                    IsIncluded = table.Column<bool>(type: "bit", nullable: false, comment: "Boolean value that determines if the current construction and assembly work is included in the total quantity report"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_WorksTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorksTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Construction and assembly work");

            migrationBuilder.CreateTable(
                name: "WorksByProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work according to investment project identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work type identifier according to investment project"),
                    UnitId = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work according to investment project measurement unit identifier"),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false, comment: "Construction and assembly work according to investment project total quantity"),
                    ProjectId = table.Column<int>(type: "int", nullable: false, comment: "Construction and assembly work investment project identifier"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksByProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorksByProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorksByProjects_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorksByProjects_WorksTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorksTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Construction and assembly work according to investment project");

            migrationBuilder.CreateTable(
                name: "SitesStages",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "int", nullable: false, comment: "Construction site identifier"),
                    StageId = table.Column<int>(type: "int", nullable: false, comment: "Construction stage identifier"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitesStages", x => new { x.SiteId, x.StageId });
                    table.ForeignKey(
                        name: "FK_SitesStages_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SitesStages_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Construction site and construction stage mapping table");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectSiteNameId",
                table: "Projects",
                column: "ProjectSiteNameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sites_ProjectSiteNameId",
                table: "Sites",
                column: "ProjectSiteNameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SitesStages_StageId",
                table: "SitesStages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ContractorId",
                table: "Works",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CreatorId",
                table: "Works",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_StageId",
                table: "Works",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_UnitId",
                table: "Works",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_WorkTypeId",
                table: "Works",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksByProjects_ProjectId",
                table: "WorksByProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksByProjects_UnitId",
                table: "WorksByProjects",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksByProjects_WorkTypeId",
                table: "WorksByProjects",
                column: "WorkTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SitesStages");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "WorksByProjects");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "WorksTypes");

            migrationBuilder.DropTable(
                name: "ProjectsSitesNames");
        }
    }
}
