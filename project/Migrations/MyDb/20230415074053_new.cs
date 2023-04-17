using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations.MyDb
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterAccounts",
                columns: table => new
                {
                    CartNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    InitialAmount = table.Column<int>(type: "int", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAccounts", x => x.CartNumber);
                });

            migrationBuilder.CreateTable(
                name: "MasterTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardBalance = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    TransactionValue = table.Column<int>(type: "int", nullable: false),
                    TarnsactonNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    MasterAccountID = table.Column<int>(type: "int", nullable: false),
                    MasterAccountCartNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_MasterTransactions_MasterAccounts_MasterAccountCartNumber",
                        column: x => x.MasterAccountCartNumber,
                        principalTable: "MasterAccounts",
                        principalColumn: "CartNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterTransactions_MasterAccountCartNumber",
                table: "MasterTransactions",
                column: "MasterAccountCartNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterTransactions");

            migrationBuilder.DropTable(
                name: "MasterAccounts");
        }
    }
}
