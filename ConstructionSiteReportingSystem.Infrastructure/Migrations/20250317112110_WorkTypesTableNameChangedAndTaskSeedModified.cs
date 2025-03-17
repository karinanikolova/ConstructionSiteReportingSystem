using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSiteReportingSystem.Infrastructure.Migrations
{
    public partial class WorkTypesTableNameChangedAndTaskSeedModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_WorksTypes_WorkTypeId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorksTypes",
                table: "WorksTypes");

            migrationBuilder.RenameTable(
                name: "WorksTypes",
                newName: "WorkTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTypes",
                table: "WorkTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimValue",
                value: "Konstantin Georgiev");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClaimValue",
                value: "Ivan Petrov");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "774640dd-2181-462e-9981-3c03d01acf6c", "AQAAAAEAACcQAAAAECSxrMAtBAfmQLKuGSZFv8qPGK7IlUoOlXzjsf6BLq7zrOk9joB5L8C9cElNAXF/Nw==", "2f2b886e-13cd-4953-aead-8dfc06db31c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51d6e97b-9c12-4832-95e1-c0dfa1715ad9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aec82a93-920a-4ee9-a971-a34ff0f48c05", "AQAAAAEAACcQAAAAEN1hcvhicu5nDSOOslGVAY3jwAbOqnDuG9qldINmbMHuEsTF6dPAXfkEWplU/iXfrA==", "7d7f92d8-151d-43c4-8c86-9d22a37e0566" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a615552b-5981-4730-be32-12c087492aef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22930212-8711-477c-8703-c0a254aa946e", "AQAAAAEAACcQAAAAELpWCQuRrgAV2CpjcyNwrYi5ySpE9GXtGRSwln3r3UoTXkGPSIxJy2TjCXajjlzkEQ==", "e918b1db-b68f-4816-9452-b5f63a883faf" });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinishDate",
                value: new DateTime(2028, 3, 17, 13, 21, 9, 755, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinishDate",
                value: new DateTime(2030, 3, 17, 13, 21, 9, 755, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinishDate",
                value: new DateTime(2027, 3, 17, 13, 21, 9, 755, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 3, 17, 13, 21, 9, 850, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 15, 13, 21, 9, 850, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 3, 12, 13, 21, 9, 850, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 3, 17, 13, 21, 9, 850, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 3, 17, 13, 21, 9, 850, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 3, 12, 13, 21, 9, 850, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 17, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 17, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 16, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 4,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 16, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 5,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 15, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 6,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 7, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 7,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 5, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 8,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 4, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 9,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 3, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 2, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 11,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 12, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 12,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 13, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 13,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 13, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 14,
                column: "CarryOutDate",
                value: new DateTime(2025, 2, 28, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 15,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 12, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 16,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 13, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 14, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 15, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 19,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 18, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 20,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 17, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 21,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 16, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 22,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 16, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 23,
                column: "CarryOutDate",
                value: new DateTime(2025, 3, 17, 13, 21, 9, 831, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.AddForeignKey(
                name: "FK_Works_WorkTypes_WorkTypeId",
                table: "Works",
                column: "WorkTypeId",
                principalTable: "WorkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_WorkTypes_WorkTypeId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTypes",
                table: "WorkTypes");

            migrationBuilder.RenameTable(
                name: "WorkTypes",
                newName: "WorksTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorksTypes",
                table: "WorksTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimValue",
                value: "Konstantin Kirilov");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClaimValue",
                value: "Ivan Metodiev");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Works_WorksTypes_WorkTypeId",
                table: "Works",
                column: "WorkTypeId",
                principalTable: "WorksTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
