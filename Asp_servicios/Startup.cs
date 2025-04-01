using asp_servicios.Controllers;
using Lib_aplicaciones.Implementaciones;
using Lib_aplicaciones.Interfaces;
using Lib_repositorios;
using Lib_repositorios.Implementaciones;
using Lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
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
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IInventarioRepositorio, InventarioRepositorio>();
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IProveedorRepositorio, ProveedorRepositorio>();
            services.AddScoped<ISucursalRepositorio, SucursalRepositorio>();
            services.AddScoped<IBodegaRepositorio, BodegaRepositorio>();
            services.AddScoped<IEstanteRepositorio, EstanteRepositorio>();
            services.AddScoped<IAuditoriasRepositorio, AuditoriasRepositorio>();



            // Aplicaciones
            services.AddScoped<I_InventarioAplicacion, InventarioAplicacion>();
            services.AddScoped<I_ProductoAplicacion, ProductoAplicacion>();
            services.AddScoped<I_ProveedorAplicacion, ProveedorAplicacion>();
            services.AddScoped<I_SucursalAplicacion, SucursalAplicacion>();
            services.AddScoped<I_BodegaAplicacion, BodegaAplicacion>();
            services.AddScoped<I_EstanteAplicacion, EstanteAplicacion>();
            services.AddScoped<I_AuditoriasAplicacion, AuditoriasAplicacion>();

            // Controladores
            services.AddScoped<TokenController>();
            services.AddScoped<InventarioController>();
            services.AddScoped<ProductoController>();
            services.AddScoped<ProveedorController>();
            services.AddScoped<SucursalController>();
            services.AddScoped<BodegaController>();
            services.AddScoped<EstanteController>();
            services.AddScoped<AuditoriasController>();


            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}