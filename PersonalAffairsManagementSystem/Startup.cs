using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PAMS.Common;

namespace PersonalAffairsManagementSystem
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            Connection.MySqlConnection =Configuration.GetConnectionString("MySqlConnection");
            Connection.SqlConnection = Configuration.GetConnectionString("MySqlConnection");
            RedisConfig.Connection = Configuration.GetSection("RedisConfig")["Connection"];
            RedisConfig.DefaultDataBase =Convert.ToInt32( Configuration.GetSection("RedisConfig")["DefaultDatabase"]);
            RedisConfig.InstanceName = Configuration.GetSection("RedisConfig")["InstanceName"];
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //var connection = @"Server=.;Database=Performance;UID=sa;Password=123sa;";
            //services.AddDbContext<User>(options=>);

            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1", new Info
            //    {
            //        Contact = new Contact
            //        {
            //            Name = "Danvic Wang",
            //            Email = "danvic96@hotmail.com",
            //            Url = "https://yuiter.com"
            //        },
            //        Description = "A front-background project build by ASP.NET Core 2.1 and Vue",
            //        Title = "Grapefruit.VuCore",
            //        Version = "v1"
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Logon}/{action=Welcome}/{id?}");//Home表示文件夹，action表示页面文件
            });
        }
    }
}
