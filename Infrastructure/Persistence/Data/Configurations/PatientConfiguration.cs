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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            
            builder.Property(p => p.Gender)
             .HasConversion<string>();
            builder.Property(p => p.DateOfBirth)
                .IsRequired();
            builder.Property(p => p.CreateAt)
               .HasDefaultValueSql("GETDATE()");//to create time with diffrent servies
           
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
