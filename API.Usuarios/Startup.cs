using API.Usuarios.Data.Configurations;
using API.Usuarios.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios
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

            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API.Usuarios", Version = "v1"});
            }
            );


            //Le uma confiração no jason e fala pra aplicação puchar os dados
            //name of pega a configuração a partir do nome dela. No app setigns crio uma configuração 
            //com este mesmo nome.
            services.Configure<DatabaseConfig>(Configuration.GetSection(nameof(DatabaseConfig)));
            
            //Injeta a configaração database config na interface. 
            services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);
            
            //O singleton passa a interface repositore e fala que aquela classe vai
            //usuarios repository, irá implementar esta abstração. Configuração da injeção de dependencia.
            services.AddSingleton<IUsuariosRepository, UsuariosRepository>();
            services.AddSingleton<ICategoriaRepository, CategoriaRepository>();

            services.AddControllers();


            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200");
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {




            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API.Usuarios v1"));

            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Meu Swagger V1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();

            } ); }
    }
}
