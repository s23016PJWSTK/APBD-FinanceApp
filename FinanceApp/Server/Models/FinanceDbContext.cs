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
        public DbSet<ArticleToDb> Articles { get; set; }
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
                        Logo = "https://s24.q4cdn.com/287068338/files/design/lumen-logo-blue-black.png",
                        Sector = "fiber infrastructure",
                        Country = "US",
                        CEO = "Jeffrey Storey"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 2,
                        Symbol = "WMB",
                        Name = "Williams Companies Inc.",
                        Logo = "https://g.foolcdn.com/art/companylogos/medium/WMB.png",
                        Sector = "Utilities",
                        Country = "US",
                        CEO = "Alan S. Armstrong"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 3,
                        Symbol = "SUZ",
                        Name = "Suzano S.A.",
                        Logo = "https://suzano-site.s3-sa-east-1.amazonaws.com/assets/img/logo-suzano-rodape.png",
                        Sector = "bio-based materials",
                        Country = "US",
                        CEO = "Walter Schalka"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 4,
                        Symbol = "INTU",
                        Name = "Intuit Inc",
                        Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Intuit_Logo.svg/1200px-Intuit_Logo.svg.png",
                        Sector = "financial management",
                        Country = "US",
                        CEO = "Sasan K. Goodarzi"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 5,
                        Symbol = "TGNA",
                        Name = "TEGNA Inc.",
                        Logo = "https://res.cloudinary.com/etoro/image/fetch/w_1.5/https://etoro-cdn.etorostatic.com/market-avatars/6873/150x150.png",
                        Sector = "media provider",
                        Country = "US",
                        CEO = "Dave Lougee"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 6,
                        Symbol = "TMST",
                        Name = "TIMKENSTEEL CORPORATION",
                        Logo = "https://www.timkensteel.com/img/timkenSteelShare.jpg",
                        Sector = "basic materials",
                        Country = "US",
                        CEO = "Michael Williams"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 7,
                        Symbol = "TSLA",
                        Name = "Tesla, Inc.",
                        Logo = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Tesla_logo.png",
                        Sector = "Automotive, Energy Generation",
                        Country = "US",
                        CEO = "Elon Musk"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 8,
                        Symbol = "TGA",
                        Name = "Transglobe Energy Corp",
                        Logo = "https://s24.q4cdn.com/107256193/files/design/transglobe-logo.svg",
                        Sector = "oil exploration",
                        Country = "US",
                        CEO = "Randy Neely"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 9,
                        Symbol = "MOGO",
                        Name = "Mogo Inc.",
                        Logo = "https://static.seekingalpha.com/uploads/2020/1/13/22464021-15789554209817338.jpg",
                        Sector = "information",
                        Country = "US",
                        CEO = "David Feller"
                    },
                    new TicketerToDb
                    {
                        TicketerId = 10,
                        Symbol = "ESGRO",
                        Name = "Enstar Group",
                        Logo = "https://s3-symbol-logo.tradingview.com/enstar-group--600.png",
                        Sector = "insurance",
                        Country = "US",
                        CEO = "Paul J. O'Shea"
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

            modelBuilder.Entity<ArticleToDb>(e =>
            {
                e.ToTable("Article");
                e.HasKey(e => new { e.TicketerId, e.published_utc });
                e.Property(e => e.title).IsRequired();
                e.Property(e => e.article_url).IsRequired();
                e.Property(e => e.name).IsRequired();

                e.HasOne(e => e.Ticketer)
                .WithMany(e => e.Articles)
                .HasForeignKey(e => e.TicketerId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
