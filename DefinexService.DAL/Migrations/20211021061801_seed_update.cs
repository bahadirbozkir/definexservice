using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefinexService.DAL.Migrations
{
    public partial class seed_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BankListId",
                table: "BankGateway",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "BankGateway",
                columns: new[] { "Id", "BankListId", "ClientPassword", "ClientUsername", "ConfigurationId", "CreatedOn", "TerminalId" },
                values: new object[,]
                {
                    { 1L, 0L, "test", "test", 123L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(1246), 123L },
                    { 2L, 0L, "test", "test", 123L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(1418), 123L },
                    { 3L, 0L, "test", "test", 123L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(1424), 123L }
                });

            migrationBuilder.InsertData(
                table: "BankLists",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 10, 21, 6, 18, 0, 871, DateTimeKind.Utc).AddTicks(8243), "Is Bankasi" },
                    { 2L, new DateTime(2021, 10, 21, 6, 18, 0, 871, DateTimeKind.Utc).AddTicks(8352), "Garanti" },
                    { 3L, new DateTime(2021, 10, 21, 6, 18, 0, 871, DateTimeKind.Utc).AddTicks(8357), "Akbank" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(3589), "ELEKTRONIK" },
                    { 2L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(3638), "OYUN" },
                    { 3L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(3642), "YAPI MALZEMESI" }
                });

            migrationBuilder.InsertData(
                table: "CreditConditions",
                columns: new[] { "Id", "BankGatewayId", "BankType", "ConditionType", "ConditionValue", "CreatedOn" },
                values: new object[,]
                {
                    { 1L, 1L, 1, 1, "3500", new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(9803) },
                    { 4L, 1L, 1, 1, "3500", new DateTime(2021, 10, 21, 6, 18, 0, 877, DateTimeKind.Utc).AddTicks(3948) },
                    { 2L, 2L, 2, 1, "3500", new DateTime(2021, 10, 21, 6, 18, 0, 877, DateTimeKind.Utc).AddTicks(3871) },
                    { 5L, 2L, 2, 1, "3500", new DateTime(2021, 10, 21, 6, 18, 0, 877, DateTimeKind.Utc).AddTicks(3951) },
                    { 3L, 3L, 3, 1, "3500", new DateTime(2021, 10, 21, 6, 18, 0, 877, DateTimeKind.Utc).AddTicks(3944) },
                    { 6L, 3L, 3, 1, "3500", new DateTime(2021, 10, 21, 6, 18, 0, 877, DateTimeKind.Utc).AddTicks(3953) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(7960), "TEST1", 5000m },
                    { 2L, 2L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(8076), "TEST2", 2000m },
                    { 3L, 3L, new DateTime(2021, 10, 21, 6, 18, 0, 876, DateTimeKind.Utc).AddTicks(8082), "TEST3", 7000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankGateway_BankListId",
                table: "BankGateway",
                column: "BankListId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankGateway_BankLists_BankListId",
                table: "BankGateway",
                column: "BankListId",
                principalTable: "BankLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankGateway_BankLists_BankListId",
                table: "BankGateway");

            migrationBuilder.DropIndex(
                name: "IX_BankGateway_BankListId",
                table: "BankGateway");

            migrationBuilder.DeleteData(
                table: "BankLists",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BankLists",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BankLists",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CreditConditions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CreditConditions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CreditConditions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CreditConditions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CreditConditions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CreditConditions",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "BankGateway",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BankGateway",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BankGateway",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "BankListId",
                table: "BankGateway");
        }
    }
}
