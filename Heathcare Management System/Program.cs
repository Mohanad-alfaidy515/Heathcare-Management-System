
using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Data;
using Service;
using AutoMapper;
using ServiceAbstractions;
using System.Threading.Tasks;
using Service.MappingProfile;
using Microsoft.Extensions.DependencyInjection;
using serviceRef = Service.AssemblyReference2;
using Heathcare_Management_System.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
namespace Heathcare_Management_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(conf=> {
                conf.AddMaps(typeof(serviceRef).Assembly);

                });
            builder.Services.Configure<ApiBehaviorOptions>(conf=>
            {
                conf.InvalidModelStateResponseFactory = (actionContext) =>
                {
                   var errors= actionContext.ModelState.Where(m => m.Value.Errors.Any())
                    .Select(m => new ValidationError()
                    {
                        Field = m.Key,
                        Errors=m.Value.Errors.Select(errors=>errors.ErrorMessage)
                    });
                 
                    var response = new ValidationErrorResponse()
                    {
                        Errors=errors

                    };
                    return new BadRequestObjectResult(response);
                };
            });

            var app = builder.Build();
            using var scope=app.Services.CreateScope();
           var dbinializer= scope.ServiceProvider.GetRequiredService<IDbInitializer>();
           await dbinializer.InitilizeAsync();
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
