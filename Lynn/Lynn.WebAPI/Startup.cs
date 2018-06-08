using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lynn.BLL;
using Lynn.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddTransient<EnrolledCoursesManager>();
            services.AddTransient<EnrollmentManager>();
            services.AddTransient<ExercisesManager>();
            services.AddTransient<LanguageManager>();
            services.AddTransient<TestsManager>();

            services.AddDbContext<LynnDb>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
