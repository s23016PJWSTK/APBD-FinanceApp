using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Server.Models
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<UserToDb> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<WatchList_Ticketer> WatchList_Ticketers { get; set; }
        public DbSet<TicketerToDb> Ticketers { get; set; }
        public DbSet<TicketerDataToDb> TicketerDatas { get; set; }
        public FinanceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToDb>(e =>
            {
                e.ToTable("User");
                e.HasKey(e => e.Email);
                e.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<WatchList>(e =>
            {
                e.ToTable("WatchList");
                e.HasKey(e => e.WatchListId);

                e.HasOne(e => e.User)
                .WithMany(e => e.WatchLists)
                .HasForeignKey(e => e.UserEmail)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<WatchList_Ticketer>(e =>
            {
                e.ToTable("WatchList_Ticketer");
                e.HasKey(e => new { e.TicketerId, e.WatchListId });

                e.HasOne(e => e.Ticketer)
                .WithMany(e => e.WatchList_Ticketers)
                .HasForeignKey(e => e.TicketerId)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(e => e.WatchList)
                .WithMany(e => e.WatchList_Ticketers)
                .HasForeignKey(e => e.WatchListId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TicketerToDb>(e =>
            {
                e.ToTable("Ticketer");
                e.HasKey(e => e.TicketerId);
                e.Property(e => e.Logo).IsRequired();
                e.Property(e => e.Symbol).HasMaxLength(10).IsRequired();
                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.Property(e => e.Sector).HasMaxLength(30).IsRequired();
                e.Property(e => e.Country).HasMaxLength(40).IsRequired();
                e.Property(e => e.CEO).HasMaxLength(40).IsRequired();

                e.HasData(
                    new TicketerToDb
                    {
                        TicketerId = 1,
                        Symbol = "LUMN",
                        Name = "Lumen Technologies, Inc.",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3Lmx1bWVuLmNvbQ/images/2022-01-10_logo.png",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 2,
                        Symbol = "WMB",
                        Name = "Williams Companies Inc.",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LndpbGxpYW1zLmNvbQ/images/2022-01-10_logo.png",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 3,
                        Symbol = "SUZ",
                        Name = "Suzano S.A. American Depositary Shares",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LnN1emFuby5jb20uYnI/images/2022-01-10_logo.png",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 4,
                        Symbol = "INTU",
                        Name = "Intuit Inc",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LmludHVpdC5jb20/images/2022-01-10_logo.svg",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 5,
                        Symbol = "TGNA",
                        Name = "TEGNA Inc.",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LnRlZ25hLmNvbQ/images/2022-01-10_logo.png",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 6,
                        Symbol = "TMST",
                        Name = "TIMKENSTEEL CORPORATION",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LnRpbWtlbnN0ZWVsLmNvbQ/images/2022-01-10_icon.jpeg",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 7,
                        Symbol = "TSLA",
                        Name = "Tesla, Inc. Common Stock",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LnRlc2xhLmNvbQ/images/2022-01-10_logo.svg",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 8,
                        Symbol = "TGA",
                        Name = "Transglobe Energy Corp",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LnRyYW5zLWdsb2JlLmNvbQ/images/2022-01-10_logo.svg",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 9,
                        Symbol = "MOGO",
                        Name = "Mogo Inc. Common Shares",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3Lm1vZ28uY2E/images/2022-01-10_logo.png",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 10,
                        Symbol = "ESGRO",
                        Name = "Enstar Group Limited Depository",
                        Logo = "https://api.polygon.io/v1/reference/company-branding/d3d3LmVuc3Rhcmdyb3VwLmNvbQ/images/2022-01-10_logo.png",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    }
                );
            });

            modelBuilder.Entity<TicketerDataToDb>(e =>
            {
                e.ToTable("TicketerData");
                e.HasKey(e => new { e.TicketerId, e.Date });
                e.Property(e => e.Close).IsRequired();
                e.Property(e => e.Highest).IsRequired();
                e.Property(e => e.Lowest).IsRequired();
                e.Property(e => e.NumberOfTransactons).IsRequired();
                e.Property(e => e.Open).IsRequired();
                e.Property(e => e.OTC).IsRequired();
                e.Property(e => e.Timestamp).IsRequired();
                e.Property(e => e.Volume).IsRequired();
                e.Property(e => e.VolumeWeighted).IsRequired();

                e.HasOne(e => e.Ticketer)
                .WithMany(e => e.TicketerDatas)
                .HasForeignKey(e => e.TicketerId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
