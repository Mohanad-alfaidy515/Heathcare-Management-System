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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName). 
                IsRequired().
                HasMaxLength(50);
            builder.Property(p=>p.LastName).
                IsRequired().
                HasMaxLength(50);
            builder.HasOne(p => p.Specialization)
                .WithMany(p => p.Doctors)
                .HasForeignKey(p => p.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Title).HasMaxLength(50);

            //soft query
            builder.HasQueryFilter(p =>! p.IsDeleted);

            builder.Property(p=>p.bio).HasMaxLength(50);
            builder.Property(p => p.CreateAt)
               .HasDefaultValueSql("GETDATE()");//to create time with diffrent servies
        }
    }
}
