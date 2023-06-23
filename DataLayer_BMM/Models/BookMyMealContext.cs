using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL_BMM.Models;

public partial class BookMyMealContext : DbContext
{
    public BookMyMealContext()
    {
    }

    public BookMyMealContext(DbContextOptions<BookMyMealContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP301;Database=BookMyMeal;Trusted_Connection=True; Encrypt = False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__35AAE1F802B6DA42");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("Booking_id");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.EidNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Eid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Eid__3C69FB99");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__Employee__C1971B538871DBD8");

            entity.ToTable("Employee");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Token).IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
