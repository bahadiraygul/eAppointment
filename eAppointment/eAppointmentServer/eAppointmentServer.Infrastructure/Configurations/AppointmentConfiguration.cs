using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eAppointmentServer.Domain.Entities;

public sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(a => a.DoctorId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(a => a.PatientId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(a => a.StartDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(a => a.EndDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(a => a.IsCompleted)
            .HasColumnType("tinyint(1)")
            .IsRequired();

        // İlişkiler
        builder.HasOne(a => a.Doctor)
            .WithMany() // Eğer Doctor -> Appointments navigation eklenirse burayı güncelle
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Patient)
            .WithMany() // Eğer Patient -> Appointments navigation eklenirse burayı güncelle
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
