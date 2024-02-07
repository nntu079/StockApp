using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StockApp.Data;

public partial class StockAppContext : DbContext
{
    public StockAppContext()
    {
    }

    public StockAppContext(DbContextOptions<StockAppContext> options)
        : base(options)
    {
    }
    //virtual => cho phép ghi đè lại thuộc tính này
    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<IndustryStock> IndustryStocks { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Watchlist> Watchlists { get; set; }

    public virtual DbSet<WatchlistStock> WatchlistStocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.IndustryId).HasName("PK__Industri__808DEDCC9FC2A857");

            entity.HasIndex(e => e.Name, "UQ__Industri__737584F6FADF0965").IsUnique();

            entity.Property(e => e.IndustryId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IndustryStock>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Industry).WithMany()
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IndustryS__Indus__4CA06362");

            entity.HasOne(d => d.Stock).WithMany()
                .HasForeignKey(d => d.StockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IndustryS__Stock__4D94879B");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Stocks__2C83A9C208180A4D");

            entity.HasIndex(e => e.Symbol, "UQ__Stocks__B7CC3F0176D4C920").IsUnique();

            entity.Property(e => e.StockId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Change).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Industry)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sector)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CBB8AF620");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4A44CBD1C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534ADC48351").IsUnique();

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Watchlist>(entity =>
        {
            entity.HasKey(e => e.WatchlistId).HasName("PK__Watchlis__48DE55CB96392774");

            entity.Property(e => e.WatchlistId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Watchlists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Watchlist__UserI__3F466844");
        });

        modelBuilder.Entity<WatchlistStock>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Stock).WithMany()
                .HasForeignKey(d => d.StockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Watchlist__Stock__4AB81AF0");

            entity.HasOne(d => d.Watchlist).WithMany()
                .HasForeignKey(d => d.WatchlistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Watchlist__Watch__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
