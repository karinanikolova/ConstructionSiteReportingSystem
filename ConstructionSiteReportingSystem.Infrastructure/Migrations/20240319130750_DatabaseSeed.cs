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
                    { "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", 0, "8bf7f41d-db18-4cd9-ae4e-df30088265ae", "test@mail.com", false, false, null, "TEST@MAIL.COM", "TEST@MAIL.COM", "AQAAAAEAACcQAAAAEGaBJe7vVRbwioFY/aVj3kSOkHFdypTu6izfNq63al5AQXwrvkgZna9QdH/6UhK3Jg==", null, false, "408ca107-dbd0-4435-956e-4e97b2d1e76e", false, "test@mail.com" },
                    { "a615552b-5981-4730-be32-12c087492aef", 0, "af7a0db4-efcb-463a-b993-7b29fe87cb5e", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEIGQK+mkxT7qWGrc4SWNoAfxHs2gummbaTsKUJqqwMkEhM3o1jY1f7HGSZbDbuO5rg==", null, false, "660a4215-3e6d-4ecd-94ec-c82d7d44bf31", false, "guest@mail.com" }
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
                table: "Sites",
                columns: new[] { "Id", "DeletedAt", "FinishDate", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2027, 3, 19, 15, 7, 50, 83, DateTimeKind.Local).AddTicks(1370), "https://images.pexels.com/photos/220885/pexels-photo-220885.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for production of electric bicycles MaxCompany" },
                    { 2, null, new DateTime(2029, 3, 19, 15, 7, 50, 83, DateTimeKind.Local).AddTicks(1393), "https://images.pexels.com/photos/2833686/pexels-photo-2833686.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Construction of streets in Plovdiv Municipality" },
                    { 3, null, new DateTime(2026, 3, 19, 15, 7, 50, 83, DateTimeKind.Local).AddTicks(1396), "https://images.pexels.com/photos/236698/pexels-photo-236698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for cardboard packaging GreenPac" }
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
                    { 1, null, false, "ton" },
                    { 2, null, false, "kg" },
                    { 3, null, false, "cu.m" },
                    { 4, null, false, "sq.m" },
                    { 5, null, false, "m" },
                    { 6, null, false, "piece" },
                    { 7, null, false, "piece/m" },
                    { 8, null, false, "machine hours" },
                    { 9, null, false, "man hours" }
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
                    { 2, 5, null, false },
                    { 3, 1, null, false },
                    { 3, 2, null, false },
                    { 3, 3, null, false },
                    { 3, 4, null, false },
                    { 3, 5, null, false }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "DeletedAt", "Description", "IsDeleted", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 19, 15, 7, 50, 159, DateTimeKind.Local).AddTicks(6548), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Must order 5m3 concrete class C20/25 with delivery date next Monday", false, 0, "Order concrete" },
                    { 2, new DateTime(2024, 4, 18, 15, 7, 50, 159, DateTimeKind.Local).AddTicks(6550), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Should start looking through documentation and drawings of upcoming project", false, 0, "New project documentation" },
                    { 3, new DateTime(2024, 3, 14, 15, 7, 50, 159, DateTimeKind.Local).AddTicks(6553), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Go to weekly site Monday meeting", false, 2, "Weekly meeting" },
                    { 4, new DateTime(2024, 3, 19, 15, 7, 50, 159, DateTimeKind.Local).AddTicks(6555), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Fill in monthly workers attendance forms and send them to accounting by the end of month", false, 1, "Monthly workers attendance forms" },
                    { 5, new DateTime(2024, 3, 19, 15, 7, 50, 159, DateTimeKind.Local).AddTicks(6557), "a615552b-5981-4730-be32-12c087492aef", null, "Call engineer supervisor and schedule meeting to discuss construction work progress and difficulties", false, 0, "Schedule meeting" },
                    { 6, new DateTime(2024, 3, 24, 15, 7, 50, 159, DateTimeKind.Local).AddTicks(6559), "a615552b-5981-4730-be32-12c087492aef", null, "Call Doka representative and order more formwork for site", false, 0, "Formwork" }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "CarryOutDate", "ContractorId", "CostPerUnit", "CreatorId", "DeletedAt", "Description", "IsDeleted", "Quantity", "StageId", "TotalCost", "UnitId", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 19, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(550), 3, 23m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 897.0, 4, 20631m, 5, 1 },
                    { 2, new DateTime(2024, 3, 19, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(557), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 120.0, 1, 5100m, 3, 2 },
                    { 3, new DateTime(2024, 3, 20, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(560), 4, 35.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate material and delivery", false, 150.0, 1, 5325m, 3, 2 },
                    { 4, new DateTime(2024, 3, 20, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(563), 2, 600m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate compaction using 11 ton roller", false, 1.0, 1, 600m, 8, 2 },
                    { 5, new DateTime(2024, 3, 21, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(565), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 250.0, 1, 10625m, 3, 2 },
                    { 6, new DateTime(2024, 3, 29, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(569), 4, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Used combined excavators", false, 150.0, 1, 1200m, 3, 3 },
                    { 7, new DateTime(2024, 3, 31, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(571), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 163.0, 1, 26732m, 1, 4 },
                    { 8, new DateTime(2024, 4, 1, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(574), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 158.0, 1, 25912m, 1, 4 },
                    { 9, new DateTime(2024, 4, 2, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(576), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 75.0, 1, 12300m, 1, 4 },
                    { 10, new DateTime(2024, 4, 3, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(579), 4, 152m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 210.0, 1, 31920m, 1, 5 },
                    { 11, new DateTime(2024, 3, 24, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(581), 2, 135m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, 20.0, 1, 2700m, 3, 6 },
                    { 12, new DateTime(2024, 3, 23, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(584), 5, 2.2m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel and delivery", false, 57.0, 1, 125.4m, 2, 7 },
                    { 13, new DateTime(2024, 3, 23, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(587), 1, 0.3m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel laying", false, 57.0, 1, 17.1m, 2, 7 },
                    { 14, new DateTime(2024, 4, 5, 15, 7, 50, 147, DateTimeKind.Local).AddTicks(590), 1, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for formwork assembly", false, 57.0, 2, 456m, 4, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "SitesStages",
                keyColumns: new[] { "SiteId", "StageId" },
                keyValues: new object[] { 3, 5 });

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
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
