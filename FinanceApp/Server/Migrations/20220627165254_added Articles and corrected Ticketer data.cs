using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Migrations
{
    public partial class addedArticlesandcorrectedTicketerdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    TicketerId = table.Column<int>(type: "int", nullable: false),
                    published_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    article_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => new { x.TicketerId, x.published_utc });
                    table.ForeignKey(
                        name: "FK_Article_Ticketer_TicketerId",
                        column: x => x.TicketerId,
                        principalTable: "Ticketer",
                        principalColumn: "TicketerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 1,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "Jeffrey Storey", "https://s24.q4cdn.com/287068338/files/design/lumen-logo-blue-black.png", "fiber infrastructure" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 2,
                columns: new[] { "CEO", "Logo", "Name", "Sector" },
                values: new object[] { "Alan S. Armstrong", "https://g.foolcdn.com/art/companylogos/medium/WMB.png", "Williams Companies Inc.", "Utilities" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 3,
                columns: new[] { "CEO", "Logo", "Name", "Sector" },
                values: new object[] { "Walter Schalka", "https://suzano-site.s3-sa-east-1.amazonaws.com/assets/img/logo-suzano-rodape.png", "Suzano S.A.", "bio-based materials" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 4,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "Sasan K. Goodarzi", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Intuit_Logo.svg/1200px-Intuit_Logo.svg.png", "financial management" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 5,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "Dave Lougee", "https://res.cloudinary.com/etoro/image/fetch/w_1.5/https://etoro-cdn.etorostatic.com/market-avatars/6873/150x150.png", "media provider" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 6,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "Michael Williams", "https://www.timkensteel.com/img/timkenSteelShare.jpg", "basic materials" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 7,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "Elon Musk", "https://upload.wikimedia.org/wikipedia/commons/e/e8/Tesla_logo.png", "Automotive, Energy Generation" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 8,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "Randy Neely", "https://s24.q4cdn.com/107256193/files/design/transglobe-logo.svg", "oil exploration" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 9,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "David Feller", "https://static.seekingalpha.com/uploads/2020/1/13/22464021-15789554209817338.jpg", "information" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 10,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "Paul J. O'Shea", "https://s3-symbol-logo.tradingview.com/enstar-group--600.png", "insurance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 1,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi1.wp.com%2Fwww.denverpost.com%2Fwp-content%2Fuploads%2F2020%2F09%2FLumen-Logo.png%3Ffit%3D620%252C9999px%26ssl%3D1&f=1&nofb=1", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 2,
                columns: new[] { "CEO", "Logo", "Name", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Flogosandbrands.directory%2Fwp-content%2Fthemes%2Fdirectorypress%2Fthumbs%2FWilliams-Companies-logo.jpg&f=1&nofb=1", " Inc.", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 3,
                columns: new[] { "CEO", "Logo", "Name", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Flogodownload.org%2Fwp-content%2Fuploads%2F2014%2F07%2Fsuzano-logo-1.png&f=1&nofb=1", "Suzano S.A. American Depositary Shares", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 4,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Feveripedia-storage.s3-accelerate.amazonaws.com%2FProfilePics%2F83065__29332.png&f=1&nofb=1", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 5,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fmms.businesswire.com%2Fmedia%2F20150721005847%2Fen%2F474552%2F5%2FTEGNA_Logo.jpg&f=1&nofb=1", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 6,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmma.prnewswire.com%2Fmedia%2F476403%2Fthe_timken_company_timkensteel_corporation_logo.jpg%3Fp%3Dpublish%26w%3D950&f=1&nofb=1", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 7,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.Uu1GrEpm9v2YGCNB0iRmkwHaHa%26pid%3DApi&f=1", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 8,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.cbj.ca%2Fwp-content%2Fuploads%2F2021%2F01%2Ftransglobe-energy-corporation-announces-its-2021-capital-budget.jpg&f=1&nofb=1", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 9,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.wHxnsGXoVsXXmYLj_tAmSgHaHa%26pid%3DApi&f=1", "stocks" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 10,
                columns: new[] { "CEO", "Logo", "Sector" },
                values: new object[] { "tmp", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.marketbeat.com%2Flogos%2Fenstar-group-ltd-logo.png&f=1&nofb=1", "stocks" });
        }
    }
}
