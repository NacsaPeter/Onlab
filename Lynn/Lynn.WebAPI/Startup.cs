using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lynn.BLL;
using Lynn.BLL.Interfaces;
using Lynn.BLL.Managers;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DAL.Identity;
using Lynn.DAL.Repositories;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.WebAPI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lynn.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICourseManager, CourseManager>();
            services.AddTransient<IEnrollmentManager, EnrollmentManager>();
            services.AddTransient<IExerciseManager, ExerciseManager>();
            services.AddTransient<ILanguageManager, LanguageManager>();
            services.AddTransient<ITestManager, TestManager>();
            services.AddTransient<IUserManager, UserManager>();

            services.AddSingleton(MapperConfig.Configure());

            services.AddDbContext<LynnDb>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<LynnDb>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<ProfileService>();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:57770";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "lynnapi";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("GuruOnly", policy => policy.RequireClaim("Level", "Guru"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseIdentityServer();
            app.UseMvc();
        }
    }
}
