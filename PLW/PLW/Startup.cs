using Framework.Common.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PLW.Api.Configuration;
using PLW.Data.Entity;
using PLW.Data.Model;
using System;
using System.Text;

namespace PLW
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
            // Add DB config
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Permission.Data")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            var JwtSettings = Configuration.GetSection("JwtSettings").Get<JwtConfig>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PLW Api", Version = "v1" });
            });

            //Configure jwt authentication
            //services.AddAuthentication("Bearer")
            //       .AddIdentityServerAuthentication(options =>
            //       {
            //           options.Authority = JwtSettings.Issuer;
            //           options.RequireHttpsMetadata = false;
            //           options.ApiName = JwtSettings.ApiName;
            //       });
            var appSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecurityKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    LifetimeValidator = CustomLifetimeValidator,
                    ValidateIssuer = false,
                    RequireExpirationTime = true,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IJwtTokenManager, JwtTokenManager>();


            // configure DI for application services
            services.ConfigDI();


            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "PLW Api V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }
            return false;
        }
    }
}
