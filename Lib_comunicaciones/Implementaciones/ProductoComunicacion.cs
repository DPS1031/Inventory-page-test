using Lib_comunicaciones.Interfaces;
using System.Net.Http;
using System.Data;

namespace Lib_comunicaciones.Implementaciones
{
    public class ProductoComunicacion : IProductoComunicacion
    {
        private Comunicaciones? comunicaciones = null;
        private string? Nombre = "Producto";

        public ProductoComunicacion()
        {
            comunicaciones = new Comunicaciones(Nombre);
        }

        public async Task<Dictionary<string, object>> Guardar(Dictionary<string, object> datos, string Usuario)
        {
            datos = comunicaciones!.BuildUrl(datos, "Guardar");
            return await comunicaciones!.Execute(datos, Usuario);
        }

        public async Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Buscar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Listar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Modificar(Dictionary<string, object> datos, string Usuario)
        {
            datos = comunicaciones!.BuildUrl(datos, "Modificar");
            return await comunicaciones!.Execute(datos, Usuario);
        }

        public async Task<Dictionary<string, object>> Borrar(Dictionary<string, object> datos, string Usuario)
        {
            datos = comunicaciones!.BuildUrl(datos, "Borrar");
            return await comunicaciones!.Execute(datos, Usuario);
        }
    }
}