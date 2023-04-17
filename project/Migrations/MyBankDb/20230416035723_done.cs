using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations.MyBankDb
{
    public partial class done : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisaTransactions_VisaAccounts_VisaAccountCartNumber",
                table: "VisaTransactions");

            migrationBuilder.DropColumn(
                name: "MasterAccountID",
                table: "VisaTransactions");

            migrationBuilder.RenameColumn(
                name: "VisaAccountCartNumber",
                table: "VisaTransactions",
                newName: "VisaAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_VisaTransactions_VisaAccountCartNumber",
                table: "VisaTransactions",
                newName: "IX_VisaTransactions_VisaAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_VisaTransactions_VisaAccounts_VisaAccountID",
                table: "VisaTransactions",
                column: "VisaAccountID",
                principalTable: "VisaAccounts",
                principalColumn: "CartNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisaTransactions_VisaAccounts_VisaAccountID",
                table: "VisaTransactions");

            migrationBuilder.RenameColumn(
                name: "VisaAccountID",
                table: "VisaTransactions",
                newName: "VisaAccountCartNumber");

            migrationBuilder.RenameIndex(
                name: "IX_VisaTransactions_VisaAccountID",
                table: "VisaTransactions",
                newName: "IX_VisaTransactions_VisaAccountCartNumber");

            migrationBuilder.AddColumn<long>(
                name: "MasterAccountID",
                table: "VisaTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_VisaTransactions_VisaAccounts_VisaAccountCartNumber",
                table: "VisaTransactions",
                column: "VisaAccountCartNumber",
                principalTable: "VisaAccounts",
                principalColumn: "CartNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
