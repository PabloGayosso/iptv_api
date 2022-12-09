using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iptv.AccesoDatos;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using iptv.Negocio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace iptv.Servicios
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
            //Se agrega AutoMapper
            //services.AddAutoMapper();

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretToken"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = new System.TimeSpan(1, 0, 0)
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Mapeo de Interfaces
            services.AddNegocioIptv();

            var MapperConfig = AutoMapperConfiguracion.Configuracion();
            IMapper mapper = MapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            IFileProvider physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

            services.AddSingleton<IFileProvider>(physicalProvider);

            //Info Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "IPTV", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
               new ApiKeyScheme
               {
                   In = "header",
                   Description = "Please enter into field the word 'Bearer' following by space and JWT",
                   Name = "Authorization",
                   Type = "apiKey"
               });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
               { "Bearer", Enumerable.Empty<string>() },});
            });



            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins(new string[] { "http://localhost:8082", "https://localhost:3000", "http://localhost:3000" })
                       //.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Configuration.GetSection("Rutas").GetSection("RutaIPTV").Value + "/Logs/Log-{Date}.txt");
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

                //SE habilita Swagger
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IPTV v1");
                    c.DocExpansion(DocExpansion.None);
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("MyPolicy");
        }
    }
}
