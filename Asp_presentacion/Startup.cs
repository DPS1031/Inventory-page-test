using Lib_comunicaciones.Implementaciones;
using Lib_comunicaciones.Interfaces;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.Interfaces;

namespace Asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            // Comunicaciones
            services.AddScoped<IInventarioComunicacion, InventarioComunicacion>();
            services.AddScoped<IProductoComunicacion, ProductoComunicacion>();
            services.AddScoped<IProveedorComunicacion, ProveedorComunicacion>();
            services.AddScoped<ISucursalComunicacion, SucursalComunicacion>();
            services.AddScoped<IBodegaComunicacion, BodegaComunicacion>();
            services.AddScoped<IEstanteComunicacion, EstanteComunicacion>();
            services.AddScoped<IAuditoriasComunicacion, AuditoriasComunicacion>();



            // Presentaciones
            services.AddScoped<IInventarioPresentacion, InventarioPresentacion>();
            services.AddScoped<IProductoPresentacion, ProductoPresentacion>();
            services.AddScoped<IProveedorPresentacion, ProveedorPresentacion>();
            services.AddScoped<ISucursalPresentacion, SucursalPresentacion>();
            services.AddScoped<IBodegaPresentacion, BodegaPresentacion>();
            services.AddScoped<IEstantePresentacion, EstantePresentacion>();
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();



            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}