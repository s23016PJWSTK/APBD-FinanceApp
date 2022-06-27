﻿// <auto-generated />
using System;
using FinanceApp.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceApp.Server.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20220627063711_seeded correct logos")]
    partial class seededcorrectlogos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinanceApp.Server.Models.TicketerDataToDb", b =>
                {
                    b.Property<int>("TicketerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Close")
                        .HasColumnType("float");

                    b.Property<double>("Highest")
                        .HasColumnType("float");

                    b.Property<double>("Lowest")
                        .HasColumnType("float");

                    b.Property<double>("NumberOfTransactons")
                        .HasColumnType("float");

                    b.Property<bool>("OTC")
                        .HasColumnType("bit");

                    b.Property<double>("Open")
                        .HasColumnType("float");

                    b.Property<int>("Timestamp")
                        .HasColumnType("int");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.Property<double>("VolumeWeighted")
                        .HasColumnType("float");

                    b.HasKey("TicketerId", "Date");

                    b.ToTable("TicketerData", (string)null);
                });

            modelBuilder.Entity("FinanceApp.Server.Models.TicketerToDb", b =>
                {
                    b.Property<int>("TicketerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketerId"), 1L, 1);

                    b.Property<string>("CEO")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TicketerId");

                    b.ToTable("Ticketer", (string)null);

                    b.HasData(
                        new
                        {
                            TicketerId = 1,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi1.wp.com%2Fwww.denverpost.com%2Fwp-content%2Fuploads%2F2020%2F09%2FLumen-Logo.png%3Ffit%3D620%252C9999px%26ssl%3D1&f=1&nofb=1",
                            Name = "Lumen Technologies, Inc.",
                            Sector = "stocks",
                            Symbol = "LUMN"
                        },
                        new
                        {
                            TicketerId = 2,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Flogosandbrands.directory%2Fwp-content%2Fthemes%2Fdirectorypress%2Fthumbs%2FWilliams-Companies-logo.jpg&f=1&nofb=1",
                            Name = " Inc.",
                            Sector = "stocks",
                            Symbol = "WMB"
                        },
                        new
                        {
                            TicketerId = 3,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Flogodownload.org%2Fwp-content%2Fuploads%2F2014%2F07%2Fsuzano-logo-1.png&f=1&nofb=1",
                            Name = "Suzano S.A. American Depositary Shares",
                            Sector = "stocks",
                            Symbol = "SUZ"
                        },
                        new
                        {
                            TicketerId = 4,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Feveripedia-storage.s3-accelerate.amazonaws.com%2FProfilePics%2F83065__29332.png&f=1&nofb=1",
                            Name = "Intuit Inc",
                            Sector = "stocks",
                            Symbol = "INTU"
                        },
                        new
                        {
                            TicketerId = 5,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fmms.businesswire.com%2Fmedia%2F20150721005847%2Fen%2F474552%2F5%2FTEGNA_Logo.jpg&f=1&nofb=1",
                            Name = "TEGNA Inc.",
                            Sector = "stocks",
                            Symbol = "TGNA"
                        },
                        new
                        {
                            TicketerId = 6,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmma.prnewswire.com%2Fmedia%2F476403%2Fthe_timken_company_timkensteel_corporation_logo.jpg%3Fp%3Dpublish%26w%3D950&f=1&nofb=1",
                            Name = "TIMKENSTEEL CORPORATION",
                            Sector = "stocks",
                            Symbol = "TMST"
                        },
                        new
                        {
                            TicketerId = 7,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.Uu1GrEpm9v2YGCNB0iRmkwHaHa%26pid%3DApi&f=1",
                            Name = "Tesla, Inc.",
                            Sector = "stocks",
                            Symbol = "TSLA"
                        },
                        new
                        {
                            TicketerId = 8,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.cbj.ca%2Fwp-content%2Fuploads%2F2021%2F01%2Ftransglobe-energy-corporation-announces-its-2021-capital-budget.jpg&f=1&nofb=1",
                            Name = "Transglobe Energy Corp",
                            Sector = "stocks",
                            Symbol = "TGA"
                        },
                        new
                        {
                            TicketerId = 9,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.wHxnsGXoVsXXmYLj_tAmSgHaHa%26pid%3DApi&f=1",
                            Name = "Mogo Inc.",
                            Sector = "stocks",
                            Symbol = "MOGO"
                        },
                        new
                        {
                            TicketerId = 10,
                            CEO = "tmp",
                            Country = "US",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.marketbeat.com%2Flogos%2Fenstar-group-ltd-logo.png&f=1&nofb=1",
                            Name = "Enstar Group",
                            Sector = "stocks",
                            Symbol = "ESGRO"
                        });
                });

            modelBuilder.Entity("FinanceApp.Server.Models.UserToDb", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("FinanceApp.Server.Models.WatchList", b =>
                {
                    b.Property<int>("WatchListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WatchListId"), 1L, 1);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WatchListId");

                    b.HasIndex("UserEmail");

                    b.ToTable("WatchList", (string)null);
                });

            modelBuilder.Entity("FinanceApp.Server.Models.WatchList_Ticketer", b =>
                {
                    b.Property<int>("TicketerId")
                        .HasColumnType("int");

                    b.Property<int>("WatchListId")
                        .HasColumnType("int");

                    b.HasKey("TicketerId", "WatchListId");

                    b.HasIndex("WatchListId");

                    b.ToTable("WatchList_Ticketer", (string)null);
                });

            modelBuilder.Entity("FinanceApp.Server.Models.TicketerDataToDb", b =>
                {
                    b.HasOne("FinanceApp.Server.Models.TicketerToDb", "Ticketer")
                        .WithMany("TicketerDatas")
                        .HasForeignKey("TicketerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticketer");
                });

            modelBuilder.Entity("FinanceApp.Server.Models.WatchList", b =>
                {
                    b.HasOne("FinanceApp.Server.Models.UserToDb", "User")
                        .WithMany("WatchLists")
                        .HasForeignKey("UserEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinanceApp.Server.Models.WatchList_Ticketer", b =>
                {
                    b.HasOne("FinanceApp.Server.Models.TicketerToDb", "Ticketer")
                        .WithMany("WatchList_Ticketers")
                        .HasForeignKey("TicketerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceApp.Server.Models.WatchList", "WatchList")
                        .WithMany("WatchList_Ticketers")
                        .HasForeignKey("WatchListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticketer");

                    b.Navigation("WatchList");
                });

            modelBuilder.Entity("FinanceApp.Server.Models.TicketerToDb", b =>
                {
                    b.Navigation("TicketerDatas");

                    b.Navigation("WatchList_Ticketers");
                });

            modelBuilder.Entity("FinanceApp.Server.Models.UserToDb", b =>
                {
                    b.Navigation("WatchLists");
                });

            modelBuilder.Entity("FinanceApp.Server.Models.WatchList", b =>
                {
                    b.Navigation("WatchList_Ticketers");
                });
#pragma warning restore 612, 618
        }
    }
}
