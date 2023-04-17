using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations.BankingDb
{
    public partial class colomntype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTransactions_MasterAccounts_MasterAccountCartNumber",
                table: "MasterTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MasterTransactions_MasterAccountCartNumber",
                table: "MasterTransactions");

            migrationBuilder.DropColumn(
                name: "MasterAccountCartNumber",
                table: "MasterTransactions");

            migrationBuilder.AlterColumn<long>(
                name: "MasterAccountID",
                table: "MasterTransactions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTransactions_MasterAccountID",
                table: "MasterTransactions",
                column: "MasterAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTransactions_MasterAccounts_MasterAccountID",
                table: "MasterTransactions",
                column: "MasterAccountID",
                principalTable: "MasterAccounts",
                principalColumn: "CartNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTransactions_MasterAccounts_MasterAccountID",
                table: "MasterTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MasterTransactions_MasterAccountID",
                table: "MasterTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "MasterAccountID",
                table: "MasterTransactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "MasterAccountCartNumber",
                table: "MasterTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_MasterTransactions_MasterAccountCartNumber",
                table: "MasterTransactions",
                column: "MasterAccountCartNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTransactions_MasterAccounts_MasterAccountCartNumber",
                table: "MasterTransactions",
                column: "MasterAccountCartNumber",
                principalTable: "MasterAccounts",
                principalColumn: "CartNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
