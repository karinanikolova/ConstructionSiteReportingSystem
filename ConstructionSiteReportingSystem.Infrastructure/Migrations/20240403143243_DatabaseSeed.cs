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
                    { "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", 0, "92dd796a-9c62-41b2-8076-f7462c6d9990", "test@mail.com", false, false, null, "TEST@MAIL.COM", "TEST@MAIL.COM", "AQAAAAEAACcQAAAAECjwJ//Tzqv4NyTTa1Yx5/pRTfL4KqPDhNNGiwJM6qJY7qhkvUojqZu/SOBIp/WUsg==", null, false, "81bcdb6c-d71e-414e-85ea-d694e16b972b", false, "test@mail.com" },
                    { "a615552b-5981-4730-be32-12c087492aef", 0, "00afc460-8404-457d-80bc-6333e7719a93", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEDvut/StLb+YpadbHrfn3zua7pMWFSsfRveLWtbYFLhmo4mmAKXN/lD/dkaL4e6ylA==", null, false, "0b7c1a2c-7000-4364-9e08-16bd63e74b09", false, "guest@mail.com" }
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
                    { 1, null, new DateTime(2027, 4, 3, 17, 32, 42, 994, DateTimeKind.Local).AddTicks(8055), "https://images.pexels.com/photos/220885/pexels-photo-220885.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for production of electric bicycles MaxCompany" },
                    { 2, null, new DateTime(2029, 4, 3, 17, 32, 42, 994, DateTimeKind.Local).AddTicks(8076), "https://images.pexels.com/photos/2833686/pexels-photo-2833686.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Construction of streets in Plovdiv Municipality" },
                    { 3, null, new DateTime(2026, 4, 3, 17, 32, 42, 994, DateTimeKind.Local).AddTicks(8079), "https://images.pexels.com/photos/236698/pexels-photo-236698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for cardboard packaging GreenPac" }
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
                    { 8, null, false, "machine shift" },
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
                    { 1, new DateTime(2024, 4, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1246), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Must order 5m3 concrete class C20/25 with delivery date next Monday", false, 0, "Order concrete" },
                    { 2, new DateTime(2024, 5, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1249), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Should start looking through documentation and drawings of upcoming project", false, 0, "New project documentation" },
                    { 3, new DateTime(2024, 3, 29, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1252), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Go to weekly site Monday meeting", false, 2, "Weekly meeting" },
                    { 4, new DateTime(2024, 4, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1255), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Fill in monthly workers attendance forms and send them to accounting by the end of month", false, 1, "Monthly workers attendance forms" },
                    { 5, new DateTime(2024, 4, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1257), "a615552b-5981-4730-be32-12c087492aef", null, "Call engineer supervisor and schedule meeting to discuss construction work progress and difficulties", false, 0, "Schedule meeting" },
                    { 6, new DateTime(2024, 4, 8, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1260), "a615552b-5981-4730-be32-12c087492aef", null, "Call Doka representative and order more formwork for site", false, 0, "Formwork" }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "CarryOutDate", "ContractorId", "CostPerUnit", "CreatorId", "DeletedAt", "Description", "IsDeleted", "Quantity", "SiteId", "StageId", "TotalCost", "UnitId", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5658), 3, 23m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 897.0, 1, 4, 20631m, 5, 1 },
                    { 2, new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5663), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 120.0, 1, 1, 5100m, 3, 2 },
                    { 3, new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5667), 4, 35.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate material and delivery", false, 150.0, 1, 1, 5325m, 3, 2 },
                    { 4, new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5672), 2, 600m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate compaction using 11 ton roller", false, 1.0, 1, 1, 600m, 8, 2 },
                    { 5, new DateTime(2024, 4, 1, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5675), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 250.0, 1, 1, 10625m, 3, 2 },
                    { 6, new DateTime(2024, 3, 24, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5679), 4, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Used combined excavators", false, 150.0, 1, 1, 1200m, 3, 3 },
                    { 7, new DateTime(2024, 3, 22, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5682), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 163.0, 1, 1, 26732m, 1, 4 },
                    { 8, new DateTime(2024, 3, 21, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5686), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 158.0, 1, 1, 25912m, 1, 4 },
                    { 9, new DateTime(2024, 3, 20, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5689), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 75.0, 1, 1, 12300m, 1, 4 },
                    { 10, new DateTime(2024, 3, 19, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5694), 4, 152m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 210.0, 1, 1, 31920m, 1, 5 },
                    { 11, new DateTime(2024, 3, 29, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5697), 2, 135m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, 20.0, 1, 1, 2700m, 3, 6 },
                    { 12, new DateTime(2024, 3, 30, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5700), 5, 2.2m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel and delivery", false, 57.0, 1, 1, 125.4m, 2, 7 },
                    { 13, new DateTime(2024, 3, 30, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5703), 1, 0.3m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel laying", false, 57.0, 1, 1, 17.1m, 2, 7 },
                    { 14, new DateTime(2024, 3, 17, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5756), 1, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for formwork assembly", false, 57.0, 1, 2, 456m, 4, 8 },
                    { 15, new DateTime(2024, 3, 29, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5760), 4, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Used combined excavators", false, 200.0, 2, 1, 1600m, 3, 3 },
                    { 16, new DateTime(2024, 3, 30, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5763), 4, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 100.0, 2, 1, 800m, 3, 3 },
                    { 17, new DateTime(2024, 3, 31, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5767), 2, 450m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for combined excavator use", false, 2.0, 2, 1, 900m, 8, 3 },
                    { 18, new DateTime(2024, 4, 1, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5771), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 130.0, 2, 1, 21320m, 1, 4 },
                    { 19, new DateTime(2024, 4, 4, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5775), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, 250.0, 2, 1, 41000m, 1, 4 },
                    { 20, new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5778), 3, 23m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, 950.0, 3, 4, 21850m, 5, 1 },
                    { 21, new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5781), 3, 23m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, 350.0, 3, 4, 8050m, 5, 1 },
                    { 22, new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5784), 4, 42.5m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, 200.0, 3, 1, 8500m, 3, 2 },
                    { 23, new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5788), 4, 42.5m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, 390.0, 3, 1, 16575m, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Works",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 23);

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
