using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Models;
namespace ProyectoCrud.DAL.BD_Context;

public partial class BdMilesCarRentalContext : DbContext
{
    public BdMilesCarRentalContext()
    {
    }

    public BdMilesCarRentalContext(DbContextOptions<BdMilesCarRentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<IdType> IdTypes { get; set; }

    public virtual DbSet<Preference> Preferences { get; set; }

    public virtual DbSet<PreferenceClient> PreferenceClients { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdCar);

            entity.ToTable("CAR");

            entity.Property(e => e.IdCar).HasColumnName("ID_CAR");
            entity.Property(e => e.Asset).HasColumnName("ASSET");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("COLOR");
            entity.Property(e => e.Milleage).HasColumnName("MILLEAGE");
            entity.Property(e => e.Model).HasColumnName("MODEL");
            entity.Property(e => e.Tuition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TUITION");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.ToTable("CLIENT");

            entity.Property(e => e.IdClient)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_CLIENT");
            entity.Property(e => e.AddressClient)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_CLIENT");
            entity.Property(e => e.AgeClient).HasColumnName("AGE_CLIENT");
            entity.Property(e => e.BirthdateClient).HasColumnName("BIRTHDATE_CLIENT");
            entity.Property(e => e.City)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.FirstNameClient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME_CLIENT");
            entity.Property(e => e.FirstSurnameClient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRST_SURNAME_CLIENT");
            entity.Property(e => e.GenderClient)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GENDER_CLIENT");
            entity.Property(e => e.PhoneClient)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PHONE_CLIENT");
            entity.Property(e => e.SecondNameClient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SECOND_NAME_CLIENT");
            entity.Property(e => e.SecondSurnameClient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SECOND_SURNAME_CLIENT");
            entity.Property(e => e.TypeidId).HasColumnName("TYPEID_ID");

            entity.HasOne(d => d.oIdType).WithMany(p => p.ICClients)
                .HasForeignKey(d => d.TypeidId)
                .HasConstraintName("FK_CLIENT_ID_TYPE");
        });

        modelBuilder.Entity<IdType>(entity =>
        {
            entity.HasKey(e => e.IdIdtype);

            entity.ToTable("ID_TYPE");

            entity.Property(e => e.IdIdtype).HasColumnName("ID_IDTYPE");
            entity.Property(e => e.NameIdType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME_ID_TYPE");
        });

        modelBuilder.Entity<Preference>(entity =>
        {
            entity.HasKey(e => e.IdPreference);

            entity.ToTable("PREFERENCE");

            entity.Property(e => e.IdPreference).HasColumnName("ID_PREFERENCE");
            entity.Property(e => e.Preference1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PREFERENCE");
        });

        modelBuilder.Entity<PreferenceClient>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PREFERENCE_CLIENT");

            entity.Property(e => e.IdClient)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_CLIENT");
            entity.Property(e => e.IdPreferenceType).HasColumnName("ID_PREFERENCE_TYPE");

            entity.HasOne(d => d.oClient).WithMany()
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PREFERENCE_CLIENT_CLIENT");

            entity.HasOne(d => d.oPreference).WithMany()
                .HasForeignKey(d => d.IdPreferenceType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PREFERENCE_CLIENT_PREFERENCE");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.IdReservation);

            entity.ToTable("RESERVATION");

            entity.Property(e => e.IdReservation).HasColumnName("ID_RESERVATION");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.DateReservation).HasColumnName("DATE_RESERVATION");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("END_DATE");
            entity.Property(e => e.IdCar).HasColumnName("ID_CAR");
            entity.Property(e => e.IdClient)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_CLIENT");
            entity.Property(e => e.IdUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_USER");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PAYMENT_MODE");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("START_DATE");
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("STATE");

            entity.HasOne(d => d.oCar).WithMany(p => p.OReservations)
                .HasForeignKey(d => d.IdCar)
                .HasConstraintName("FK_RESERVATION_CAR");

            entity.HasOne(d => d.oClient).WithMany(p => p.ICReservations)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_RESERVATION_CLIENT");

            entity.HasOne(d => d.oUser).WithMany(p => p.ICReservations)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_RESERVATION_USER");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("ROLE");

            entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ROLE_NAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("USER");

            entity.Property(e => e.IdUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_USER");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(500)
                .HasColumnName("PASSWORDHASH");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PHONE");

            entity.HasOne(d => d.oRole).WithMany(p => p.ICUser)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_USER_ROLE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
