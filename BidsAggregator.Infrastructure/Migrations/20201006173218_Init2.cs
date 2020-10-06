using Microsoft.EntityFrameworkCore.Migrations;

namespace BidsAggregator.Infrastructure.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Inquirers_BidderId",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_BidderId",
                table: "Inquiries");

            migrationBuilder.DropColumn(
                name: "BidderId",
                table: "Inquiries");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_InquirerId",
                table: "Inquiries",
                column: "InquirerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Inquirers_InquirerId",
                table: "Inquiries",
                column: "InquirerId",
                principalTable: "Inquirers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Inquirers_InquirerId",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_InquirerId",
                table: "Inquiries");

            migrationBuilder.AddColumn<long>(
                name: "BidderId",
                table: "Inquiries",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_BidderId",
                table: "Inquiries",
                column: "BidderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Inquirers_BidderId",
                table: "Inquiries",
                column: "BidderId",
                principalTable: "Inquirers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
