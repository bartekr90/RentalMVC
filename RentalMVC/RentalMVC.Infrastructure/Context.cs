using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain;
using RentalMVC.Domain.Model.Entity;
using RentalMVC.Domain.Model.Entity.DeviceEntities;
using RentalMVC.Domain.Model.Entity.UserEntities;
using System.Data;

namespace RentalMVC.Infrastructure;

public class Context : IdentityDbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ContactData> ContactDatas { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Lessor> Lessors { get; set; }
    public DbSet<UserDetail> UserDetails { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationPosition> ReservationPositions { get; set; }

    public Context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Node>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(x => x.Name).IsRequired();
            entity.Property(x => x.CreatorId).IsRequired();

            entity.HasIndex(e => e.RentalId);
            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.DeviceTypeId).IsUnique();
            entity.HasIndex(e => e.ParentNodeId);

            entity.HasOne(d => d.Rental)
            .WithMany(p => p.Nodes)
            .HasForeignKey(d => d.RentalId)
            .IsRequired();

            entity.HasOne(x => x.ParentNode)
            .WithMany(x => x.ChildNodes)
            .HasForeignKey(x => x.ParentNodeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.DeviceType)
              .WithOne(dt => dt.Node)
              .HasForeignKey<Node>(n => n.DeviceTypeId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<DeviceType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(x => x.Name).IsRequired();
            entity.Property(x => x.CreatorId).IsRequired();
            entity.Property(x => x.FullPath).IsRequired();

            entity.HasIndex(e => e.RentalId);
            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.NodeId).IsUnique();

            entity.HasOne(d => d.Rental)
                .WithMany(p => p.Types)
                .HasForeignKey(d => d.RentalId)
                .IsRequired();

            entity.HasOne(d => d.Node)
                .WithOne(p => p.DeviceType)
                .HasForeignKey<DeviceType>(d => d.NodeId)
                .IsRequired();

