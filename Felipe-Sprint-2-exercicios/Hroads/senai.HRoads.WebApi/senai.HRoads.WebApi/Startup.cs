using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Senai.HRoads.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    // Ignora os loopings nas consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    // Ignora valores nulos ao fazer jun��es nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";

            })
            .AddJwtBearer("JwtBearer", Options =>
            {
                //Quem est� emitindo
                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Quem est� emitiondo
                    ValidateIssuer = true,

                    //quem est� recebendo
                    ValidateAudience = true,

                    //O tempo de expira��o
                    ValidateLifetime = true,

                    //forma de criptografia e a chave de autentica��o
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuarios-chave-autenticacao")),

                    //Tempo de expira��o do token
                    ClockSkew = TimeSpan.FromMinutes(30),

                    //Nome do issuer
                    ValidIssuer = "HRoads.webApi",

                    ValidAudience = "HRoads.webApi",
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            //Habilita a autentica��o
            app.UseAuthentication();

            //Habilita a autoriza��o
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
