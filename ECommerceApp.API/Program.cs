using ECommerceApp.BL.AutoMapper;
using ECommerceApp.BL.Helpers;
using ECommerceApp.BL.Managers.AuthManager;
using ECommerceApp.DAL.Data.Context;
using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.NonGeneric.User_NonGeneric;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Context Configuration
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Base Classes 
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            #endregion

            #region Auto mapper configs
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiler).Assembly);
            #endregion

            #region MAnager configs
            builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            #endregion

            #region Identity usermanager configuration
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion
            //To inject iConfiguration
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            #region Authentication Configs
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Default";
                options.DefaultChallengeScheme = "Default";
            }).AddJwtBearer("Default", options =>
            {
                SymmetricSecurityKey key = JWT.getKey(builder.Configuration);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}