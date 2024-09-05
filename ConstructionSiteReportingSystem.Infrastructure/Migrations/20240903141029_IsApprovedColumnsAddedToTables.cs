using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSiteReportingSystem.Infrastructure.Migrations
{
    public partial class IsApprovedColumnsAddedToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "WorksTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is construction and assembly work type approved by the administrator");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Units",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is measurement unit approved by the administrator");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Stages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is construction stage approved by the administrator");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Contractors",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is construction contractor approved by the administrator");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30f87965-b478-471b-a9af-7ba27a5afb65", "AQAAAAEAACcQAAAAEHQHFTo/ohCA7rMS/yy6JgL4z0X6ozHg6fq+487ahcxmQQAnGMnWRKkqjKl8z/umkw==", "ba2517ae-290e-4fc6-9370-618348f420e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51d6e97b-9c12-4832-95e1-c0dfa1715ad9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "990475c9-4def-4f55-af22-dbf319c1c188", "AQAAAAEAACcQAAAAEFULviZPa/0Zul35W+Dz1uwckdH3+6AlHBbzP96h+FFQjrVsiVR8C0gJzuanLRSarg==", "9df45db0-b489-4f74-bb1d-17d261c2c60d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a24add4-026f-4b41-8fbe-372d9e6459da", "AQAAAAEAACcQAAAAEJe6LKAGgS5+8DyUNHlSJN/XEGuepk+PSNlbaFlbziSeXeKwWSwoAuBKZSZYgzyk4Q==", "6d77187c-9d4b-47f4-a8ff-e5cefe3e8746" });

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinishDate",
                value: new DateTime(2027, 9, 3, 17, 10, 28, 518, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinishDate",
                value: new DateTime(2029, 9, 3, 17, 10, 28, 518, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinishDate",
                value: new DateTime(2026, 9, 3, 17, 10, 28, 518, DateTimeKind.Local).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 3, 17, 10, 28, 637, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 3, 17, 10, 28, 637, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 29, 17, 10, 28, 637, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 3, 17, 10, 28, 637, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 3, 17, 10, 28, 637, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 8, 17, 10, 28, 637, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 3, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 3, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 2, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 4,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 2, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 5,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 1, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 6,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 24, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 7,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 22, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 8,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 21, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 9,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 20, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 19, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 11,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 29, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 12,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 30, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 13,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 30, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 14,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 17, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 15,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 29, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 16,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 30, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarryOutDate",
                value: new DateTime(2024, 8, 31, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 1, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 19,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 4, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 20,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 3, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 21,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 2, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 22,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 2, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 23,
                column: "CarryOutDate",
                value: new DateTime(2024, 9, 3, 17, 10, 28, 612, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorksTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsApproved",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "WorksTypes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Contractors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e29ed539-9013-4e2a-a836-e1646e70baaf", "AQAAAAEAACcQAAAAEHonMwwd5ipW5IrMEzpbjR97Gy/b6tE/zIV6aRSd8c4IYiGw/DvRxINqKe3Jxnr6+Q==", "9af44863-c993-49fc-8d3e-ed3da5d1bc03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51d6e97b-9c12-4832-95e1-c0dfa1715ad9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73a43135-cd6c-4477-aa1c-ff0523275172", "AQAAAAEAACcQAAAAEKcV7dJkqY9vXsWxc2K05J88YaDuJVH75WoCrGNXlDs/ZrpsWeAOnBYuB9/6Ab7/VQ==", "778f8d68-787d-46b7-8f4e-ed00ff3ef526" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59755472-5d76-4ae3-9462-bc508b74ff72", "AQAAAAEAACcQAAAAEPn14m5JDWgtqx8PyGxvkXh4yz/J8KepOhuvBlblEx//Hddr3zwnOQtNm1Bm1NGnmA==", "a79a0020-babf-4eb4-9174-cdf42a3bc0dc" });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinishDate",
                value: new DateTime(2027, 7, 2, 17, 10, 20, 107, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinishDate",
                value: new DateTime(2029, 7, 2, 17, 10, 20, 107, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinishDate",
                value: new DateTime(2026, 7, 2, 17, 10, 20, 107, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 2, 17, 10, 20, 202, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 1, 17, 10, 20, 202, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 17, 10, 20, 202, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 2, 17, 10, 20, 202, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 2, 17, 10, 20, 202, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 7, 17, 10, 20, 202, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 2, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 2, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 1, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 4,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 1, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 5,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 30, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 6,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 22, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 7,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 20, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 8,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 19, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 9,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 18, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 17, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 11,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 27, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 12,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 28, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 13,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 28, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 14,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 15, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 15,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 27, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 16,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 28, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 29, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 30, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 19,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 3, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 20,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 2, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 21,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 1, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 22,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 1, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 23,
                column: "CarryOutDate",
                value: new DateTime(2024, 7, 2, 17, 10, 20, 183, DateTimeKind.Local).AddTicks(9865));
        }
    }
}
