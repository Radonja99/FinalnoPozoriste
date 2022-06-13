using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PozoristeProjekat.Models;
using PozoristeProjekat.Repositories;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoristeProjekat
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
            services.AddControllersWithViews();
            services.AddDbContext<PozoristeContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IIzvedbaRepository, IzvedbaRepository>();
            services.AddScoped<IKorisnikRepository, KorisnikRepository>();
            services.AddScoped<IPozoristeRepository, PozoristeRepository>();
            services.AddScoped<IPredstavaRepository, PredstavaRepository>();
            services.AddScoped<IRezervacijaRepository, RezervacijaRepository>();
            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<ISedisteRepository, SedisteRepository>();
            services.AddScoped<IUrednikRepository, UrednikRepository>();
            services.AddScoped<IJWTAuth,Auth>();
            var key = Configuration["JWT:Key"].ToString();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = "sk_test_51LA8D8ADqdpBkuR8YvCgwwabtHeRAY8rVffgKcONfaJqRTPOFGmZx0Y3aX1MlEgSxRKQHWIGCg64BNGQB1uPg33s00DX700YNX";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
