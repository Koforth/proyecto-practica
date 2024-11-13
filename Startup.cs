using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaEscolar.Data;

namespace SistemaEscolar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método se llama en tiempo de ejecución. Aquí se agregan los servicios al contenedor de DI.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración del contexto de base de datos usando SQL Server
            services.AddDbContext<SistemaEscolarContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SistemaEscolarContext")));

            // Configuración de autenticación basada en cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Cuenta/Login";             // Ruta de inicio de sesión
                    options.AccessDeniedPath = "/Cuenta/AccesoDenegado"; // Ruta para acceso denegado
                });

            services.AddControllersWithViews();
        }

        // Este método se llama en tiempo de ejecución para configurar el middleware de la aplicación.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Habilitar autenticación en la aplicación
            app.UseAuthorization();  // Habilitar autorización

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}