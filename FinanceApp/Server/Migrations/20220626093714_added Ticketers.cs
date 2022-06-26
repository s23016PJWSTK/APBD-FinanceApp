using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Migrations
{
    public partial class addedTicketers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticketer",
                columns: table => new
                {
                    TicketerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CEO = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticketer", x => x.TicketerId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "TicketerData",
                columns: table => new
                {
                    TicketerId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Close = table.Column<double>(type: "float", nullable: false),
                    Highest = table.Column<double>(type: "float", nullable: false),
                    Lowest = table.Column<double>(type: "float", nullable: false),
                    NumberOfTransactons = table.Column<double>(type: "float", nullable: false),
                    Open = table.Column<double>(type: "float", nullable: false),
                    OTC = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    VolumeWeighted = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketerData", x => new { x.TicketerId, x.Date });
                    table.ForeignKey(
                        name: "FK_TicketerData_Ticketer_TicketerId",
                        column: x => x.TicketerId,
                        principalTable: "Ticketer",
                        principalColumn: "TicketerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchList",
                columns: table => new
                {
                    WatchListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList", x => x.WatchListId);
                    table.ForeignKey(
                        name: "FK_WatchList_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchList_Ticketer",
                columns: table => new
                {
                    TicketerId = table.Column<int>(type: "int", nullable: false),
                    WatchListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList_Ticketer", x => new { x.TicketerId, x.WatchListId });
                    table.ForeignKey(
                        name: "FK_WatchList_Ticketer_Ticketer_TicketerId",
                        column: x => x.TicketerId,
                        principalTable: "Ticketer",
                        principalColumn: "TicketerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchList_Ticketer_WatchList_WatchListId",
                        column: x => x.WatchListId,
                        principalTable: "WatchList",
                        principalColumn: "WatchListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ticketer",
                columns: new[] { "TicketerId", "CEO", "Country", "Logo", "Name", "Sector", "Symbol" },
                values: new object[,]
                {
                    { 1, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3Lmx1bWVuLmNvbQ/images/2022-01-10_logo.png", "Lumen Technologies, Inc.", "stocks", "LUMN" },
                    { 2, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LndpbGxpYW1zLmNvbQ/images/2022-01-10_logo.png", "Williams Companies Inc.", "stocks", "WMB" },
                    { 3, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LnN1emFuby5jb20uYnI/images/2022-01-10_logo.png", "Suzano S.A. American Depositary Shares", "stocks", "SUZ" },
                    { 4, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LmludHVpdC5jb20/images/2022-01-10_logo.svg", "Intuit Inc", "stocks", "INTU" },
                    { 5, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LnRlZ25hLmNvbQ/images/2022-01-10_logo.png", "TEGNA Inc.", "stocks", "TGNA" },
                    { 6, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LnRpbWtlbnN0ZWVsLmNvbQ/images/2022-01-10_icon.jpeg", "TIMKENSTEEL CORPORATION", "stocks", "TMST" },
                    { 7, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LnRlc2xhLmNvbQ/images/2022-01-10_logo.svg", "Tesla, Inc. Common Stock", "stocks", "TSLA" },
                    { 8, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LnRyYW5zLWdsb2JlLmNvbQ/images/2022-01-10_logo.svg", "Transglobe Energy Corp", "stocks", "TGA" },
                    { 9, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3Lm1vZ28uY2E/images/2022-01-10_logo.png", "Mogo Inc. Common Shares", "stocks", "MOGO" },
                    { 10, "tmp", "US", "https://api.polygon.io/v1/reference/company-branding/d3d3LmVuc3Rhcmdyb3VwLmNvbQ/images/2022-01-10_logo.png", "Enstar Group Limited Depository", "stocks", "ESGRO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_UserEmail",
                table: "WatchList",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_Ticketer_WatchListId",
                table: "WatchList_Ticketer",
                column: "WatchListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketerData");

            migrationBuilder.DropTable(
                name: "WatchList_Ticketer");

            migrationBuilder.DropTable(
                name: "Ticketer");

            migrationBuilder.DropTable(
                name: "WatchList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
