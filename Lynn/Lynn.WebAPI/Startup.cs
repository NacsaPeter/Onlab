using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lynn.BLL;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DAL.Identity;
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
            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<EnrollmentManager>();
            services.AddTransient<ExercisesManager>();
            services.AddTransient<LanguageManager>();
            services.AddTransient<TestsManager>();
            services.AddSingleton<IMapper>(MapperConfig.Configure());

            services.AddDbContext<LynnDb>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<LynnDb>()
                .AddDefaultTokenProviders();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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
                    options.Authority = "http://localhost:56750";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
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
            app.UseMvc();
        }
    }
}
