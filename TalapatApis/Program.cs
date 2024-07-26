using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Talapat.Core.Entities;
using Talapat.Core.Identity;
using Talapat.Core.Repositories;
using Talapat.Repository;
using Talapat.Repository.Data;
using Talapat.Repository.Identity;
using TalapatApis.Errors;
using TalapatApis.Extensions;
using TalapatApis.Helper;

namespace TalapatApis
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Configure service
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // allow dependency injection for StoreContext
            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            // open connection with redis

            builder.Services.AddSingleton<IConnectionMultiplexer>(Options =>
            {
                var connection = builder.Configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(connection);

            });


            builder.Services.AddDbContext<AppIdentityDbContext>(Options =>
            {

                Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });




            builder.Services.AddApplicationsServices();

            builder.Services.AppIdentityServices(builder.Configuration); 





            #endregion 


            var app = builder.Build();


            #region Update DataBase
            // StoreContext DbContext = new StoreContext();   In valid ..ClR will do it
            //await DbContext.Database.MigrateAsync();

                using var Scope = app.Services.CreateScope();//group of services life time is scoped[on of them is DbContext]
                var Services = Scope.ServiceProvider;// Services is self
            var loggerfactory= Services.GetService<ILoggerFactory>();
            try
            {
                var DbContext = Services.GetRequiredService<StoreContext>(); // asked clr to create  object from DbContext expilicit
                await DbContext.Database.MigrateAsync();

                var IdentityDbContext=Services.GetRequiredService<AppIdentityDbContext>();
                await IdentityDbContext.Database.MigrateAsync();    //update Database 

             await   StoreContextSeed.SeedAsync(DbContext);

                var usermanger= Services.GetRequiredService<UserManager<AppUser>>();
               await AppIdentityDbContextSeed.SeedUserAsync(usermanger);

            }
            catch (Exception ex)
            {

                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during updating database");
            }


            #endregion



            // Configure the HTTP request pipeline.
            #region Configure
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();


            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers(); 
            #endregion 

            app.Run();
        }
    }
}