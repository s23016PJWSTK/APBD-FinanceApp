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
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi1.wp.com%2Fwww.denverpost.com%2Fwp-content%2Fuploads%2F2020%2F09%2FLumen-Logo.png%3Ffit%3D620%252C9999px%26ssl%3D1&f=1&nofb=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 2,
                        Symbol = "WMB",
                        Name = " Inc.",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Flogosandbrands.directory%2Fwp-content%2Fthemes%2Fdirectorypress%2Fthumbs%2FWilliams-Companies-logo.jpg&f=1&nofb=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 3,
                        Symbol = "SUZ",
                        Name = "Suzano S.A. American Depositary Shares",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Flogodownload.org%2Fwp-content%2Fuploads%2F2014%2F07%2Fsuzano-logo-1.png&f=1&nofb=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 4,
                        Symbol = "INTU",
                        Name = "Intuit Inc",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Feveripedia-storage.s3-accelerate.amazonaws.com%2FProfilePics%2F83065__29332.png&f=1&nofb=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 5,
                        Symbol = "TGNA",
                        Name = "TEGNA Inc.",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fmms.businesswire.com%2Fmedia%2F20150721005847%2Fen%2F474552%2F5%2FTEGNA_Logo.jpg&f=1&nofb=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 6,
                        Symbol = "TMST",
                        Name = "TIMKENSTEEL CORPORATION",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmma.prnewswire.com%2Fmedia%2F476403%2Fthe_timken_company_timkensteel_corporation_logo.jpg%3Fp%3Dpublish%26w%3D950&f=1&nofb=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 7,
                        Symbol = "TSLA",
                        Name = "Tesla, Inc.",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.Uu1GrEpm9v2YGCNB0iRmkwHaHa%26pid%3DApi&f=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 8,
                        Symbol = "TGA",
                        Name = "Transglobe Energy Corp",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.cbj.ca%2Fwp-content%2Fuploads%2F2021%2F01%2Ftransglobe-energy-corporation-announces-its-2021-capital-budget.jpg&f=1&nofb=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 9,
                        Symbol = "MOGO",
                        Name = "Mogo Inc.",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.wHxnsGXoVsXXmYLj_tAmSgHaHa%26pid%3DApi&f=1",
                        Sector = "stocks",
                        Country = "US",
                        CEO = "tmp"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 10,
                        Symbol = "ESGRO",
                        Name = "Enstar Group",
                        Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.marketbeat.com%2Flogos%2Fenstar-group-ltd-logo.png&f=1&nofb=1",
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
