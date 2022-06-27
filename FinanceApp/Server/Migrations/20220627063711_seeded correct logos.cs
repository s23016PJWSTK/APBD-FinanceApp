using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Migrations
{
    public partial class seededcorrectlogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 1,
                column: "Logo",
                value: "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi1.wp.com%2Fwww.denverpost.com%2Fwp-content%2Fuploads%2F2020%2F09%2FLumen-Logo.png%3Ffit%3D620%252C9999px%26ssl%3D1&f=1&nofb=1");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 2,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Flogosandbrands.directory%2Fwp-content%2Fthemes%2Fdirectorypress%2Fthumbs%2FWilliams-Companies-logo.jpg&f=1&nofb=1", " Inc." });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 3,
                column: "Logo",
                value: "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Flogodownload.org%2Fwp-content%2Fuploads%2F2014%2F07%2Fsuzano-logo-1.png&f=1&nofb=1");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 4,
                column: "Logo",
                value: "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Feveripedia-storage.s3-accelerate.amazonaws.com%2FProfilePics%2F83065__29332.png&f=1&nofb=1");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 5,
                column: "Logo",
                value: "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fmms.businesswire.com%2Fmedia%2F20150721005847%2Fen%2F474552%2F5%2FTEGNA_Logo.jpg&f=1&nofb=1");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 6,
                column: "Logo",
                value: "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmma.prnewswire.com%2Fmedia%2F476403%2Fthe_timken_company_timkensteel_corporation_logo.jpg%3Fp%3Dpublish%26w%3D950&f=1&nofb=1");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 7,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.Uu1GrEpm9v2YGCNB0iRmkwHaHa%26pid%3DApi&f=1", "Tesla, Inc." });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 8,
                column: "Logo",
                value: "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.cbj.ca%2Fwp-content%2Fuploads%2F2021%2F01%2Ftransglobe-energy-corporation-announces-its-2021-capital-budget.jpg&f=1&nofb=1");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 9,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.wHxnsGXoVsXXmYLj_tAmSgHaHa%26pid%3DApi&f=1", "Mogo Inc." });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 10,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.marketbeat.com%2Flogos%2Fenstar-group-ltd-logo.png&f=1&nofb=1", "Enstar Group" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 1,
                column: "Logo",
                value: "https://api.polygon.io/v1/reference/company-branding/d3d3Lmx1bWVuLmNvbQ/images/2022-01-10_logo.png");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 2,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://api.polygon.io/v1/reference/company-branding/d3d3LndpbGxpYW1zLmNvbQ/images/2022-01-10_logo.png", "Williams Companies Inc." });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 3,
                column: "Logo",
                value: "https://api.polygon.io/v1/reference/company-branding/d3d3LnN1emFuby5jb20uYnI/images/2022-01-10_logo.png");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 4,
                column: "Logo",
                value: "https://api.polygon.io/v1/reference/company-branding/d3d3LmludHVpdC5jb20/images/2022-01-10_logo.svg");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 5,
                column: "Logo",
                value: "https://api.polygon.io/v1/reference/company-branding/d3d3LnRlZ25hLmNvbQ/images/2022-01-10_logo.png");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 6,
                column: "Logo",
                value: "https://api.polygon.io/v1/reference/company-branding/d3d3LnRpbWtlbnN0ZWVsLmNvbQ/images/2022-01-10_icon.jpeg");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 7,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://api.polygon.io/v1/reference/company-branding/d3d3LnRlc2xhLmNvbQ/images/2022-01-10_logo.svg", "Tesla, Inc. Common Stock" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 8,
                column: "Logo",
                value: "https://api.polygon.io/v1/reference/company-branding/d3d3LnRyYW5zLWdsb2JlLmNvbQ/images/2022-01-10_logo.svg");

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 9,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://api.polygon.io/v1/reference/company-branding/d3d3Lm1vZ28uY2E/images/2022-01-10_logo.png", "Mogo Inc. Common Shares" });

            migrationBuilder.UpdateData(
                table: "Ticketer",
                keyColumn: "TicketerId",
                keyValue: 10,
                columns: new[] { "Logo", "Name" },
                values: new object[] { "https://api.polygon.io/v1/reference/company-branding/d3d3LmVuc3Rhcmdyb3VwLmNvbQ/images/2022-01-10_logo.png", "Enstar Group Limited Depository" });
        }
    }
}
