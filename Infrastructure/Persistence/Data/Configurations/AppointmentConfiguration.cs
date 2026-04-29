using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {

            builder.HasOne(p => p.doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Patient)
                .WithMany(p=>p.Appointments)
                .HasForeignKey(p=>p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.Status)
                .HasConversion<string>();
            builder.Property(p => p.CreateAt)
                .HasDefaultValueSql("GETDATE()");//to create time with diffrent servies
            builder.Property(p => p.Notes).HasMaxLength(100);
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
