using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SupportRegister.Application.Interfaces;
using SupportRegister.Application.Services;
using SupportRegister.Application.System.Roles;
using SupportRegister.Application.System.Users;
using SupportRegister.Data.EF;
using SupportRegister.Data.Interfaces;
using SupportRegister.Data.Models;
using SupportRegister.Data.Repository;
using SupportRegister.Utilities.SystemConstants;
using System;

namespace SupportRegister.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectSupportRegisterContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MAIN_CONNECTION_STRING)));
            services.AddControllers();

            // automapper
            services.AddAutoMapper(typeof(Startup).Assembly);

            // Add services Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ProjectSupportRegisterContext>()
                .AddDefaultTokenProviders();


            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IStorageService, StorageService>();
            services.AddTransient<IScoreboardService, ScoreboardService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // DI for identity

            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<IUserService, UserService>();

            //// Add services SqlServer
            //services.AddDbContext<ProjectSupportRegisterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SupportRegister.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupportRegister.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
