using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // Guid tipi MySQL'de char(36) olarak saklanmalı
        builder.Property(u => u.Id)
            .HasColumnType("char(36)")
            .IsRequired();

        // FirstName ve LastName varchar(50), zorunlu alanlar
        builder.Property(u => u.FirstName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        // FullName sadece C# tarafında hesaplanıyor, DB'de yer almaz
        builder.Ignore(u => u.FullName);
    }
}
