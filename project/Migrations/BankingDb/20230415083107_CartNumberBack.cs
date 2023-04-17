using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations.BankingDb
{
    public partial class CartNumberBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTransactions_MasterAccounts_MasterAccountNameOnCard",
                table: "MasterTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MasterTransactions_MasterAccountNameOnCard",
                table: "MasterTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterAccounts",
                table: "MasterAccounts");

            migrationBuilder.DropColumn(
                name: "MasterAccountNameOnCard",
                table: "MasterTransactions");

            migrationBuilder.AddColumn<long>(
                name: "MasterAccountCartNumber",
                table: "MasterTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "NameOnCard",
                table: "MasterAccounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "CartNumber",
                table: "MasterAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterAccounts",
                table: "MasterAccounts",
                column: "CartNumber");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTransactions_MasterAccounts_MasterAccountCartNumber",
                table: "MasterTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MasterTransactions_MasterAccountCartNumber",
                table: "MasterTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterAccounts",
                table: "MasterAccounts");

            migrationBuilder.DropColumn(
                name: "MasterAccountCartNumber",
                table: "MasterTransactions");

            migrationBuilder.DropColumn(
                name: "CartNumber",
                table: "MasterAccounts");

            migrationBuilder.AddColumn<string>(
                name: "MasterAccountNameOnCard",
                table: "MasterTransactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NameOnCard",
                table: "MasterAccounts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterAccounts",
                table: "MasterAccounts",
                column: "NameOnCard");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTransactions_MasterAccountNameOnCard",
                table: "MasterTransactions",
                column: "MasterAccountNameOnCard");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTransactions_MasterAccounts_MasterAccountNameOnCard",
                table: "MasterTransactions",
                column: "MasterAccountNameOnCard",
                principalTable: "MasterAccounts",
                principalColumn: "NameOnCard",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
