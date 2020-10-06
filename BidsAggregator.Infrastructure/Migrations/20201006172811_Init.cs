using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BidsAggregator.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquirers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Street = table.Column<string>(maxLength: 70, nullable: false),
                    HouseNumber = table.Column<int>(maxLength: 500, nullable: false),
                    Porch = table.Column<int>(maxLength: 20, nullable: true),
                    ApartmentNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquirers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    PositiveRating = table.Column<int>(maxLength: 1000, nullable: false, defaultValue: 0),
                    NegativeRating = table.Column<int>(maxLength: 1000, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempolaryInquirers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Street = table.Column<string>(maxLength: 70, nullable: false),
                    HouseNumber = table.Column<int>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempolaryInquirers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<byte>(nullable: false, defaultValue: (byte)0),
                    PerformerId = table.Column<long>(nullable: true),
                    InquiryType = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    InquirerId = table.Column<long>(nullable: true),
                    BidderId = table.Column<long>(nullable: true),
                    TempolaryUrl = table.Column<string>(maxLength: 200, nullable: true),
                    Body = table.Column<string>(maxLength: 500, nullable: true),
                    TempolaryInquiry_InquirerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_Inquirers_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Inquirers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inquiries_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inquiries_TempolaryInquirers_TempolaryInquiry_InquirerId",
                        column: x => x.TempolaryInquiry_InquirerId,
                        principalTable: "TempolaryInquirers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InquiryItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(maxLength: 1000, nullable: false),
                    IsComleted = table.Column<bool>(nullable: false, defaultValue: false),
                    InquiryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquiryItem_Inquiries_InquiryId",
                        column: x => x.InquiryId,
                        principalTable: "Inquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inquirers_Id_FirstName_MiddleName_LastName_PhoneNumber_Street_HouseNumber",
                table: "Inquirers",
                columns: new[] { "Id", "FirstName", "MiddleName", "LastName", "PhoneNumber", "Street", "HouseNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_BidderId",
                table: "Inquiries",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CreatedDate",
                table: "Inquiries",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_ModifiedDate",
                table: "Inquiries",
                column: "ModifiedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_Status",
                table: "Inquiries",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_PerformerId",
                table: "Inquiries",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CreatedDate1",
                table: "Inquiries",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_TempolaryInquiry_InquirerId",
                table: "Inquiries",
                column: "TempolaryInquiry_InquirerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_ModifiedDate1",
                table: "Inquiries",
                column: "ModifiedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_Status1",
                table: "Inquiries",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryItem_InquiryId",
                table: "InquiryItem",
                column: "InquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Performers_Id_FirstName_MiddleName_LastName",
                table: "Performers",
                columns: new[] { "Id", "FirstName", "MiddleName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_TempolaryInquirers_Id_FirstName_MiddleName_LastName_PhoneNumber_Street_HouseNumber",
                table: "TempolaryInquirers",
                columns: new[] { "Id", "FirstName", "MiddleName", "LastName", "PhoneNumber", "Street", "HouseNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InquiryItem");

            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropTable(
                name: "Inquirers");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "TempolaryInquirers");
        }
    }
}
