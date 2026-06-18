using Domain.Contract;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer(ApplicationDbContext _context, RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager) : IDbInitializer
    {
        public async Task InitilizeAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            //check any pending migration 
            if(_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync(); 
            }

            // Seed Roles
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await _roleManager.RoleExistsAsync("Doctor"))
                await _roleManager.CreateAsync(new IdentityRole("Doctor"));
            if (!await _roleManager.RoleExistsAsync("Patient"))
                await _roleManager.CreateAsync(new IdentityRole("Patient"));

            // Seed Admin User
            if (await _userManager.FindByEmailAsync("admin@healthcare.com") == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@healthcare.com",
                    Email = "admin@healthcare.com",
                    FirstName = "System",
                    LastName = "Admin",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(admin, "Admin@123456");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_context.Specializations.Any()) {

                //Read all textAsync from json file
                var Data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeeding\specializations.json");
                //convertdata to List<Specialization>>(Data, options)
                var types = JsonSerializer.Deserialize<List<Specialization>>(Data, options);
                if (types is not null && types.Any())
                {
                    await _context.Database.OpenConnectionAsync();
                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Specializations ON");
                        await _context.Specializations.AddRangeAsync(types);
                        await _context.SaveChangesAsync();
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Specializations OFF");
                    }
                    finally { await _context.Database.CloseConnectionAsync(); }
                }
            }

            if(!_context.Doctors.Any())
            {
                var Data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeeding\Doctors.json");
                var types1= JsonSerializer.Deserialize<List<Doctor>>(Data,options) ;
                if (types1 is not null && types1.Any())
                {
                    await _context.Database.OpenConnectionAsync();
                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Doctors ON");
                        await _context.Doctors.AddRangeAsync(types1);
                        await _context.SaveChangesAsync();
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Doctors OFF");
                    }
                    finally { await _context.Database.CloseConnectionAsync(); }
                }

            }

            if(!_context.Patients.Any())
            {
                var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeeding\patients.json");
                var type=JsonSerializer.Deserialize<List<Patient>>(data,options) ;
                if (type is not null && type.Any())
                {
                    await _context.Database.OpenConnectionAsync();
                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Patients ON");
                        await _context.Patients.AddRangeAsync(type);
                        await _context.SaveChangesAsync();
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Patients OFF");
                    }
                    finally { await _context.Database.CloseConnectionAsync(); }
                }
            }
            if(!_context.Appointments.Any())
            {
                var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeeding\appointments.json");
                var type=JsonSerializer.Deserialize<List<Appointment>>(data,options) ;
                if (type is not null && type.Any())
                {
                    await _context.Database.OpenConnectionAsync();
                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Appointments ON");
                        await _context.Appointments.AddRangeAsync(type);
                        await _context.SaveChangesAsync();
                        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Appointments OFF");
                    }
                    finally { await _context.Database.CloseConnectionAsync(); }
                }
            }


            if(_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();   
            }

        }

        public async Task InitilizeidentityAsync()
        {
            await Task.CompletedTask;
        }
    }
}
