﻿// <auto-generated />
using System;
using Graph.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Graph.DataAccess.Migrations
{
    [DbContext(typeof(CryptoAssetsDbContext))]
    [Migration("20221016080451_UserEntityChanges")]
    partial class UserEntityChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Graph.Domain.Entities.Common.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("TelegramUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Graph.Domain.Entities.Common.UserSettings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<TimeSpan?>("SleepTimeEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("SleepTimeStart")
                        .HasColumnType("time");

                    b.Property<bool>("UsePeriodicNotifications")
                        .HasColumnType("bit");

                    b.Property<bool>("UseSleepHours")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersSettings");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.CryptoAsset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoinGeckoAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CryptoAssets");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.CryptoTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(6)
                        .HasColumnType("decimal(6)");

                    b.Property<decimal>("BuyPrice")
                        .HasPrecision(6)
                        .HasColumnType("decimal(6)");

                    b.Property<long>("CryptoAssetId")
                        .HasColumnType("bigint");

                    b.Property<long>("PortfolioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CryptoAssetId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("CryptoTransactions");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.Portfolio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.UsersFollowingCryptoAssets", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("CryptoAssetId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "CryptoAssetId");

                    b.HasIndex("CryptoAssetId");

                    b.ToTable("UsersFollowingCryptoAssets");
                });

            modelBuilder.Entity("Graph.Domain.Entities.Common.UserSettings", b =>
                {
                    b.HasOne("Graph.Domain.Entities.Common.User", "User")
                        .WithOne("Settings")
                        .HasForeignKey("Graph.Domain.Entities.Common.UserSettings", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.CryptoTransaction", b =>
                {
                    b.HasOne("Graph.Domain.Entities.CryptoAssets.CryptoAsset", "CryptoAsset")
                        .WithMany("CryptoTransactions")
                        .HasForeignKey("CryptoAssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Graph.Domain.Entities.CryptoAssets.Portfolio", "Portfolio")
                        .WithMany("CryptoTransactions")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CryptoAsset");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.Portfolio", b =>
                {
                    b.HasOne("Graph.Domain.Entities.Common.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.UsersFollowingCryptoAssets", b =>
                {
                    b.HasOne("Graph.Domain.Entities.CryptoAssets.CryptoAsset", "CryptoAsset")
                        .WithMany("Followers")
                        .HasForeignKey("CryptoAssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Graph.Domain.Entities.Common.User", "User")
                        .WithMany("FollowedCryptoAssets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CryptoAsset");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Graph.Domain.Entities.Common.User", b =>
                {
                    b.Navigation("FollowedCryptoAssets");

                    b.Navigation("Portfolios");

                    b.Navigation("Settings")
                        .IsRequired();
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.CryptoAsset", b =>
                {
                    b.Navigation("CryptoTransactions");

                    b.Navigation("Followers");
                });

            modelBuilder.Entity("Graph.Domain.Entities.CryptoAssets.Portfolio", b =>
                {
                    b.Navigation("CryptoTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}