using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations.MyBankDb
{
    public partial class lastoflast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTransactions_VisaAccounts_VisaAcountsCartNumber",
                table: "MasterTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_VisaTransactions_MasterAccounts_MasterAccountID",
                table: "VisaTransactions");

            migrationBuilder.DropIndex(
                name: "IX_VisaTransactions_MasterAccountID",
                table: "VisaTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MasterTransactions_VisaAcountsCartNumber",
                table: "MasterTransactions");

            migrationBuilder.DropColumn(
                name: "VisaAcountsCartNumber",
                table: "MasterTransactions");

            migrationBuilder.AddColumn<long>(
                name: "VisaAccountCartNumber",
                table: "VisaTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_VisaTransactions_VisaAccountCartNumber",
                table: "VisaTransactions",
                column: "VisaAccountCartNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_VisaTransactions_VisaAccounts_VisaAccountCartNumber",
                table: "VisaTransactions",
                column: "VisaAccountCartNumber",
                principalTable: "VisaAccounts",
                principalColumn: "CartNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisaTransactions_VisaAccounts_VisaAccountCartNumber",
                table: "VisaTransactions");

            migrationBuilder.DropIndex(
                name: "IX_VisaTransactions_VisaAccountCartNumber",
                table: "VisaTransactions");

            migrationBuilder.DropColumn(
                name: "VisaAccountCartNumber",
                table: "VisaTransactions");

            migrationBuilder.AddColumn<long>(
                name: "VisaAcountsCartNumber",
                table: "MasterTransactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisaTransactions_MasterAccountID",
                table: "VisaTransactions",
                column: "MasterAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTransactions_VisaAcountsCartNumber",
                table: "MasterTransactions",
                column: "VisaAcountsCartNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTransactions_VisaAccounts_VisaAcountsCartNumber",
                table: "MasterTransactions",
                column: "VisaAcountsCartNumber",
                principalTable: "VisaAccounts",
                principalColumn: "CartNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_VisaTransactions_MasterAccounts_MasterAccountID",
                table: "VisaTransactions",
                column: "MasterAccountID",
                principalTable: "MasterAccounts",
                principalColumn: "CartNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
