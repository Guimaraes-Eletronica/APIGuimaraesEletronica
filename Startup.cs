using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiGuimaraesEletronica.Domain;
using apiGuimaraesEletronica.Mock;
<<<<<<< HEAD
using ApiGuimaraesEletronica.Models;
=======
>>>>>>> 03a228cfef98da2014f5c32b81d78af9b4c45195
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> 03a228cfef98da2014f5c32b81d78af9b4c45195
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace apiGuimaraesEletronica
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
            services.AddSingleton<ProductRepository>();
            services.AddSingleton<CartRepository>();

            services.AddControllers();
<<<<<<< HEAD

            services.AddDbContext<guimaraeseletronicaContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("EletronicaDatabase")));
            services.AddMvc();
=======
>>>>>>> 03a228cfef98da2014f5c32b81d78af9b4c45195
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
