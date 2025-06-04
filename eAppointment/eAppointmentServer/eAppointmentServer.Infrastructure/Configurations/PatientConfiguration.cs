using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eAppointmentServer.Domain.Entities;

public sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);

        // Guid için MySQL'de char(36)
        builder.Property(p => p.Id)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(p => p.FirstName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(p => p.IdentityNumber)
            .HasColumnType("varchar(11)") // TC kimlik numarası için
            .IsRequired();

        builder.Property(p => p.City)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(p => p.Town)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(p => p.FullAddress)
            .HasColumnType("varchar(250)") // veya daha büyükse text
            .IsRequired();
    }
}
