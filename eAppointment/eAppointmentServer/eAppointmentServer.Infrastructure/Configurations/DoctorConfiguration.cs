using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(d => d.Id);

        // Guid -> char(36)
        builder.Property(d => d.Id)
            .HasColumnType("char(36)")
            .IsRequired();

        // FirstName ve LastName -> varchar(50) 
        builder.Property(d => d.FirstName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(d => d.LastName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        // Department alanı için string dönüşümü
        builder.Property(d => d.Department)
            .HasConversion(
                d => d.Name,  // DepartmentEnum -> string
                name => DepartmentEnum.FromName(name, true)) // string -> DepartmentEnum
            .HasColumnType("varchar(50)")
            .IsRequired();

        // FullName property'si için ignore, çünkü computed property
        builder.Ignore(d => d.FullName);
    }
}
