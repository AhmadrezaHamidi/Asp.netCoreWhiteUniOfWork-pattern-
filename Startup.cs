using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PocketBook.Core.IConfiguration;
using TamsaApi.Data;
using TamsaApi.Domain.BaseDomain;
using TamsaApi.ViewModels;
using tTamsaApi.Domain.BaseDomain;

namespace TamsaApi
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

            var address =   Configuration.GetConnectionString("SqlDefault");  
            services.AddControllers();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TamsaApi", Version = "v1" });
            });


            services.AddDbContext<TamsaApisaContext>(options => {
                options.UseSqlServer(address);
            });
            DependeciConrtainer.setServeses(services,Configuration);

            #region Authentication 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(opetion => {
                opetion.LoginPath = "/User/Login";
                opetion.LogoutPath = "/User/LogOut";
                opetion.ExpireTimeSpan = TimeSpan.FromDays(3);
            });
                
            #endregion


        ///Add this dependecies in other classs 
        ///    services.Configure<KaveNegarModel>(Configuration.GetSection("KaveNegar:Api"));///baraye dastreci be maqadire apppseting.json az Configurstion estefade mikonim 
        //    services.Configure<PassarGadModel>(Configuration.GetSection("PassarGad:SeryalNumber"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ///Middle vare ha hastand 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TamsaApi v1"));
            }
            app.UseStatusCodePages();//bara ine ke agar ye safei zad ke jojod nadasht ba in mishe contollersh kard  
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();///Bara token in chizas
            app.UseAuthorization(); //bara sathe dastreci hast  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"Default",
                    pattern: "{controller=WeatherForecast}/{action=Get}"
                );

               // endpoints.MapControllers();
               
                // endpoints.MapControllerRoute(
                //     name:"Insta",
                //     pattern: "insta/{name}",
                //     defaults : new {  controller = "Insta", action = "index"}
                // );


            });
        }
    }
}
