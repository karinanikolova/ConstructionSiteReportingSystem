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
                    { "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", 0, "05202de6-33f5-4f8f-b89e-c26318572c3d", "test@mail.com", false, false, null, "TEST@MAIL.COM", "TEST@MAIL.COM", "AQAAAAEAACcQAAAAEN79zn9xMOCrS6kT3CwEupiRwM/Hgy3LZPQ0JoRkcaq+8tmawK3L//gsVLkB1mzcUw==", null, false, "cdbc8c96-7449-42c0-9cfb-188c98a4de32", false, "test@mail.com" },
                    { "a615552b-5981-4730-be32-12c087492aef", 0, "843e239e-8492-427a-97e7-d239950e5953", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEHXybsxtUXKCtrxA40nW+DcdSiktKJCIcNfcEY5Nl+CD8B3xfhQ7JY/EqbnuBUZimQ==", null, false, "5a2c28de-145a-4e2e-b134-c3d17bf0b5b8", false, "guest@mail.com" }
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
                    { 1, null, new DateTime(2027, 3, 27, 12, 23, 5, 661, DateTimeKind.Local).AddTicks(6418), "https://images.pexels.com/photos/220885/pexels-photo-220885.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for production of electric bicycles MaxCompany" },
                    { 2, null, new DateTime(2029, 3, 27, 12, 23, 5, 661, DateTimeKind.Local).AddTicks(6435), "https://images.pexels.com/photos/2833686/pexels-photo-2833686.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Construction of streets in Plovdiv Municipality" },
                    { 3, null, new DateTime(2026, 3, 27, 12, 23, 5, 661, DateTimeKind.Local).AddTicks(6545), "https://images.pexels.com/photos/236698/pexels-photo-236698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for cardboard packaging GreenPac" }
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
                table: "Tasks",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "DeletedAt", "Description", "IsDeleted", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 12, 23, 5, 740, DateTimeKind.Local).AddTicks(585), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Must order 5m3 concrete class C20/25 with delivery date next Monday", false, 0, "Order concrete" },
                    { 2, new DateTime(2024, 4, 26, 12, 23, 5, 740, DateTimeKind.Local).AddTicks(668), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Should start looking through documentation and drawings of upcoming project", false, 0, "New project documentation" },
                    { 3, new DateTime(2024, 3, 22, 12, 23, 5, 740, DateTimeKind.Local).AddTicks(671), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Go to weekly site Monday meeting", false, 2, "Weekly meeting" },
                    { 4, new DateTime(2024, 3, 27, 12, 23, 5, 740, DateTimeKind.Local).AddTicks(673), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Fill in monthly workers attendance forms and send them to accounting by the end of month", false, 1, "Monthly workers attendance forms" },
                    { 5, new DateTime(2024, 3, 27, 12, 23, 5, 740, DateTimeKind.Local).AddTicks(675), "a615552b-5981-4730-be32-12c087492aef", null, "Call engineer supervisor and schedule meeting to discuss construction work progress and difficulties", false, 0, "Schedule meeting" },
                    { 6, new DateTime(2024, 4, 1, 12, 23, 5, 740, DateTimeKind.Local).AddTicks(678), "a615552b-5981-4730-be32-12c087492aef", null, "Call Doka representative and order more formwork for site", false, 0, "Formwork" }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "CarryOutDate", "ContractorId", "CostPerUnit", "CreatorId", "DeletedAt", "Description", "IsDeleted", "Quantity", "StageId", "TotalCost", "UnitId", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6467), 3, 23m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 897.0, 4, 20631m, 5, 1 },
                    { 2, new DateTime(2024, 3, 27, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6487), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 120.0, 1, 5100m, 3, 2 },
                    { 3, new DateTime(2024, 3, 28, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6491), 4, 35.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate material and delivery", false, 150.0, 1, 5325m, 3, 2 },
                    { 4, new DateTime(2024, 3, 28, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6551), 2, 600m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate compaction using 11 ton roller", false, 1.0, 1, 600m, 8, 2 },
                    { 5, new DateTime(2024, 3, 29, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6554), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 250.0, 1, 10625m, 3, 2 },
                    { 6, new DateTime(2024, 4, 6, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6559), 4, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Used combined excavators", false, 150.0, 1, 1200m, 3, 3 },
                    { 7, new DateTime(2024, 4, 8, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6566), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 163.0, 1, 26732m, 1, 4 },
                    { 8, new DateTime(2024, 4, 9, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6569), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 158.0, 1, 25912m, 1, 4 },
                    { 9, new DateTime(2024, 4, 10, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6689), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 75.0, 1, 12300m, 1, 4 },
                    { 10, new DateTime(2024, 4, 11, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6694), 4, 152m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 210.0, 1, 31920m, 1, 5 },
                    { 11, new DateTime(2024, 4, 1, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6700), 2, 135m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, 20.0, 1, 2700m, 3, 6 },
                    { 12, new DateTime(2024, 3, 31, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6703), 5, 2.2m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel and delivery", false, 57.0, 1, 125.4m, 2, 7 },
                    { 13, new DateTime(2024, 3, 31, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6706), 1, 0.3m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel laying", false, 57.0, 1, 17.1m, 2, 7 },
                    { 14, new DateTime(2024, 4, 13, 12, 23, 5, 727, DateTimeKind.Local).AddTicks(6708), 1, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for formwork assembly", false, 57.0, 2, 456m, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "SitesWorks",
                columns: new[] { "SiteId", "WorkId", "DeletedAt", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, null, false },
                    { 1, 2, null, false },
                    { 1, 3, null, false },
                    { 1, 4, null, false },
                    { 1, 5, null, false },
                    { 1, 6, null, false },
                    { 1, 7, null, false },
                    { 1, 8, null, false },
                    { 1, 9, null, false },
                    { 1, 10, null, false },
                    { 1, 11, null, false },
                    { 1, 12, null, false },
                    { 1, 13, null, false },
                    { 1, 14, null, false },
                    { 2, 1, null, false },
                    { 2, 2, null, false },
                    { 2, 3, null, false },
                    { 3, 12, null, false },
                    { 3, 13, null, false },
                    { 3, 14, null, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "SitesWorks",
                keyColumns: new[] { "SiteId", "WorkId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 5);

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
                keyValue: 4);

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
