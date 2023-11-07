using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure;

public class Context : IdentityDbContext
{
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<ContactDetail> ContactDetails { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationPosition> ReservationPositions { get; set; }

    public Context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Device>()
               .HasOne(d => d.DeviceType)
               .WithMany(dt => dt.Devices)
               .HasForeignKey(d => d.DeviceTypeId);

        builder.Entity<DeviceType>()
               .HasOne(dt => dt.Node)
               .WithOne(n => n.DeviceType)
               .HasForeignKey<DeviceType>(dt => dt.NodetId);

        builder.Entity<ReservationPosition>()
               .HasOne(rp => rp.Device)
               .WithMany(d => d.Positions)
               .HasForeignKey(rp => rp.DeviceId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ReservationPosition>()
               .HasOne(rp => rp.DeviceType)
               .WithMany(dt => dt.Positions)
               .HasForeignKey(rp => rp.DeviceTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ReservationPosition>()
               .HasOne(rp => rp.Reservation)
               .WithMany(r => r.Positions)
               .HasForeignKey(rp => rp.ReservationId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ContactDetail>()
               .HasOne(cd => cd.Adress)
               .WithOne(a => a.ContactDetail)
               .HasForeignKey<ContactDetail>(cd => cd.AdressId);

        builder.Entity<Node>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name);
            entity.HasOne(x => x.ParentNode)
                .WithMany(x => x.ChildNodes)
                .HasForeignKey(x => x.ParentNodeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

    }
}
