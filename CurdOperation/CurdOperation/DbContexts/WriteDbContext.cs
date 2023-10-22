using System;
using System.Collections.Generic;
using CurdOperation.Models.Write;
using Microsoft.EntityFrameworkCore;

namespace CurdOperation.DbContexts;

public partial class WriteDbContext : DbContext
{
    public WriteDbContext()
    {
    }

    public WriteDbContext(DbContextOptions<WriteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=IFTEKHAR\\SQLEXPRESS;Initial Catalog = ProductDB;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;ApplicationIntent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.ToTable("tblUser");

            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("userName");
            entity.Property(e => e.PassWord)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("passWord");
            entity.Property(e => e.UserId)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("userId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
