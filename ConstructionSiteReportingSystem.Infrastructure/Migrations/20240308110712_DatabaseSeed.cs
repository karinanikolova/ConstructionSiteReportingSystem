using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSiteReportingSystem.Infrastructure.Migrations
{
    public partial class DatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", 0, "38cc9533-0137-413c-96b8-d687d21fd223", "test@mail.com", false, false, null, "TEST@MAIL.COM", "TEST@MAIL.COM", "AQAAAAEAACcQAAAAEAwt5VAo6/x+HG9NY6jB4msq/jaGhjF/jAzD/nERASTOfuUlX5oVKZhbgjo5m6JFRA==", null, false, "7d9eee49-29f1-4dca-957a-5a5da03e6e00", false, "test@mail.com" },
                    { "a615552b-5981-4730-be32-12c087492aef", 0, "84e2d68a-47d8-4224-a07a-6867f8fe70e8", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEKbZvZktaX5RimrUC1G7EQgSrmf3AsMFJKIf5frWyh0dgbngoOXNbwcMIkL0rPTKAw==", null, false, "f71baa4a-9e4c-4420-badf-730d063d7c32", false, "guest@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "DeletedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "GBS Build" },
                    { 2, null, false, "M Constructions" },
                    { 3, null, false, "Quality Plumbing" },
                    { 4, null, false, "Pavement Systems" },
                    { 5, null, false, "NewSteel LTD" }
                });

            migrationBuilder.InsertData(
                table: "ProjectsSitesNames",
                columns: new[] { "Id", "DeletedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Plant construction for production of electric bicycles MaxCompany" },
                    { 2, null, false, "Construction of streets in Plovdiv Municipality" }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "DeletedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Sitework and foundation" },
                    { 2, null, false, "Rough framing" },
                    { 3, null, false, "Exterior construction" },
                    { 4, null, false, "Mechanical, electrical and plumbing" },
                    { 5, null, false, "Finishes and fixtures" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "DeletedAt", "IsDeleted", "Type" },
                values: new object[,]
                {
                    { 1, null, false, "Ton" },
                    { 2, null, false, "Kilogram" },
                    { 3, null, false, "cu.m" },
                    { 4, null, false, "sq.m" },
                    { 5, null, false, "Meter" },
                    { 6, null, false, "Piece" },
                    { 7, null, false, "Piece/m" },
                    { 8, null, false, "Machine hours" },
                    { 9, null, false, "Man hours" }
                });

            migrationBuilder.InsertData(
                table: "WorksTypes",
                columns: new[] { "Id", "DeletedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "PE400 SN8 pipe installation" },
                    { 2, null, false, "Delivery,laying and compaction of crushed aggregate for road base" },
                    { 3, null, false, "Earthwork excavation" },
                    { 4, null, false, "Delivery, laying and compaction of asphalt concrete binder course" },
                    { 5, null, false, "Delivery, laying and compaction of asphalt concrete surface course" },
                    { 6, null, false, "Delivery and pouring concrete for foundation slab" },
                    { 7, null, false, "Delivery and laying of reinforcement steel for foundation slab" },
                    { 8, null, false, "Large-area formwork for concrete slab" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "DeletedAt", "IsDeleted", "ProjectSiteNameId" },
                values: new object[,]
                {
                    { 1, null, false, 1 },
                    { 2, null, false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "DeletedAt", "FinishDate", "IsDeleted", "ProjectSiteNameId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2027, 3, 8, 13, 7, 12, 270, DateTimeKind.Local).AddTicks(1283), false, 1 },
                    { 2, null, new DateTime(2029, 3, 8, 13, 7, 12, 270, DateTimeKind.Local).AddTicks(1310), false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "DeletedAt", "Description", "IsDeleted", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 8, 13, 7, 12, 361, DateTimeKind.Local).AddTicks(4508), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Must order 5m3 concrete class C20/25 with delivery date next Monday", false, 0, "Order concrete" },
                    { 2, new DateTime(2024, 4, 7, 13, 7, 12, 361, DateTimeKind.Local).AddTicks(4511), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Should start looking through documentation and drawings of upcoming project", false, 0, "New project documentation" },
                    { 3, new DateTime(2024, 3, 3, 13, 7, 12, 361, DateTimeKind.Local).AddTicks(4514), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Go to weekly site Monday meeting", false, 2, "Weekly meeting" },
                    { 4, new DateTime(2024, 3, 8, 13, 7, 12, 361, DateTimeKind.Local).AddTicks(4516), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Fill in monthly workers attendance forms and send them to accounting by the end of month", false, 1, "Monthly workers attendance forms" },
                    { 5, new DateTime(2024, 3, 8, 13, 7, 12, 361, DateTimeKind.Local).AddTicks(4518), "a615552b-5981-4730-be32-12c087492aef", null, "Call engineer supervisor and schedule meeting to discuss construction work progress and difficulties", false, 0, "Schedule meeting" },
                    { 6, new DateTime(2024, 3, 13, 13, 7, 12, 361, DateTimeKind.Local).AddTicks(4521), "a615552b-5981-4730-be32-12c087492aef", null, "Call Doka representative and order more formwork for site", false, 0, "Formwork" }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "CarryOutDate", "ContractorId", "CostPerUnit", "CreatorId", "DeletedAt", "Description", "IsDeleted", "IsIncluded", "Quantity", "StageId", "TotalCost", "UnitId", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 8, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1168), 3, 23m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 897.0, 4, 0m, 5, 1 },
                    { 2, new DateTime(2024, 3, 8, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1172), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 120.0, 1, 0m, 3, 2 },
                    { 3, new DateTime(2024, 3, 9, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1174), 4, 35.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate material and delivery", false, true, 150.0, 1, 0m, 3, 2 },
                    { 4, new DateTime(2024, 3, 9, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1177), 2, 600m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate compaction using 11 ton roller", false, false, 1.0, 1, 0m, 8, 2 },
                    { 5, new DateTime(2024, 3, 10, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1179), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 250.0, 1, 0m, 3, 2 },
                    { 6, new DateTime(2024, 3, 18, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1182), 4, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Used combined excavators", false, true, 150.0, 1, 0m, 3, 3 },
                    { 7, new DateTime(2024, 3, 20, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1184), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 163.0, 1, 0m, 1, 4 },
                    { 8, new DateTime(2024, 3, 21, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1186), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 158.0, 1, 0m, 1, 4 },
                    { 9, new DateTime(2024, 3, 22, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1188), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 75.0, 1, 0m, 1, 4 },
                    { 10, new DateTime(2024, 3, 23, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1192), 4, 152m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 210.0, 1, 0m, 1, 5 },
                    { 11, new DateTime(2024, 3, 13, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1194), 2, 135m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, true, 20.0, 1, 0m, 3, 6 },
                    { 12, new DateTime(2024, 3, 12, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1199), 5, 2.2m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel and delivery", false, true, 57.0, 1, 0m, 2, 7 },
                    { 13, new DateTime(2024, 3, 12, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1202), 1, 0.3m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel laying", false, false, 57.0, 1, 0m, 2, 7 },
                    { 14, new DateTime(2024, 3, 25, 13, 7, 12, 334, DateTimeKind.Local).AddTicks(1204), 1, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for formwork assembly", false, true, 57.0, 2, 0m, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "SitesStages",
                columns: new[] { "SiteId", "StageId", "DeletedAt", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, null, false },
                    { 1, 2, null, false },
                    { 1, 3, null, false },
                    { 1, 4, null, false },
                    { 1, 5, null, false },
                    { 2, 1, null, false },
                    { 2, 2, null, false },
                    { 2, 3, null, false },
                    { 2, 4, null, false },
                    { 2, 5, null, false }
                });

            migrationBuilder.InsertData(
                table: "WorksByProjects",
                columns: new[] { "Id", "DeletedAt", "IsDeleted", "ProjectId", "TotalQuantity", "UnitId", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, null, false, 1, 3543.0, 5, 1 },
                    { 2, null, false, 1, 12056.0, 3, 2 },
                    { 3, null, false, 1, 15327.0, 3, 3 },
                    { 4, null, false, 1, 3024.0, 1, 4 },
                    { 5, null, false, 1, 3024.0, 1, 5 },
                    { 6, null, false, 1, 3000.0, 1, 6 },
                    { 7, null, false, 1, 72000.0, 2, 7 },
                    { 8, null, false, 1, 3600.0, 4, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorksByProjects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef");

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProjectsSitesNames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectsSitesNames",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
