using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb_MGM.Data;
using CMDb_MGM.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CMDb_MGM
{
    public class Startup
    {
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //--Repon--//

            //services.AddScoped<IOMDbRepo, OMDbRepo>();
            //services.AddScoped<ICMDbRepo, CMDbRepo>();

            //--Mockrepon--//

            services.AddScoped<IOMDbRepo, OMDbMockRepo>();
            services.AddScoped<ICMDbRepo, CMDbMockRepo>();

        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseStaticFiles();
            app.UseRouting();    


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=start}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
