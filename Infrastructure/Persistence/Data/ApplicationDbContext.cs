using Domain.Models;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Doctor> Doctors {  get; set; }
        public DbSet<Patient> Patients { get; set; }   
        public DbSet<Appointment> Appointments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefrences).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
