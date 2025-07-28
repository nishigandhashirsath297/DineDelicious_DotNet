using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DineDelicious.Models;

public partial class RestaurantDbContext : DbContext
{
    public RestaurantDbContext()
    {
    }

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bills__3214EC07833C5160");

            entity.Property(e => e.GeneratedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.Bills)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bills__OrderId__5070F446");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07E869D044");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MenuItem__3214EC0720E815C3");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07A4185479");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__44FF419A");

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__TableId__440B1D61");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07EFA6AED2");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__MenuI__4CA06362");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__4BAC3F29");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tables__3214EC072B99D4B7");

            entity.HasIndex(e => e.TableNumber, "UQ__Tables__E8E0DB52F8960527").IsUnique();

            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC077DB425CB");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4EACFA743").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
