using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSiteReportingSystem.Infrastructure.Migrations
{
    public partial class AddedUserClaimsAndAdminUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:firstlastname", "Konstantin Kirilov", "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f" },
                    { 2, "user:firstlastname", "Ivan Metodiev", "a615552b-5981-4730-be32-12c087492aef" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e29ed539-9013-4e2a-a836-e1646e70baaf", "AQAAAAEAACcQAAAAEHonMwwd5ipW5IrMEzpbjR97Gy/b6tE/zIV6aRSd8c4IYiGw/DvRxINqKe3Jxnr6+Q==", "9af44863-c993-49fc-8d3e-ed3da5d1bc03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59755472-5d76-4ae3-9462-bc508b74ff72", "AQAAAAEAACcQAAAAEPn14m5JDWgtqx8PyGxvkXh4yz/J8KepOhuvBlblEx//Hddr3zwnOQtNm1Bm1NGnmA==", "a79a0020-babf-4eb4-9174-cdf42a3bc0dc" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "51d6e97b-9c12-4832-95e1-c0dfa1715ad9", 0, "73a43135-cd6c-4477-aa1c-ff0523275172", "admin@mail.com", false, "Anton", "Kovadzhiev", false, null, "Naidenov", "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEKcV7dJkqY9vXsWxc2K05J88YaDuJVH75WoCrGNXlDs/ZrpsWeAOnBYuB9/6Ab7/VQ==", null, false, "778f8d68-787d-46b7-8f4e-ed00ff3ef526", false, "admin@mail.com" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 3, "user:firstlastname", "Anton Kovadzhiev", "51d6e97b-9c12-4832-95e1-c0dfa1715ad9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51d6e97b-9c12-4832-95e1-c0dfa1715ad9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f2285a4-86ba-441a-baf4-0b73f95280ec", "AQAAAAEAACcQAAAAEGovRXDPlJSV+RNXirQIFm2AyKSRRS75rHYQO+5QfFtFG55Yr6E+SChtYiTMfBEYCA==", "22a18c6e-a447-4bfe-9dc4-5166ef75c3dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2a4ff73-92e0-48a7-afd4-6263e1af4d11", "AQAAAAEAACcQAAAAECEgSbs+s3goCzIixajx/y/EyaSAI3Q8y2ppqwGxwwuT/osysW0aWVxFzRoonLGVpA==", "2fb39918-4846-4c4b-bafc-90539ae9dfe5" });

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
    }
}
