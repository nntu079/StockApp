﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApp.Data;

#nullable disable

namespace StockApp.Migrations
{
    [DbContext(typeof(StockAppContext))]
    [Migration("20240218100035_time1")]
    partial class time1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockApp.Data.Industry", b =>
                {
                    b.Property<Guid>("IndustryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IndustryId")
                        .HasName("PK__Industri__808DEDCC9FC2A857");

                    b.HasIndex(new[] { "Name" }, "UQ__Industri__737584F6FADF0965")
                        .IsUnique();

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("StockApp.Data.IndustryStock", b =>
                {
                    b.Property<Guid>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("IndustryId");

                    b.HasIndex("StockId");

                    b.ToTable("IndustryStocks");
                });

            modelBuilder.Entity("StockApp.Data.Stock", b =>
                {
                    b.Property<Guid>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("StockId")
                        .HasName("PK__Stocks__2C83A9C208180A4D");

                    b.HasIndex(new[] { "Symbol" }, "UQ__Stocks__B7CC3F0176D4C920")
                        .IsUnique();

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockApp.Data.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CC4CBB8AF620");

                    b.HasIndex(new[] { "Username" }, "UQ__Users__536C85E4A44CBD1C")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534ADC48351")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StockApp.Data.Watchlist", b =>
                {
                    b.Property<Guid>("WatchlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WatchlistId")
                        .HasName("PK__Watchlis__48DE55CB96392774");

                    b.HasIndex("UserId");

                    b.ToTable("Watchlists");
                });

            modelBuilder.Entity("StockApp.Data.WatchlistStock", b =>
                {
                    b.Property<Guid>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WatchlistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("StockId");

                    b.HasIndex("WatchlistId");

                    b.ToTable("WatchlistStocks");
                });

            modelBuilder.Entity("StockApp.Data.IndustryStock", b =>
                {
                    b.HasOne("StockApp.Data.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId")
                        .IsRequired()
                        .HasConstraintName("FK__IndustryS__Indus__4CA06362");

                    b.HasOne("StockApp.Data.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .IsRequired()
                        .HasConstraintName("FK__IndustryS__Stock__4D94879B");

                    b.Navigation("Industry");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.Data.Watchlist", b =>
                {
                    b.HasOne("StockApp.Data.User", "User")
                        .WithMany("Watchlists")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Watchlist__UserI__3F466844");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StockApp.Data.WatchlistStock", b =>
                {
                    b.HasOne("StockApp.Data.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .IsRequired()
                        .HasConstraintName("FK__Watchlist__Stock__4AB81AF0");

                    b.HasOne("StockApp.Data.Watchlist", "Watchlist")
                        .WithMany()
                        .HasForeignKey("WatchlistId")
                        .IsRequired()
                        .HasConstraintName("FK__Watchlist__Watch__49C3F6B7");

                    b.Navigation("Stock");

                    b.Navigation("Watchlist");
                });

            modelBuilder.Entity("StockApp.Data.User", b =>
                {
                    b.Navigation("Watchlists");
                });
#pragma warning restore 612, 618
        }
    }
}
