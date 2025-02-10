using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryDolgozat.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.Genre)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PublishedYear).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