            entity.HasMany(d => d.Devices)
                .WithOne(p => p.DeviceType)
                .HasForeignKey(d => d.DeviceTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(d => d.Positions)
                .WithOne(p => p.DeviceType)
                .HasForeignKey(d => d.DeviceTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Device>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(x => x.Name).IsRequired();
            entity.Property(x => x.CreatorId).IsRequired();
            entity.Property(x => x.SerialNr).IsRequired();

            entity.HasIndex(e => e.RentalId);
            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.DeviceTypeId);

            entity.HasOne(d => d.Rental)
                .WithMany(p => p.Devices)
                .HasForeignKey(d => d.RentalId)
                .IsRequired();

            entity.HasOne(d => d.DeviceType)
                .WithMany(p => p.Devices)
                .HasForeignKey(d => d.DeviceTypeId)
                .IsRequired();

            entity.HasMany(d => d.Positions)
                .WithOne(p => p.Device)
                .HasForeignKey(p => p.DeviceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(e => e.CreatorId).IsRequired();

            entity.HasIndex(e => e.CreatorId).IsUnique();
            entity.HasIndex(e => e.LessorId).IsUnique();
            entity.HasIndex(e => e.ClientId).IsUnique();
            entity.HasIndex(e => e.EmployeeId).IsUnique();

            entity.HasOne(d => d.Client)
                .WithOne(p => p.UserDetail)
                .HasForeignKey<UserDetail>(d => d.ClientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Lessor)
                .WithOne(p => p.UserDetail)
                .HasForeignKey<UserDetail>(d => d.LessorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Employee)
                .WithOne(p => p.UserDetail)
                .HasForeignKey<UserDetail>(d => d.EmployeeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Lessor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(e => e.CreatorId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.UserId).IsRequired();

            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.MainContactDataId).IsUnique();
            entity.HasIndex(e => e.UserId).IsUnique();
            entity.HasIndex(e => e.RentalId).IsUnique();
            entity.HasIndex(e => e.UserDetailId).IsUnique();

            entity.HasOne(d => d.Rental)
                .WithOne()
                .HasForeignKey<Lessor>(d => d.RentalId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            entity.HasOne(d => d.UserDetail)
                .WithOne()
                .HasForeignKey<Lessor>(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        builder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(e => e.CreatorId).IsRequired();
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.Name).IsRequired();

            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.MainContactDataId).IsUnique();
            entity.HasIndex(e => e.UserId).IsUnique();
            entity.HasIndex(e => e.RentalId);
            entity.HasIndex(e => e.UserDetailId).IsUnique();

            entity.HasOne(d => d.Rental)
             .WithMany(p => p.Employees)
             .HasForeignKey(d => d.RentalId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired();

            entity.HasOne(d => d.UserDetail)
                .WithOne()
                .HasForeignKey<Employee>(d => d.UserDetailId)
                .IsRequired();
        });

        builder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(e => e.CreatorId).IsRequired();
            entity.Property(e => e.Name).IsRequired();

            entity.HasIndex(e => e.CreatorId).IsUnique();
            entity.HasIndex(e => e.MainContactDataId).IsUnique();
            entity.HasIndex(e => e.UserDetailId).IsUnique();

            entity.HasOne(d => d.UserDetail)
                .WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasMany(d => d.Positions)
                .WithOne(p => p.Client)
                .HasForeignKey(d => d.ClientId)
                .IsRequired(false);

            entity.HasMany(d => d.Reservations)
                .WithOne(p => p.Client)
                .HasForeignKey(d => d.ClientId)
                .IsRequired(false);
        });

        builder.Entity<ContactData>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(e => e.CreatorId).IsRequired();
            entity.Property(e => e.NamePart1).IsRequired();
            entity.Property(e => e.NamePart2).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PhoneNr).IsRequired();

            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.AddressId);
        });

        builder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(e => e.CreatorId).IsRequired();
            entity.Property(e => e.AddressPartOne).IsRequired();
            entity.Property(e => e.AddressPartTwo).IsRequired();
            entity.Property(e => e.City).IsRequired();
            entity.Property(e => e.PostalCode).IsRequired();
            
            entity.HasIndex(e => e.CreatorId);
        });

        builder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CreatorId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.LessorId).IsRequired();
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);

            entity.HasIndex(e => e.MainContactDataId).IsUnique();
            entity.HasIndex(e => e.CreatedAt).IsUnique();
            entity.HasIndex(e => e.LessorId).IsUnique();

            entity.HasOne(d => d.Lessor)
                .WithOne(p => p.Rental)
                .HasForeignKey<Rental>(d => d.LessorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasMany(d => d.Employees)
                .WithOne(p => p.Rental)
                .HasForeignKey(d => d.RentalId)
                .IsRequired(false);

            entity.HasMany(d => d.Devices)
                .WithOne(p => p.Rental)
                .HasForeignKey(d => d.RentalId)
                .IsRequired(false);

            entity.HasMany(d => d.Types)
                .WithOne(p => p.Rental)
                .HasForeignKey(d => d.RentalId)
                .IsRequired(false);

            entity.HasMany(d => d.Nodes)
                .WithOne(p => p.Rental)
                .HasForeignKey(d => d.RentalId)
                .IsRequired(false);

            entity.HasMany(d => d.Positions)
                .WithOne(p => p.Rental)
                .HasForeignKey(d => d.RentalId)
                .IsRequired(false);

            entity.HasMany(d => d.Reservations)
                .WithOne(p => p.Rental)
                .HasForeignKey(d => d.RentalId)
                .IsRequired(false);
        });

        builder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CreatorId).IsRequired();
            entity.Property(e => e.ClientName).IsRequired();
            entity.Property(e => e.RentalName).IsRequired();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Comments).IsRequired(false);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);

            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.RentalId);
            entity.HasIndex(e => e.ClientId);

            entity.HasOne(d => d.Rental)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasMany(d => d.Positions)
                .WithOne(p => p.Reservation)
                .HasForeignKey(d => d.ReservationId);
        });
        builder.Entity<ReservationPosition>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DeletedBy).IsRequired(false);
            entity.Property(e => e.ModifiedBy).IsRequired(false);
            entity.Property(e => e.CreatorId).IsRequired();

            entity.HasIndex(e => e.CreatorId);
            entity.HasIndex(e => e.ClientId);
            entity.HasIndex(e => e.RentalId);
            entity.HasIndex(e => e.ReservationId);
            entity.HasIndex(e => e.DeviceId);
            entity.HasIndex(e => e.DeviceTypeId);

            entity.HasOne(d => d.Rental)
                .WithMany(p => p.Positions)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.Device)
                .WithMany(p => p.Positions)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.Reservation)
                .WithMany(p => p.Positions)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.DeviceType)
                .WithMany(p => p.Positions)
                .HasForeignKey(d => d.DeviceTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Positions)
                .HasForeignKey(d => d.ClientId)
            .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        });

        builder.Entity<IdentityRole>().HasData(
            Enum.GetValues(typeof(Role))
                .Cast<Role>()
                .Select(e => new IdentityRole
                {
                    Id = e.ToString(),
                    Name = e.ToString(),
                    NormalizedName = e.ToString().ToUpper()
                })
        );
    }
}
