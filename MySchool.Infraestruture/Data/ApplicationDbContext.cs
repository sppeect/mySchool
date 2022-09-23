using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities.School;
using MySchool.Domain.Entities.Student;
using MySchool.Domain.Entities.Teacher;

namespace MySchool.Infraestruture.Data;
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Schools> Schools { get; set; }
    public DbSet<ClassRoom> ClassRoom { get; set; }
    public DbSet<ClassTypes> ClassTypes { get; set; }
    public DbSet<Students> Students { get; set; }
    public DbSet<StudentsClassRoom> StudentsClassRoom { get; set; }
    public DbSet<StudentsNotes> StudentsNotes { get; set; }
    public DbSet<TeachersClassRooms> TeachersClassRooms { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        #region Schools(ValueObjects)
        builder.Entity<Schools>().OwnsOne(x => x.Address)
                .Property(x => x.Street)
                .HasColumnName("AddressStreet")
                .IsRequired(false);
        builder.Entity<Schools>().OwnsOne(x => x.Address)
                .Property(x => x.Street)
                .HasColumnName("AddressStreet")
                .IsRequired(false);
        builder.Entity<Schools>().OwnsOne(x => x.Address)
                .Property(x => x.Number)
                .HasColumnName("AddressNumber")
                .IsRequired(false);
        builder.Entity<Schools>().OwnsOne(x => x.Address)
                .Property(x => x.Neighborhood)
                .HasColumnName("AddressNeighborhood")
                .IsRequired(false);
        builder.Entity<Schools>().OwnsOne(x => x.Address)
                .Property(x => x.City)
                .HasColumnName("AddressCity")
                .IsRequired(false);
        builder.Entity<Schools>().OwnsOne(x => x.Address)
                .Property(x => x.State)
                .HasColumnName("AddressState")
                .IsRequired(false);
        builder.Entity<Schools>().OwnsOne(x => x.Address)
                .Property(x => x.Country)
                .HasColumnName("AddressCountry")
                .IsRequired(false);
        builder.Entity<Schools>().OwnsOne(x => x.Address)
               .Property(x => x.ZipCode)
               .HasColumnName("AddressZipCode")
               .IsRequired(false);

        builder.Entity<Schools>().OwnsOne(x => x.Document)
               .Property(x => x.Number)
               .HasColumnName("Document")
               .IsRequired();
        builder.Entity<Schools>().OwnsOne(x => x.Document)
               .Property(x => x.Type)
               .HasColumnName("DocumentType")
               .IsRequired();
        builder.Entity<Schools>().OwnsOne(x => x.Email)
               .Property(x => x.Address)
               .HasColumnName("Email")
               .IsRequired();
        #endregion

        #region Students(ValueObjects)
        builder.Entity<Students>().OwnsOne(x => x.Address)
                .Property(x => x.Street)
                .HasColumnName("AddressStreet")
                .IsRequired(false);
        builder.Entity<Students>().OwnsOne(x => x.Address)
                .Property(x => x.Street)
                .HasColumnName("AddressStreet")
                .IsRequired(false);
        builder.Entity<Students>().OwnsOne(x => x.Address)
                .Property(x => x.Number)
                .HasColumnName("AddressNumber")
                .IsRequired(false);
        builder.Entity<Students>().OwnsOne(x => x.Address)
                .Property(x => x.Neighborhood)
                .HasColumnName("AddressNeighborhood")
                .IsRequired(false);
        builder.Entity<Students>().OwnsOne(x => x.Address)
                .Property(x => x.City)
                .HasColumnName("AddressCity")
                .IsRequired(false);
        builder.Entity<Students>().OwnsOne(x => x.Address)
                .Property(x => x.State)
                .HasColumnName("AddressState")
                .IsRequired(false);
        builder.Entity<Students>().OwnsOne(x => x.Address)
                .Property(x => x.Country)
                .HasColumnName("AddressCountry")
                .IsRequired(false);
        builder.Entity<Students>().OwnsOne(x => x.Address)
               .Property(x => x.ZipCode)
               .HasColumnName("AddressZipCode")
               .IsRequired(false);

        builder.Entity<Students>().OwnsOne(x => x.Document)
               .Property(x => x.Number)
               .HasColumnName("Document")
               .IsRequired();
        builder.Entity<Students>().OwnsOne(x => x.Document)
               .Property(x => x.Type)
               .HasColumnName("DocumentType")
               .IsRequired();
       
        builder.Entity<Students>().OwnsOne(x => x.Name)
              .Property(x => x.FullName)
              .HasColumnName("Name")
              .IsRequired();
        builder.Entity<Students>().OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .IsRequired();

        #endregion

        #region Teachers(ValueObjects)
     
        builder.Entity<Students>().OwnsOne(x => x.Document)
               .Property(x => x.Number)
               .HasColumnName("Document")
               .IsRequired();
        builder.Entity<Students>().OwnsOne(x => x.Document)
               .Property(x => x.Type)
               .HasColumnName("DocumentType")
               .IsRequired();

        builder.Entity<Students>().OwnsOne(x => x.Name)
              .Property(x => x.FullName)
              .HasColumnName("Name")
              .IsRequired();
        builder.Entity<Students>().OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .IsRequired();

        #endregion

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder config)
    {
        config.Properties<string>()
            .HaveMaxLength(50);
        config.Properties<DateTime>()
            .HaveColumnType("datetime");

    }

}


