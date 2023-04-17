using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations.MyBankDb
{
    public partial class last : Migration
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
                    AccountStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAccounts", x => x.CartNumber);
                });

            migrationBuilder.CreateTable(
                name: "VisaAccounts",
                columns: table => new
                {
                    CartNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    InitialAmount = table.Column<int>(type: "int", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaAccounts", x => x.CartNumber);
                });

            migrationBuilder.CreateTable(
                name: "VisaTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardBalance = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    TransactionValue = table.Column<int>(type: "int", nullable: false),
                    TarnsactonNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    MasterAccountID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_VisaTransactions_MasterAccounts_MasterAccountID",
                        column: x => x.MasterAccountID,
                        principalTable: "MasterAccounts",
                        principalColumn: "CartNumber",
                        onDelete: ReferentialAction.Cascade);
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
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    MasterAccountID = table.Column<long>(type: "bigint", nullable: false),
                    VisaAcountsCartNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_MasterTransactions_MasterAccounts_MasterAccountID",
                        column: x => x.MasterAccountID,
                        principalTable: "MasterAccounts",
                        principalColumn: "CartNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterTransactions_VisaAccounts_VisaAcountsCartNumber",
                        column: x => x.VisaAcountsCartNumber,
                        principalTable: "VisaAccounts",
                        principalColumn: "CartNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterTransactions_MasterAccountID",
                table: "MasterTransactions",
                column: "MasterAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTransactions_VisaAcountsCartNumber",
                table: "MasterTransactions",
                column: "VisaAcountsCartNumber");

            migrationBuilder.CreateIndex(
                name: "IX_VisaTransactions_MasterAccountID",
                table: "VisaTransactions",
                column: "MasterAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterTransactions");

            migrationBuilder.DropTable(
                name: "VisaTransactions");

            migrationBuilder.DropTable(
                name: "VisaAccounts");

            migrationBuilder.DropTable(
                name: "MasterAccounts");
        }
    }
}
