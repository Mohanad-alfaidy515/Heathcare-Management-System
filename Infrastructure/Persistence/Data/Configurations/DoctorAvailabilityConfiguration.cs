using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class DoctorAvailabilityConfiguration : IEntityTypeConfiguration<DoctorAvailability>
    {
        public void Configure(EntityTypeBuilder<DoctorAvailability> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
