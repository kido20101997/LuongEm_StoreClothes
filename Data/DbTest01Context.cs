using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mvc_web_app.Data;

public partial class DbTest01Context : DbContext
{
    public DbTest01Context()
    {
    }

    public DbTest01Context(DbContextOptions<DbTest01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server= KIDO_NGUYEN01\\DB01;Database=DB_TEST_01;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.IdCard);

            entity.ToTable("User_Info", "sfis");

            entity.Property(e => e.IdCard)
                .ValueGeneratedNever()
                .HasColumnName("ID_Card");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Create_Time");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("Created_By");
            entity.Property(e => e.DateBrithday)
                .HasColumnType("date")
                .HasColumnName("Date_Brithday");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("Update_Time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
