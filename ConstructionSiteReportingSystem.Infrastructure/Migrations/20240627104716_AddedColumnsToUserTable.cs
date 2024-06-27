using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSiteReportingSystem.Infrastructure.Migrations
{
    public partial class AddedColumnsToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "MiddleName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f2285a4-86ba-441a-baf4-0b73f95280ec", "Konstantin", "Georgiev", "Kirilov", "AQAAAAEAACcQAAAAEGovRXDPlJSV+RNXirQIFm2AyKSRRS75rHYQO+5QfFtFG55Yr6E+SChtYiTMfBEYCA==", "22a18c6e-a447-4bfe-9dc4-5166ef75c3dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "MiddleName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2a4ff73-92e0-48a7-afd4-6263e1af4d11", "Ivan", "Petrov", "Metodiev", "AQAAAAEAACcQAAAAECEgSbs+s3goCzIixajx/y/EyaSAI3Q8y2ppqwGxwwuT/osysW0aWVxFzRoonLGVpA==", "2fb39918-4846-4c4b-bafc-90539ae9dfe5" });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinishDate",
                value: new DateTime(2027, 6, 27, 13, 47, 15, 606, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinishDate",
                value: new DateTime(2029, 6, 27, 13, 47, 15, 606, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinishDate",
                value: new DateTime(2026, 6, 27, 13, 47, 15, 606, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 13, 47, 15, 671, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 27, 13, 47, 15, 671, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 22, 13, 47, 15, 671, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 13, 47, 15, 671, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 13, 47, 15, 671, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 2, 13, 47, 15, 671, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 27, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 27, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 26, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 4,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 26, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 5,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 25, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 6,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 17, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 7,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 15, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 8,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 14, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 9,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 13, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 12, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 11,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 22, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 12,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 23, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 13,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 23, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 14,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 10, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 15,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 22, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 16,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 23, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 24, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 25, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 19,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 28, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 20,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 27, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 21,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 26, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 22,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 26, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 23,
                column: "CarryOutDate",
                value: new DateTime(2024, 6, 27, 13, 47, 15, 657, DateTimeKind.Local).AddTicks(6503));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92dd796a-9c62-41b2-8076-f7462c6d9990", "AQAAAAEAACcQAAAAECjwJ//Tzqv4NyTTa1Yx5/pRTfL4KqPDhNNGiwJM6qJY7qhkvUojqZu/SOBIp/WUsg==", "81bcdb6c-d71e-414e-85ea-d694e16b972b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00afc460-8404-457d-80bc-6333e7719a93", "AQAAAAEAACcQAAAAEDvut/StLb+YpadbHrfn3zua7pMWFSsfRveLWtbYFLhmo4mmAKXN/lD/dkaL4e6ylA==", "0b7c1a2c-7000-4364-9e08-16bd63e74b09" });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinishDate",
                value: new DateTime(2027, 4, 3, 17, 32, 42, 994, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinishDate",
                value: new DateTime(2029, 4, 3, 17, 32, 42, 994, DateTimeKind.Local).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinishDate",
                value: new DateTime(2026, 4, 3, 17, 32, 42, 994, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 29, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1255));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1257));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 17, 32, 43, 58, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5663));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 4,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 5,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 1, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 6,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 24, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 7,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 22, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 8,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 21, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 9,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 20, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 19, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5694));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 11,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 29, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 12,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 30, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 13,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 30, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 14,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 17, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 15,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 29, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 16,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 30, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarryOutDate",
                value: new DateTime(2024, 3, 31, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 1, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 19,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 4, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 20,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5778));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 21,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 22,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 2, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 23,
                column: "CarryOutDate",
                value: new DateTime(2024, 4, 3, 17, 32, 43, 45, DateTimeKind.Local).AddTicks(5788));
        }
    }
}
