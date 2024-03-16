﻿using System;
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
                    { "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", 0, "324fdb42-5876-4830-8d7b-2c5d619f0dd0", "test@mail.com", false, false, null, "TEST@MAIL.COM", "TEST@MAIL.COM", "AQAAAAEAACcQAAAAEDg+aU7I9+eX6A4FCtGmP2uMOKXxXWI1JVkutF7G4LiKqgLn9lOPoySTrDV9dCUnjw==", null, false, "3c3a09a7-8cc8-43a0-84c0-a49c1705e45d", false, "test@mail.com" },
                    { "a615552b-5981-4730-be32-12c087492aef", 0, "d076887f-db67-4b3b-8962-1d97bacf7e1c", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEFh003/+frxFpn0Ca1x4CERvoNQqz9VrX7gKyZYpL4dy+BtsCaai4r2lL+bteC0Jag==", null, false, "4d0db6aa-4121-4e60-9558-e28ef3e2c87a", false, "guest@mail.com" }
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
                columns: new[] { "Id", "DeletedAt", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, "https://images.pexels.com/photos/220885/pexels-photo-220885.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for production of electric bicycles MaxCompany" },
                    { 2, null, "https://images.pexels.com/photos/2833686/pexels-photo-2833686.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Construction of streets in Plovdiv Municipality" },
                    { 3, null, "https://images.pexels.com/photos/236698/pexels-photo-236698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", false, "Plant construction for cardboard packaging GreenPac" }
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
                    { 2, null, false, 2 },
                    { 3, null, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "DeletedAt", "FinishDate", "IsDeleted", "ProjectSiteNameId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2027, 3, 14, 14, 21, 55, 720, DateTimeKind.Local).AddTicks(2457), false, 1 },
                    { 2, null, new DateTime(2029, 3, 14, 14, 21, 55, 720, DateTimeKind.Local).AddTicks(2466), false, 2 },
                    { 3, null, new DateTime(2026, 3, 14, 14, 21, 55, 720, DateTimeKind.Local).AddTicks(2468), false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "DeletedAt", "Description", "IsDeleted", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 14, 14, 21, 55, 820, DateTimeKind.Local).AddTicks(2896), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Must order 5m3 concrete class C20/25 with delivery date next Monday", false, 0, "Order concrete" },
                    { 2, new DateTime(2024, 4, 13, 14, 21, 55, 820, DateTimeKind.Local).AddTicks(2899), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Should start looking through documentation and drawings of upcoming project", false, 0, "New project documentation" },
                    { 3, new DateTime(2024, 3, 9, 14, 21, 55, 820, DateTimeKind.Local).AddTicks(2902), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Go to weekly site Monday meeting", false, 2, "Weekly meeting" },
                    { 4, new DateTime(2024, 3, 14, 14, 21, 55, 820, DateTimeKind.Local).AddTicks(2904), "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Fill in monthly workers attendance forms and send them to accounting by the end of month", false, 1, "Monthly workers attendance forms" },
                    { 5, new DateTime(2024, 3, 14, 14, 21, 55, 820, DateTimeKind.Local).AddTicks(2906), "a615552b-5981-4730-be32-12c087492aef", null, "Call engineer supervisor and schedule meeting to discuss construction work progress and difficulties", false, 0, "Schedule meeting" },
                    { 6, new DateTime(2024, 3, 19, 14, 21, 55, 820, DateTimeKind.Local).AddTicks(2908), "a615552b-5981-4730-be32-12c087492aef", null, "Call Doka representative and order more formwork for site", false, 0, "Formwork" }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "CarryOutDate", "ContractorId", "CostPerUnit", "CreatorId", "DeletedAt", "Description", "IsDeleted", "IsIncluded", "Quantity", "StageId", "TotalCost", "UnitId", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 14, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3046), 3, 23m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 897.0, 4, 20631m, 5, 1 },
                    { 2, new DateTime(2024, 3, 14, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3051), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 120.0, 1, 5100m, 3, 2 },
                    { 3, new DateTime(2024, 3, 15, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3055), 4, 35.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate material and delivery", false, true, 150.0, 1, 5325m, 3, 2 },
                    { 4, new DateTime(2024, 3, 15, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3059), 2, 600m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for crushed aggredate compaction using 11 ton roller", false, false, 1.0, 1, 600m, 8, 2 },
                    { 5, new DateTime(2024, 3, 16, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3062), 4, 42.5m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 250.0, 1, 10625m, 3, 2 },
                    { 6, new DateTime(2024, 3, 24, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3065), 4, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Used combined excavators", false, true, 150.0, 1, 1200m, 3, 3 },
                    { 7, new DateTime(2024, 3, 26, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3067), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 163.0, 1, 26732m, 1, 4 },
                    { 8, new DateTime(2024, 3, 27, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3069), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 158.0, 1, 25912m, 1, 4 },
                    { 9, new DateTime(2024, 3, 28, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3072), 4, 164m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 75.0, 1, 12300m, 1, 4 },
                    { 10, new DateTime(2024, 3, 29, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3075), 4, 152m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, null, false, true, 210.0, 1, 31920m, 1, 5 },
                    { 11, new DateTime(2024, 3, 19, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3077), 2, 135m, "a615552b-5981-4730-be32-12c087492aef", null, null, false, true, 20.0, 1, 2700m, 3, 6 },
                    { 12, new DateTime(2024, 3, 18, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3080), 5, 2.2m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel and delivery", false, true, 57.0, 1, 125.4m, 2, 7 },
                    { 13, new DateTime(2024, 3, 18, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3082), 1, 0.3m, "a615552b-5981-4730-be32-12c087492aef", null, "Entered cost for reinforcement steel laying", false, false, 57.0, 1, 17.1m, 2, 7 },
                    { 14, new DateTime(2024, 3, 31, 14, 21, 55, 789, DateTimeKind.Local).AddTicks(3084), 1, 8m, "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f", null, "Entered cost for formwork assembly", false, true, 57.0, 2, 456m, 4, 8 }
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
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "ProjectsSitesNames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectsSitesNames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectsSitesNames",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}