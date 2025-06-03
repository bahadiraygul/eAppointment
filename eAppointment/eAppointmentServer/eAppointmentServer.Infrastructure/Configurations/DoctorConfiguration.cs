

using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations;

internal sealed class DoctorConfiguration
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(p => p.FirstName).HasColumnType("varChar(50)");
        builder.Property(p => p.LastName).HasColumnType("varChar(50)");

        // Additional configurations can be added here
    }
}
